using Eplan.EplApi.Base;

namespace Eplan.EplAddin.ApiSampleAddin.Helpers
{
    public static class MessageDisplayHelper
    {
        public static EnumDecisionReturn Show(string message, string caption)
        {
            using (Decider decider = new Decider())
            {
                return decider.Decide(EnumDecisionType.eOkDecision, message, caption, EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
            }
        }

        public static EnumDecisionReturn Show(string message, string caption, EnumDecisionIcon icon)
        {
            return Show(EnumDecisionType.eOkDecision, message, caption, EnumDecisionReturn.eOK, icon);
        }

        public static EnumDecisionReturn Show(EnumDecisionType decision, string message, string caption, EnumDecisionReturn decisionReturn, EnumDecisionIcon icon)
        {
            using (Decider decider = new Decider())
            {
                return decider.Decide(decision, message, caption, decisionReturn, decisionReturn, "MessageDisplayHelper", false, icon);
            }
        }
    }
}
