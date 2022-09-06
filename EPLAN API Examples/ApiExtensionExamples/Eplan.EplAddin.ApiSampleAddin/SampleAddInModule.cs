using Eplan.EplAddin.ApiSampleAddin.Events;
using Eplan.EplAddin.ApiSampleAddin.Internals;
using Eplan.EplAddin.ApiSampleAddin.Logging;
using Eplan.EplApi.ApplicationFramework;
using log4net;
using System;
using System.IO;

namespace Eplan.EplAddin.ApiSampleAddin
{
    /// <summary>
    ///   That is an example for a EPLAN addin.  
    ///   Exactly a class must implement the interface Eplan.EplApi.ApplicationFramework.IEplAddIn.  
    ///   An Assembly is identified through this criterion as EPLAN addin!  
    /// </summary>  

    public class SampleAddInModule : IEplAddIn, IEplAddInShadowCopy
    {
        private readonly string _log4netConfigFile = ".\\Config\\log4net.config";
        private ILog _logger = null;
        private string _originalAssemblyPath = string.Empty;
        private string _shadowAssemblyPath = string.Empty;

        private SymbolPartChangedActionEventListener _symbolPartChangedEventListener = null;

        public SampleAddInModule()
        {
            try
            {
                this._shadowAssemblyPath = Path.GetDirectoryName(this.GetType().Assembly.Location);

                if (this._logger != null)
                    this._logger.InfoFormat("Constructor(), initializing Add-In...[{0}]", this._shadowAssemblyPath);
            }
            catch (Exception ex)
            {
                if (this._logger != null)
                    this._logger.Fatal("Constructor(), Error while initializing Add-In!!!", ex);

                throw;
            }
        }

        #region IEplAddIn Implementations

        public bool OnInit()
        {
            if (this._logger != null)
                this._logger.InfoFormat("OnInit()@{0}", DateTime.Now);

            InitializeLogging();

            this._symbolPartChangedEventListener = new SymbolPartChangedActionEventListener(null);

            return true;
        }

        public bool OnInitGui()
        {
            if (this._logger != null)
                this._logger.InfoFormat("OnInitGui()@{0}", DateTime.Now);

            CustomMenuBuilder.CreateMenuAndToolbar(true);

            return true;
        }

        public bool OnExit()
        {
            if (this._logger != null)
                this._logger.InfoFormat("OnExit()@{0}", DateTime.Now);

            return true;
        }

        public bool OnRegister(ref bool bLoadOnStart)
        {
            if (this._logger != null)
                this._logger.InfoFormat("OnRegister()@{0}", DateTime.Now);

            bLoadOnStart = true;

            CustomMenuBuilder.RegisterMenuAndToolbar(true);

            return true;
        }

        public bool OnUnregister()
        {
            if (this._logger != null)
                this._logger.InfoFormat("OnUnregister()@{0}", DateTime.Now);

            CustomMenuBuilder.UnregisterMenuAndToolbar(true);

            return true;
        }

        #endregion

        #region IEplAddInShadowCopy

        public void OnBeforeInit(string strOriginalAssemblyPath)
        {
            try
            {
                this._originalAssemblyPath = Path.GetDirectoryName(strOriginalAssemblyPath);

                if (this._logger != null)
                    this._logger.DebugFormat("OnBeforeInit(), strOriginalAssemblyPath=[{0}], this._originalAssemblyPath=[{1}]", strOriginalAssemblyPath, this._originalAssemblyPath);
            }
            catch (Exception ex)
            {
                if (this._logger != null)
                    this._logger.Fatal("OnBeforeInit(), Error while initializing Add-In!!!", ex);

                throw;
            }
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Logging (Log4Net) 초기화
        /// </summary>
        /// <returns>초기화에 사용된 Config File Full Path</returns>
        private string InitializeLogging()
        {
            string configFileFullPath = Path.Combine(this._shadowAssemblyPath, this._log4netConfigFile);
            EnsureLog4NetConfigurationFile(configFileFullPath);

            LoggerFactory.InitializeLogging(configFileFullPath);
            this._logger = LoggerFactory.GetLogger(this.GetType());

            if (this._logger != null)
                this._logger.DebugFormat("InitializeLogging(), LoggerFactory Initialized!!!, configFileFullPath=[{0}]", configFileFullPath);

            return configFileFullPath;
        }

        /// <summary>
        /// EPLAN Version에 따라 Log4Net Configuration 파일이 복사되지 않는 경우가 있음
        /// - 실제 위치에 존재하는지 확인하고 없으면 설치 위치에서 복사해 옴
        /// </summary>
        private void EnsureLog4NetConfigurationFile(string configFileFullPath)
        {
            if (File.Exists(configFileFullPath))
                return;

            // if NOT, Copy from original path
            try
            {
                string configFolder = Path.GetDirectoryName(configFileFullPath);

                if (!Directory.Exists(configFolder))
                    Directory.CreateDirectory(configFolder);

                File.Copy(Path.Combine(this._originalAssemblyPath, this._log4netConfigFile), configFileFullPath, true);
            }
            catch
            {
            }
        }

        #endregion
    }
}
