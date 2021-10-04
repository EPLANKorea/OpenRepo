using Eplan.EplApi.DataModel;
using System;

namespace Eplan.EplAddin.ApiSampleAddin.ViewModels
{
    public class EplanFunctionViewModel
    {
        private readonly Function _function;

        public EplanFunctionViewModel(Function function)
        {
            if (function == null)
                throw new ArgumentNullException("function");

            this._function = function;
        }

        public Function Function
        {
            get { return this._function; }
        }

        public override string ToString()
        {
            PropertyValue functionFullDT= this._function.Properties[Properties.FunctionBase.FUNC_FULLDEVICETAG];

            return string.Format("{0} <{1}>", functionFullDT.ToString(), this._function.VisibleName);
        }
    }
}
