using Eplan.EplAddin.ApiSampleAddin.Extensions;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.HEServices;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Eplan.EplAddin.ApiSampleAddin.Events
{
    public class SymbolPartChangedActionEventListener
    {
        private const string EVENT_NAME = "onActionEnd.String.XGedEditPropertiesAction";
        Eplan.EplApi.ApplicationFramework.EventHandler _myHandler = new Eplan.EplApi.ApplicationFramework.EventHandler();
        TextBox _logger = null;

        public SymbolPartChangedActionEventListener(TextBox logger)
        {
            this._logger = logger;
            this._myHandler.SetEvent(EVENT_NAME);

            this._myHandler.EplanNameEvent += SymbolPartChangedEventListener_EplanNameEvent;
        }

        public void ClearEventListener()
        {
            if (this._logger != null)
                this._logger.Clear();

            this._myHandler.EplanNameEvent -= SymbolPartChangedEventListener_EplanNameEvent;
        }

        #region Event Hanlder

        private void SymbolPartChangedEventListener_EplanNameEvent(IEventParameter eventParameter, string eventName)
        {
            this.LogEvent(eventParameter, eventName);

            SelectionSet selection = new SelectionSet();

            foreach (var function in selection.Selection.OfType<Function>())
            {
                if (function.IsMainFunction)
                    FunctionImageExtension.DoImage(function);
            }
        }

        #endregion

        #region Private Methods

        private void LogEvent(IEventParameter eventParameter, string eventName)
        {
            if (this._logger == null)
                return;

            string parameter = string.Empty;

            try
            {
                EventParameterString oEventParameterString = new EventParameterString(eventParameter);
                parameter = oEventParameterString.String;

                this._logger.AppendText(string.Format("{0}: {1}\t{2}{3}", DateTime.Now.ToString("s"), eventName, parameter, Environment.NewLine));
            }
            catch (System.InvalidCastException exc)
            {
                this._logger.AppendText(string.Format("{0}: {1}\t{2}{3}", DateTime.Now.ToString("s"), eventName, exc.Message, Environment.NewLine));
            }
        }

        #endregion
    }
}
