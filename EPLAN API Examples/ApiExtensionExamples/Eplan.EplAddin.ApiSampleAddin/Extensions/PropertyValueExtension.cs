using Eplan.EplAddin.ApiSampleAddin.Helpers;
using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;
using static Eplan.EplApi.Base.ISOCode;

namespace Eplan.EplAddin.ApiSampleAddin.Extensions
{
    public static class PropertyValueExtension
    {
        #region Public Methods

        public static string ToLocaleText(this PropertyValue propertyValue, ISOCode locale = null)
        {
            if (propertyValue == null || propertyValue.IsEmpty)
                return string.Empty;

            switch (propertyValue.Definition.Type)
            {
                case PropertyDefinition.PropertyType.MultilangString:
                    return GetMultilangStringText(propertyValue, locale);

                default:
                    return propertyValue.ToString();
            }
        }

        #endregion

        #region Private Methods

        private static string GetMultilangStringText(PropertyValue propertyValue, ISOCode locale)
        {
            ISOCode workingLocale = null;
            string toReturn = string.Empty;

            if (propertyValue == null || propertyValue.IsEmpty)
                return toReturn;

            try
            {
                workingLocale = locale ?? ApiExtHelpers.GetEplanGUILanguage();

                toReturn = propertyValue.ToString(workingLocale.GetNumber());

                // 현재 Locale로 값이 없는 경우, 기본 값(@??_??)으로 구한다
                if (string.IsNullOrWhiteSpace(toReturn))
                    toReturn = propertyValue.ToString(Language.L___);
            }
            finally
            {
                // 내부에서 생성한 ISOCode Instance Dispose
                if (locale == null && workingLocale != null)
                    workingLocale.Dispose();
            }

            return toReturn;
        }

        #endregion

    }
}
