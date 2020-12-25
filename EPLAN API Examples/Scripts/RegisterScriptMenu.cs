public class RegisterScriptMenu
{
	[DeclareAction("MyScriptActionWithMenu")]
    public void MyFunctionAsAction()
    {
		Decider decider = new Decider();
        decider.Decide(EnumDecisionType.eOkDecision, "MyFunctionAsAction() was called!", "RegisterScriptMenu", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
		
		String strAction = "FirstAction";
		
		ActionManager oAMnr= new ActionManager();
		Eplan.EplApi.ApplicationFramework.Action oAction= oAMnr.FindAction(strAction);
		
		if (oAction != null) {
			ActionCallingContext ctx = new ActionCallingContext();
			
            String strParamValue = "Param1 Value";
            ctx.AddParameter("Param1", strParamValue);

			bool bRet=oAction.Execute(ctx);
			
			if (bRet) {
				String strReturnValue = null;
				ctx.GetParameter("ReturnParam", ref strReturnValue);
				
				decider.Decide(EnumDecisionType.eOkDecision, string.Format("The Action '{0}' ended successfully with Return Value = [{1}]", strAction, strReturnValue), "MyFunctionAsAction", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
			}
			else
				decider.Decide(EnumDecisionType.eOkDecision, "The Action '" + strAction + "' ended with errors!", "MyFunctionAsAction", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
        }
		else 
    		decider.Decide(EnumDecisionType.eOkDecision, "The Action '" + strAction + "' not found!", "MyFunctionAsAction", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);

        decider.Dispose();
		decider = null;

	    return;
    }

	[DeclareMenu]
	public void RegisterMenu()
	{
		Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
		oMenu.AddMenuItem("MyMenu Text", "MyScriptActionWithMenu");
		oMenu.AddMenuItem("FirstAction Text", "FirstAction");
	}
}
