public class SimpleScriptWithParameters
{
    [Start]
    public bool FunctionWithParameters(string Param1, string Param2, string Param3)
    {
		new Decider().Decide(EnumDecisionType.eOkDecision, string.Format("{0}\n{1} {2}", Param1, Param2, Param3), "SimpleScriptWithParameters", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);

        return true;
    }
}
