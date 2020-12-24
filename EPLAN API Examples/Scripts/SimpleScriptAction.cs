public class SimpleScriptAction
{
     [DeclareAction("MyScriptAction")]
     public void MyFunctionAsAction()
     {
		   new Decider().Decide(EnumDecisionType.eOkDecision, "MyFunctionAsAction was called!", "SimpleScriptAction", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);

           return;
     }
}