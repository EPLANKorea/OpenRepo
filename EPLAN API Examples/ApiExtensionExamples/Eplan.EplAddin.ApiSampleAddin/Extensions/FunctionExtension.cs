using Eplan.EplAddin.ApiSampleAddin.Logging;
using Eplan.EplApi.DataModel;
using log4net;

namespace Eplan.EplAddin.ApiSampleAddin.Extensions
{
    public static class FunctionExtension
    {
        private static ILog _logger = LoggerFactory.GetLogger(typeof(FunctionExtension));

        #region Public Methods

        /// <summary>
        /// BOM Part를 가질 수 있는 Function인가??
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public static bool CanHaveBOMPart(this Function function)
        {
            if (_logger.IsDebugEnabled)
                _logger.DebugFormat("canHaveBOMPart(), function=[{0}]", function == null ? "NULL" : string.Format("{0},{1},{2},{3}", function.VisibleName, function.Name, function.IsNameEmpty, function.Category));

            if (function == null || !function.IsMainFunction)
                return false;

            return function.CanHaveArticleData && !function.IsNameEmpty;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
