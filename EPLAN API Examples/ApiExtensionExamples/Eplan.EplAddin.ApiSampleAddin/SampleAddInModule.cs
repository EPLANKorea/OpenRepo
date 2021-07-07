using Eplan.EplAddin.ApiSampleAddin.Events;
using Eplan.EplAddin.ApiSampleAddin.Logging;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Gui;
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
        private ILog _logger = null;
        private string _originalAssemblyPath = string.Empty;

        private SymbolPartChangedActionEventListener _symbolPartChangedEventListener = null;

        public SampleAddInModule()
        {
            try
            {
                var shadowAssemblyPath = Path.GetDirectoryName(this.GetType().Assembly.Location);

                InitializeLogging();

                if (this._logger != null)
                    this._logger.InfoFormat("Constructor(), initializing Add-In...[{0}]", shadowAssemblyPath);
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

            this._symbolPartChangedEventListener = new SymbolPartChangedActionEventListener(null);

            return true;
        }

        public bool OnInitGui()
        {
            if (this._logger != null)
                this._logger.InfoFormat("OnInitGui()@{0}", DateTime.Now);

            Menu apiExtMenu = new Menu();

            uint menuId = apiExtMenu.AddMainMenu("[API Extensions]", Menu.MainMenuName.eMainMenuHelp,
                                                  "FirstAction Text", "FirstAction", "First Action Samples", 1);
            menuId = apiExtMenu.AddMenuItem("Call Other Action", "ActionApiExtCallOtherAction", "Call Other Action", menuId, 1, false, false);

            uint popupMenuId = apiExtMenu.AddPopupMenuItem("API Popup Menu", "Popup Menu Sample", "ActionApiExtPopupMenu", "Popup Menu Sample...", menuId, 1, false, false);
            popupMenuId = apiExtMenu.AddMenuItem("Next Symbol Variant", "ActionNextSymbolVariant", "Next Symbol Variant...", popupMenuId, 1, false, false);

            menuId = apiExtMenu.AddMenuItem("Gui Examples", "ActionApiExtWithGuiSamples", "Gui Examples...", menuId, 1, false, false);

            ContextMenu contextMenu = new ContextMenu();
            ContextMenuLocation menuLocation = new ContextMenuLocation("Editor", "Ged");
            contextMenu.AddMenuItem(menuLocation, "API Ext Context Menu", "ActionApiContextMenu", true, false);

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

            return true;
        }

        public bool OnUnregister()
        {
            if (this._logger != null)
                this._logger.InfoFormat("OnUnregister()@{0}", DateTime.Now);

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
            string configFileFullPath = ".\\Config\\log4net.config";

            LoggerFactory.InitializeLogging(configFileFullPath);
            this._logger = LoggerFactory.GetLogger(this.GetType());

            if (this._logger != null)
                this._logger.DebugFormat("InitializeLogging(), LoggerFactory Initialized!!!, configFileFullPath=[{0}]", configFileFullPath);

            return configFileFullPath;
        }

        #endregion
    }
}
