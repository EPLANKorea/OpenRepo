using Eplan.EplApi.Gui;
using Eplan.EplApi.Scripting;
using System.Linq;

namespace ScriptExamples
{
    public class Script04_AddCommandWithIcon
    {
        string m_newTabName = "Exercise4_AddCommandWithIcon";
        string m_commandGroupName = "Basic tasks exercise 4";
        string m_commandName = "Parts management exercise 4";

        [DeclareRegister]
        public void Register_AddCommandWithIcon()
        {

            var newTab = new Eplan.EplApi.Gui.RibbonBar().AddTab(m_newTabName);
            var commandGroup = newTab.AddCommandGroup(m_commandGroupName);
            var command1 = commandGroup.AddCommand(m_commandName, "XPartsManagementStart /PARAM:Exercise4_AddCommandWithIcon1", CommandIcon.Amplifier);
        }

        [DeclareUnregister]
        public void UnRegisterItems()
        {
            CleanItems();
        }

        void CleanItems()
        {
            var newTab = new Eplan.EplApi.Gui.RibbonBar().Tabs.FirstOrDefault(item => item.Name == m_newTabName);
            if (newTab != null)
            {
                var commandGroup = newTab.CommandGroups.FirstOrDefault(item => item.Name == m_commandGroupName);
                if (commandGroup != null)
                {
                    var command = commandGroup.Commands.Values.FirstOrDefault(item => item.Text == m_commandName);
                    if (command != null)

                        commandGroup.Remove();
                }
                newTab.Remove();
            }
        }
    }
}
