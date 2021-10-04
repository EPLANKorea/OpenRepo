using Eplan.EplApi.DataModel;
using System;

namespace Eplan.EplAddin.ApiSampleAddin.ViewModels
{
    public class EplanArticleReferenceViewModel
    {
        private readonly ArticleReference _articleReference;

        public EplanArticleReferenceViewModel(ArticleReference articleReference)
        {
            if (articleReference == null)
                throw new ArgumentNullException(nameof(articleReference));

            this._articleReference = articleReference;
            SetPublicProperties();
        }

        public ArticleReference ArticleReference
        {
            get { return this._articleReference; }
        }

        #region Public Properties/Methods

        private string _partNumber = string.Empty;

        public string PartNumber
        {
            get { return this._partNumber ?? string.Empty; }
        }

        private int? _quantity = null;

        public int? Quantity
        {
            get { return this._quantity; }
        }

        public override string ToString()
        {
            return string.Format("{0} <{1}>", this.PartNumber, this.Quantity?.ToString() ?? "NULL");
        }

        #endregion

        #region Private Methods

        private void SetPublicProperties()
        {
            PropertyValue partNumber = this._articleReference.Properties[Properties.ArticleReference.ARTICLEREF_PARTNO];
            PropertyValue partQuantity = this._articleReference.Properties[Properties.ArticleReference.ARTICLEREF_COUNT];

            this._partNumber = partNumber.IsEmpty ? string.Empty : partNumber.ToString();
            this._quantity = partQuantity.IsEmpty ? (int?)null : partQuantity.ToInt();
        }

        #endregion
    }
}
