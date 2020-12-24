public class VerySimpleScript
{
    [Start]
    public void SimpleFunction()
    {
        new Decider().Decide(EnumDecisionType.eOkDecision, "SimpleFunction was called!", "VerySimpleScript", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);

        return;
    }
}
