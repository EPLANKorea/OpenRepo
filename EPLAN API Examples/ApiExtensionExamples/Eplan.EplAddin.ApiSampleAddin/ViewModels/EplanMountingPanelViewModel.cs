using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.E3D;
using System;

namespace Eplan.EplAddin.ApiSampleAddin.Forms
{
    public class EplanMountingPanelViewModel
    {
        private readonly MountingPanel _mountingPanel;

        public EplanMountingPanelViewModel(MountingPanel mountingPanel)
        {
            if (mountingPanel == null)
                throw new ArgumentNullException(nameof(mountingPanel));

            this._mountingPanel = mountingPanel;
        }

        public MountingPanel MountingPanel
        {
            get { return this._mountingPanel; }
        }

        public override string ToString()
        {
            PropertyValue fullItemDesignation = this._mountingPanel.Properties[Properties.Placement3D.FUNCTION3D_FULLDESIGNATION];

            return string.Format("{0} <{1}>", this._mountingPanel.Name, fullItemDesignation.ToString());
        }
    }
}
