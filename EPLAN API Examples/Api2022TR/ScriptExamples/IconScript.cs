using Eplan.EplApi.Scripting;
using System;
using System.Linq;

namespace ScriptExamples
{
    public class IconScript
    {
        string m_newTabName = "Icons test tab";
        string m_commandGroupName = "Icons test command group";

        int m_ButtonsPerGroup = 10;

        [DeclareRegister]
        public void registerItems()
        {
            cleanItems();
            var newTab = new Eplan.EplApi.Gui.RibbonBar().AddTab(m_newTabName);

            var vAllEnumValues = Enum.GetValues(typeof(Eplan.EplApi.Gui.CommandIcon)).Cast<Eplan.EplApi.Gui.CommandIcon>();
            int nCounterButtons = 0;
            int nCounterButtonGroups = 0;
            Eplan.EplApi.Gui.RibbonCommandGroup commandGroup = null;

            foreach (var value in vAllEnumValues)
            {
                if ((nCounterButtons % m_ButtonsPerGroup) == 0)
                {
                    commandGroup = newTab.AddCommandGroup(m_commandGroupName + nCounterButtonGroups.ToString());
                    nCounterButtonGroups++;
                }
                commandGroup.AddCommand(value.ToString(), "XPartsManagementStart /PARAM:" + (nCounterButtons++).ToString(), value);
            }

        }

        [DeclareUnregister]
        public void unRegisterItems()
        {
            cleanItems();
        }

        void cleanItems()
        {
            var newTab = new Eplan.EplApi.Gui.RibbonBar().Tabs.FirstOrDefault(item => item.Name == m_newTabName);
            if (newTab != null)
            {
                var commandGroup = newTab.CommandGroups.FirstOrDefault(item => item.Name == m_commandGroupName);
                if (commandGroup != null)
                {
                    //var command = commandGroup.Commands.Values.FirstOrDefault(item => item.Text == m_commandName);
                    //if(command != null)
                    commandGroup.Remove();
                }
                newTab.Remove();
            }
        }
    }
}
