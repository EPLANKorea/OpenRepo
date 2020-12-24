public class RegisterSeparateMainMenuScript
{
	[DeclareMenu]
	public void RegisterScriptCustomMenu()
	{
		Eplan.EplApi.Gui.Menu.MainMenuName helpMenu = Eplan.EplApi.Gui.Menu.MainMenuName.eMainMenuHelp;
		Eplan.EplApi.Gui.Menu hhiMenu = new Eplan.EplApi.Gui.Menu();
		
		uint menuId = hhiMenu.AddMainMenu("[Script Menu]", helpMenu, "MyMenu Text", "MyScriptActionWithMenu", "MyMenu Text...", 1);
		menuId = hhiMenu.AddMenuItem("FirstAddin Text", "FirstAction", "FirstAddin Text...", menuId, 1,  false, false);
	}
}


