using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.E3D;
using System;
using System.Windows.Media.Media3D;

namespace Eplan.EplAddin.ApiSampleAddin.Forms
{
    public class EplanFunction3DViewModel
    {
        private readonly Function3D _function3D;

        public EplanFunction3DViewModel(Function3D function3D)
        {
            if (function3D == null)
                throw new ArgumentNullException(nameof(function3D));

            this._function3D = function3D;
        }

        public Function3D Function3D
        {
            get { return this._function3D; }
        }

        public bool IsBarBase
        {
            get { return this._function3D is BarBase; }
        }

        public string GetLengthText()
        {
            return this.IsBarBase ? ((BarBase)this._function3D).Length.ToString() : string.Empty;
        }

        public Rect3D GetBoundingBox(bool withChildren = false)
        {
            return this._function3D.GetBoundingBox(withChildren);
        }

        public override string ToString()
        {
            PropertyValue fullItemDesignation = this._function3D.Properties[Properties.Placement3D.FUNCTION3D_FULLDESIGNATION];

            return string.Format("{0} <{1}>", this._function3D.Name, fullItemDesignation.ToString());
        }
    }
}
