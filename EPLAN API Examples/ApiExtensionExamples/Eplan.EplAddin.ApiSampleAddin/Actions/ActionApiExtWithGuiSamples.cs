using Eplan.EplAddin.ApiSampleAddin.Forms;
using Eplan.EplAddin.ApiSampleAddin.Helpers;
using Eplan.EplAddin.ApiSampleAddin.Logging;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using log4net;
using System;
using System.Windows.Forms;

namespace Eplan.EplAddin.ApiSampleAddin.Actions
{
    /// <summary>
    /// This class implements a EPLAN action.  The Action will register the Addins in that  <seealso cref="IEplAddIn.OnRegister"/> Registerst.
    /// <seealso cref="Eplan::EplApi::ApplicationFramework::IEplAction"/> 
    /// </summary>
    public class ActionApiExtWithGuiSamples : IEplAction
    {
        private readonly ILog _logger = null;

        public ActionApiExtWithGuiSamples()
        {
            try
            {
                this._logger = LoggerFactory.GetLogger(this.GetType());
            }
            catch (Exception ex)
            {
                SystemMessageHelper.HandleException(ex, MessageLevel.Error);

                throw;
            }
        }

        /// <summary>
        /// Execution of the Action.  
        /// </summary>
        /// <returns>True:  Execution of the Action was successful</returns>
        public bool Execute(ActionCallingContext ctx)
        {
            using (Form form = new ApiExtSampleForm())
            {
                form.ShowDialog(WindowWrapper.GetEplanMainWindow());
            }

            return true;
        }

        /// <summary>
        /// Function is called through the ApplicationFramework
        /// </summary>
        /// <param name="Name">Under this name, this Action in the system is registered</param>
        /// <param name="Ordinal">With this overload priority, this Action is registered</param>
        /// <returns>true: the return parameters are valid</returns>
        public bool OnRegister(ref string Name, ref int Ordinal)
        {
            Name = "ActionApiExtWithGuiSamples";
            Ordinal = 20;
            return true;
        }

        /// <summary>
        /// Documentation function for the Action; is called of the system as required 
        /// Bescheibungstext delivers for the Action itself and if the Action String-parameters ("Kommandozeile")
        /// also name and description of the single parameters evaluates
        /// </summary>
        /// <param name="actionProperties"> This object must be filled with the information of the Action.</param>
        public void GetActionProperties(ref ActionProperties actionProperties)
        {
            // Description 1st parameter
            // ActionParameterProperties firstParam= new ActionParameterProperties();
            // firstParam.set("Param1", "1. Parameter for FirstAction"); 
            // actionProperties.addParameter(firstParam);

            // Description 2nd parameter
            // ActionParameterProperties firstParam= new ActionParameterProperties();
            // firstParam.set("Param2", "2. Parameter for FirstAction"); 
            // actionProperties.addParameter(firstParam);
        }
    }
}