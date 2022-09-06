using Eplan.EplApi.Gui;
using System.IO;

namespace Eplan.EplAddin.ApiSampleAddin.Internals
{
    internal class CustomMenuBuilder
    {
        /// <summary>
        /// Add Custom Menu and Toolbar to RibbonBar
        /// - For Platform 2022 and above
        /// </summary>
        /// <param name="addInDebugModeEnabled"></param>
        public static void RegisterMenuAndToolbar(bool addInDebugModeEnabled)
        {
            using (RibbonBar ribbonBar = new RibbonBar())
            using (var ribbonTab = ribbonBar.AddTab("[API Extensions]", (int)RibbonTab.DefaultRibbonTabs.Pulse - 1))
            {
                using (var ribbonCommandGroup = ribbonTab.AddCommandGroup("Actions"))
                {
                    ribbonCommandGroup.AddCommand("FirstAction Text", "FirstAction", "First Action Samples", "First Action Samples", GetSvgIcon(CommandIcon.Circle_0));
                    ribbonCommandGroup.AddCommand("Call Other Action", "ActionApiExtCallOtherAction", "Call Other Action", "Call Other Action", GetSvgIcon(CommandIcon.Circle_1));
                }

                using (var ribbonCommandGroup = ribbonTab.AddCommandGroup("API Examples"))
                {
                    ribbonCommandGroup.AddCommand("Gui Examples", "ActionApiExtWithGuiSamples", "Gui Examples...", "Gui Examples...", GetSvgIcon(CommandIcon.Rectangle_2));
                }

                using (var ribbonCommandGroup = ribbonTab.AddCommandGroup("API Popup Menu"))
                {
                    ribbonCommandGroup.AddCommand("Popup Menu Sample", "ActionApiExtPopupMenu", "Popup Menu Sample...", "Popup Menu Sample...", GetSvgIcon(CommandIcon.Diamond_8));
                    ribbonCommandGroup.AddCommand("Next Symbol Variant", "ActionNextSymbolVariant", "Next Symbol Variant...", "Next Symbol Variant...", GetSvgIcon(CommandIcon.Diamond_9));
                }
            }
        }

        /// <summary>
        /// Add Menu on MenuBar
        /// - For Platform 2.9SP1 or earlier
        /// </summary>
        /// <param name="addInDebugModeEnabled"></param>
        public static void CreateMenuAndToolbar(bool addInDebugModeEnabled)
        {
            ContextMenu contextMenu = new ContextMenu();
            ContextMenuLocation menuLocation = new ContextMenuLocation("Editor", "Ged");
            contextMenu.AddMenuItem(menuLocation, "API Ext Context Menu", "ActionApiContextMenu", true, false);
        }

        /// <summary>
        /// Remove Custom Menu and Toolbar from RibbonBar
        /// - For Platform 2022 and above
        /// </summary>
        /// <param name="addInDebugModeEnabled"></param>
        public static void UnregisterMenuAndToolbar(bool addInDebugModeEnabled)
        {
            using (RibbonBar ribbonBar = new RibbonBar())
            using (var ribbonTab = ribbonBar.GetTab("[API Extensions]"))
            {
                if (ribbonTab == null)
                    return;

                using (var ribbonCommandGroup = ribbonTab.GetCommandGroup("Actions"))
                {
                    if (ribbonCommandGroup != null)
                    {
                        RemoveRibbonCommandGroupCommand(ribbonCommandGroup);
                        ribbonCommandGroup.Remove();
                    }
                }

                using (var ribbonCommandGroup = ribbonTab.GetCommandGroup("API Examples"))
                {
                    if (ribbonCommandGroup != null)
                    {
                        RemoveRibbonCommandGroupCommand(ribbonCommandGroup);
                        ribbonCommandGroup.Remove();
                    }
                }

                using (var ribbonCommandGroup = ribbonTab.GetCommandGroup("API Popup Menu"))
                {
                    if (ribbonCommandGroup != null)
                    {
                        RemoveRibbonCommandGroupCommand(ribbonCommandGroup);
                        ribbonCommandGroup.Remove();
                    }
                }

                ribbonTab.Remove();
            }
        }

        #region Private Methods

        private static void RemoveRibbonCommandGroupCommand(RibbonCommandGroup ribbonCommandGroup)
        {
            if (ribbonCommandGroup == null)
                return;

            foreach (var ribbonCommand in ribbonCommandGroup.Commands.Values)
            {
                ribbonCommand.Remove();
            }
        }

        /// <summary>
        /// Get Ribbon Icon with Svg File Path for Ribbon Command
        /// </summary>
        /// <param name="svgFileName"></param>
        /// <param name="defaultImageFolder"></param>
        /// <returns></returns>
        private static RibbonIcon GetSvgIcon(string svgFileName, string defaultImageFolder = ".\\Images")
        {
            var shadowAssemblyPath = Path.GetDirectoryName(typeof(CustomMenuBuilder).Assembly.Location);

            return new RibbonIcon(Path.Combine(shadowAssemblyPath, defaultImageFolder, svgFileName));
        }

        /// <summary>
        /// Get Ribbon Icon with embedded icon index
        /// </summary>
        /// <param name="iconIndex"></param>
        /// <returns></returns>
        private static RibbonIcon GetSvgIcon(CommandIcon iconIndex)
        {
            return new RibbonIcon(iconIndex);
        }

        #endregion
    }
}
