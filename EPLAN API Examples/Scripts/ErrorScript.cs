public class ErrorScript
{
    [Start]
    public void SimpleFunction()
    {
        new EDecider().Decide(EnumDecisionType.eOkDecision, "SimpleFunction was called!", "ErrorScript", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);

        return;
    }
}
