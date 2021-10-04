using Eplan.EplApi.Scripting;

namespace ScriptExamples
{
    public class Script01_CreateCustomRibbonItems
    {
        [Start]
        public void CreateCustomRibbonItems()
        {
            string _newTabName       = "Custom RibbonItems";
            string _commandGroupName = "Custom CommandGroup";
            string _commandName      = "Part Management Example";

            var newTab = new Eplan.EplApi.Gui.RibbonBar().AddTab(_newTabName);
            var commandGroup = newTab.AddCommandGroup(_commandGroupName);
            var command = commandGroup.AddCommand(_commandName, "XPartsManagementStart /PARAM:Script01_CreateCustomRibbonItems");
        }
    }
}
