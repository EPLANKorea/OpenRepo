﻿using Eplan.EplApi.Gui;

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
            // Do Nothing
        }

        /// <summary>
        /// Add Menu on MenuBar
        /// - For Platform 2.9SP1 or earlier
        /// </summary>
        /// <param name="addInDebugModeEnabled"></param>
        public static void CreateMenuAndToolbar(bool addInDebugModeEnabled)
        {
            using (Menu apiExtMenu = new Menu())
            {
                uint menuId = apiExtMenu.AddMainMenu("[API Extensions]", Menu.MainMenuName.eMainMenuHelp,
                                                      "FirstAction Text", "FirstAction", "First Action Samples", 1);
                menuId = apiExtMenu.AddMenuItem("Call Other Action", "ActionApiExtCallOtherAction", "Call Other Action", menuId, 1, false, false);

                uint popupMenuId = apiExtMenu.AddPopupMenuItem("API Popup Menu", "Popup Menu Sample", "ActionApiExtPopupMenu", "Popup Menu Sample...", menuId, 1, false, false);
                popupMenuId = apiExtMenu.AddMenuItem("Next Symbol Variant", "ActionNextSymbolVariant", "Next Symbol Variant...", popupMenuId, 1, false, false);

                menuId = apiExtMenu.AddMenuItem("Gui Examples", "ActionApiExtWithGuiSamples", "Gui Examples...", menuId, 1, false, false);
            }

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
            // Do Nothing
        }
    }
}
