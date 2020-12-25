public class RegisterSeparateMainMenuScript
{
	[DeclareMenu]
	public void RegisterScriptCustomMenu()
	{
		Eplan.EplApi.Gui.Menu.MainMenuName helpMenu = Eplan.EplApi.Gui.Menu.MainMenuName.eMainMenuHelp;
		Eplan.EplApi.Gui.Menu scriptMenu = new Eplan.EplApi.Gui.Menu();
		
		uint menuId = scriptMenu.AddMainMenu("[Script Menu]", helpMenu, "MyMenu Text", "MyScriptActionWithMenu", "MyMenu Text...", 1);
		menuId = scriptMenu.AddMenuItem("FirstAddin Text", "FirstAction", "FirstAddin Text...", menuId, 1,  false, false);
		menuId = scriptMenu.AddMenuItem("Create PDF", "CreatePDFAction", "Create PDF...", menuId, 1,  false, false);
	}
}


