using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.E3D;
using System;
using System.Windows.Media.Media3D;

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

        public bool IsBarBase
        {
            get { return true; }
        }

        public string GetLengthText()
        {
            return this._barBase.Length.ToString();
        }

        public Rect3D GetBoundingBox(bool withChildren = false)
        {
            return this._barBase.GetBoundingBox(withChildren);
        }

        public override string ToString()
        {
            PropertyValue fullItemDesignation = this._barBase.Properties[Properties.Placement3D.FUNCTION3D_FULLDESIGNATION];

            return string.Format("{0} <{1}>", this._barBase.Name, fullItemDesignation.ToString());
        }
    }
}
