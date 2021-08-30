using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.E3D;
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

        /// <summary>
        /// 전달된 Placement가 있는 페이지를 화면에 표시한다.
        /// </summary>
        /// <param name="placement">화면에 표시할 Placement</param>
        public static void OpenPageWithPlacement(Placement placement)
        {
            if (placement == null)
                throw new ArgumentNullException(nameof(placement));

            using (Edit editor = new Edit())
            {
                editor.OpenPageWithPlacement(placement);
                editor.RedrawGed();
            }
        }

        /// <summary>
        /// 전달된 Placement가 있는 페이지를 화면에 표시한다.
        /// </summary>
        /// <param name="placement">화면에 표시할 Placement</param>
        public static void OpenInstallationSpaceWithPlacement3D(Placement3D placement3D)
        {
            if (placement3D == null)
                throw new ArgumentNullException(nameof(placement3D));

            using (Edit3D editor = new Edit3D())
            {
                editor.OpenInstallationSpaceWithPlacement3D(placement3D);
                RefreshDrawing();
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
