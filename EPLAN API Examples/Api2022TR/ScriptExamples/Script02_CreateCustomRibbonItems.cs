using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;
using System.Linq;

namespace ScriptExamples
{
    public class Script02_CreateCustomRibbonItems
    {
        string _newTabName = "Custom RibbonItems";
        string _commandGroupName = "Custom CommandGroup";
        string _commandName = "Part Management Example";

        [DeclareRegister]
        public void CreateCustomRibbonItems()
        {
            ClearRibbonItems();
            var newTab = new Eplan.EplApi.Gui.RibbonBar().AddTab(_newTabName);
            var commandGroup = newTab.AddCommandGroup(_commandGroupName);
            var command = commandGroup.AddCommand(_commandName, "CustomActionForRibbonCommand");
        }

        [DeclareUnregister]
        public void ClearCustomRibbonItems()
        {
            ClearRibbonItems();
        }

        private void ClearRibbonItems()
        {
            var newTab = new Eplan.EplApi.Gui.RibbonBar().Tabs.FirstOrDefault(t => t.Name == _newTabName);

            if(newTab != null) {
                var commandGroup = newTab.CommandGroups.FirstOrDefault(g => g.Name == _commandGroupName);

                if (commandGroup != null) {
                    var command = commandGroup.Commands.Values.FirstOrDefault(c => c.Text == _commandName);

                    if (command != null)
                        command.Remove();

                    commandGroup.Remove();
                }

                newTab.Remove();
            }
        }

        [DeclareAction("CustomActionForRibbonCommand")]
        public void ActionCustomActionForRibbonCommand()
        {
            new Decider().Decide(EnumDecisionType.eOkDecision, "CustomActionForRibbonCommand was called!", "Script02_CreateCustomRibbonItems", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
            return;
        }
    }
}
