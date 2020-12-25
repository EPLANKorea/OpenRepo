using Eplan.EplApi.Base;
using Eplan.EplApi.HEServices;
using System;

namespace Eplan.EplAddin.ApiSampleAddin.Helpers
{
    public static class ApiExtHelpers
    {
        public static void RefreshDrawing()
        {
            try
            {
                using (Edit editor = new Edit())
                {
                    editor.RedrawGed();
                }
            }
            catch (Exception)
            {
            }
        }

        public static ISOCode GetEplanGUILanguage()
        {
            using (Languages language = new Languages())
            {
                return language.GuiLanguage;
            }
        }
    }
}
