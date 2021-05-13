using Eplan.EplApi.Base;

namespace Eplan.EplAddin.ApiSampleAddin.Extensions
{
    public static class StringExtension
    {
        public static MultiLangString GetMultiLangString(this string text)
        {
            MultiLangString mlString = new MultiLangString();

            if (string.IsNullOrWhiteSpace(text))
                mlString.SetAsString(string.Empty);
            else
                mlString.SetAsString(text);

            return mlString;
        }
    }
}
