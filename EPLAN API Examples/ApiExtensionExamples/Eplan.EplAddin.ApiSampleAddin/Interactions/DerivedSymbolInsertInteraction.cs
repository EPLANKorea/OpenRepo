using Eplan.EplAddin.ApiSampleAddin.Extensions;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.EServices.Ged;
using System.Linq;

namespace Eplan.EplAddin.ApiSampleAddin.Interactions
{
    [Interaction(Name = "XEGedIaInsertSymRef", NameOfBaseInteraction = "XEGedIaInsertSymRef", Ordinal = 50, Prio = 20)]
    public class DerivedSymbolInsertInteraction : InsertInteraction
    {
        Function _mainFunction = null;

        /*
        public override RequestCode OnStart(InteractionContext pContext)
        {
            //MessageBox.Show(string.Format("OnStart(), oContext=[{0}], IsInsertInteraction=[{1}], IsSelectionInteraction=[{2}]",
            //                               pContext == null ? "NULL" : pContext.GetParameterCount().ToString(), this.IsInsertInteraction, this.IsSelectionInteraction),
            //                "DerivedSymbolInsertInteraction");

            return base.OnStart(pContext);
        }

        public override void OnStop()
        {
            base.OnStop();

            //MessageBox.Show(string.Format("OnStop(), InsertedPlacements=[{0}]", this.InsertedPlacements == null ? "NULL" : this.InsertedPlacements.Length.ToString()), "DerivedSymbolInsertInteraction");
        }
        */

        public override void OnSuccess(InteractionContext result)
        {
            base.OnSuccess(result);

            //MessageBox.Show(string.Format("OnSuccess(), result=[{0}]", result == null ? "NULL" : result.GetParameterCount().ToString()), "DerivedSymbolInsertInteraction");

            // set property of inserted function
            StorableObject[] placements = InsertedItems;

            foreach (var function in placements.OfType<Function>())
            {
                if (function.IsMainFunction)
                {
                    this._mainFunction = function;
                    function.Properties[Properties.Function.FUNC_TEXT] = "API_Demos : DerivedSymbolInsertInteraction";

                    FunctionImageExtension.DoImage(function);
                }
                else
                {
                    if (this._mainFunction != null)
                        function.VisibleName = this._mainFunction.VisibleName;
                }
            }
        }

        #region Private Methods

        #endregion
    }
}
