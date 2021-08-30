using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.E3D;
using System;

namespace Eplan.EplAddin.ApiSampleAddin.Forms
{
    public class EplanBarBaseViewModel
    {
        private readonly BarBase _barBase;

        public EplanBarBaseViewModel(BarBase barBase)
        {
            if (barBase == null)
                throw new ArgumentNullException(nameof(barBase));

            this._barBase = barBase;
        }

        public BarBase BarBase
        {
            get { return this._barBase; }
        }

        public override string ToString()
        {
            PropertyValue fullItemDesignation = this._barBase.Properties[Properties.Placement3D.FUNCTION3D_FULLDESIGNATION];

            return string.Format("{0} <{1}>", this._barBase.Name, fullItemDesignation.ToString());
        }
    }
}
