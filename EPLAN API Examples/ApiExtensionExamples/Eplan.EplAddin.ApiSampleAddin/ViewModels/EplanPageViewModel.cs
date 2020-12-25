using Eplan.EplApi.DataModel;
using System;

namespace Eplan.EplAddin.ApiSampleAddin.ViewModels
{
    public class EplanPageViewModel
    {
        private readonly Page _page;

        public EplanPageViewModel(Page page)
        {
            if (page == null)
                throw new ArgumentNullException("page");

            this._page = page;
        }

        public Page Page
        {
            get { return this._page; }
        }

        public override string ToString()
        {
            PropertyValue pageDescription = this._page.Properties[Properties.Page.PAGE_NOMINATIOMN];

            return string.Format("{0} <{1}>", this._page.Name, pageDescription.IsEmpty ? "..." : pageDescription.ToString());
        }
    }
}
