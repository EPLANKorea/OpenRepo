using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Gui;

namespace Eplan.EplAddin.ApiSampleAddin
{
    /// <summary>
    ///   That is an example for a EPLAN addin.  
    ///   Exactly a class must implement the interface Eplan.EplApi.ApplicationFramework.IEplAddIn.  
    ///   An Assembly is identified through this criterion as EPLAN addin!  
    /// </summary>  

    public class SampleAddInModule : IEplAddIn
    {
        public bool OnInit()
        {
            return true;
        }

        public bool OnInitGui()
        {
            Menu apiExtMenu = new Menu();

            uint menuId = apiExtMenu.AddMainMenu("[API Extensions]", Menu.MainMenuName.eMainMenuHelp,
                                                  "FirstAction Text", "FirstAction", "First Action Samples", 1);
            menuId = apiExtMenu.AddMenuItem("Call Other Action", "ActionApiExtCallOtherAction", "Call Other Action", menuId, 1, false, false);

            uint popupMenuId = apiExtMenu.AddPopupMenuItem("API Popup Menu", "Popup Menu Sample", "ActionApiExtPopupMenu", "Popup Menu Sample...", menuId, 1, false, false);
            popupMenuId = apiExtMenu.AddMenuItem("Next Symbol Variant", "ActionNextSymbolVariant", "Next Symbol Variant...", popupMenuId, 1, false, false);

            menuId = apiExtMenu.AddMenuItem("Gui Examples", "ActionApiExtWithGuiSamples", "Gui Examples...", menuId, 1, false, false);

            ContextMenu contextMenu = new ContextMenu();
            ContextMenuLocation menuLocation = new ContextMenuLocation("Editor", "Ged");
            contextMenu.AddMenuItem(menuLocation, "API Ext Context Menu", "ActionApiContextMenu", true, false);

            return true;
        }

        public bool OnExit()
        {
            return true;
        }

        public bool OnRegister(ref bool bLoadOnStart)
        {
            bLoadOnStart = true;

            return true;
        }

        public bool OnUnregister()
        {
            return true;
        }
    }
}
