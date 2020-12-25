using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Eplan.EplAddin.ApiSampleAddin.Helpers
{
    public static class StringHelper
    {
        private static string NotAllowedChars = new String(Path.GetInvalidFileNameChars());

        public static string ReplaceNotAllowedFileNameCharsWith(string text, char replacement)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            string replacedText = text;
            foreach (char invalidChar in Path.GetInvalidFileNameChars())
            {
                replacedText = replacedText.Replace(invalidChar, replacement);
            }

            return replacedText;
        }

        public static string ReplaceNotAllowedFileNameCharsWith(string text, string replacement)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            return Regex.Replace(text, string.Format("[{0}]", NotAllowedChars), replacement);
        }
    }
}
