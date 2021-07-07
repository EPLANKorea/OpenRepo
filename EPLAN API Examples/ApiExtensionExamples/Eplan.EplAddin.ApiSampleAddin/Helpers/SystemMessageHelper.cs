using Eplan.EplApi.Base;
using System;

namespace Eplan.EplAddin.ApiSampleAddin.Helpers
{
    public static class SystemMessageHelper
    {
        #region Public Methods

        public static void HandleException(Exception exception, MessageLevel messageLevel = MessageLevel.Message)
        {
            if (exception == null)
                return;

            if (exception is BaseException)
                AddSystemMessage(exception as BaseException);
            else
                AddSystemMessage(exception.Message, messageLevel);

            if (exception.InnerException != null)
                HandleException(exception.InnerException, messageLevel);
        }

        public static void AddSystemMessage(string message, MessageLevel messageLevel = MessageLevel.Message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            using (BaseException bex = new BaseException(message, messageLevel))
            {
                AddSystemMessage(bex);
            }
        }

        #endregion

        #region Private Methods

        private static void AddSystemMessage(BaseException baseException)
        {
            baseException.FixMessage();
        }

        #endregion
    }
}
