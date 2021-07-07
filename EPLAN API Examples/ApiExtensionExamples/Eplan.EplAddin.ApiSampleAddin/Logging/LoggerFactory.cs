using log4net;
using log4net.Config;
using System;
using System.Collections;
using System.IO;

namespace Eplan.EplAddin.ApiSampleAddin.Logging
{
    public static class LoggerFactory
    {

        #region Public Methods

        /// <summary>
        /// 주어진 configuration file을 이용하여 Logging (Log4Net) configuration 로딩
        /// - <paramref name="configFilePath"/>가 NULL, Empty인 경우에는 Application 기본 config 파일로 초기화 
        /// </summary>
        /// <param name="configFilePath">configuration 파일 full path</param>
        public static void InitializeLogging(string configFilePath = "")
        {
            FileInfo configFile = null;

            // 1. FileInfo 초기화
            if (!string.IsNullOrWhiteSpace(configFilePath))
                configFile = new FileInfo(configFilePath);

            // 2. Log4Net 초기화,
            LoggerFactory.ConfigureAndWatch(configFile, true);
        }

        public static ILog GetLogger(Type declaringType)
        {
            return LogManager.GetLogger(declaringType);
        }

        #endregion

        #region Private Methods

        private static void ConfigureAndWatch(FileInfo configFile = null, bool watch = true)
        {
            if (configFile != null && watch)
                LoggerFactory.ConfigureAndWatchInternal(configFile);
            else
                LoggerFactory.Configure(configFile);
        }

        /// <summary>
        /// Log4Net 설정 초기화
        /// </summary>
        /// <param name="configFile"></param>
        /// <returns></returns>
        private static ICollection Configure(FileInfo configFile = null)
        {
            if (configFile == null)
                return XmlConfigurator.Configure();

            return XmlConfigurator.Configure(configFile);
        }

        /// <summary>
        /// Log4Net 설정 초기화
        /// </summary>
        /// <param name="configFile"></param>
        /// <returns></returns>
        private static ICollection ConfigureAndWatchInternal(FileInfo configFile)
        {
            if (configFile == null)
                throw new ArgumentNullException("configFile", "You should provide xml configuration file for Log4Net.");

            return XmlConfigurator.ConfigureAndWatch(configFile);
        }

        #endregion
    }
}
