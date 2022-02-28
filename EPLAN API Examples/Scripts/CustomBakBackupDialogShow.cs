using EplAction = Eplan.EplApi.ApplicationFramework.Action;

public class CustomBackupProjectDialogShow
{
	[DeclareAction("BakBackupDialogShow", 50)]
    public void CustomBakBackupDialogShowAction(ActionCallingContext ctx)
    {
		Decider decider = new Decider();
        decider.Decide(EnumDecisionType.eOkDecision, "CustomBakBackupDialogShowAction() was called!", "CustomBakBackupDialogShowAction", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
		
		ActionManager manager = new ActionManager();
        EplAction baseAction = manager.FindBaseActionFromFunctionAction(true);

        if (baseAction != null) {
			bool toReturn = baseAction.Execute(ctx);
			
			if (toReturn) {
				decider.Decide(EnumDecisionType.eOkDecision, "Base Action BakBackupDialogShow() finished successfully", "CustomBakBackupDialogShowAction", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
			}
			else {
				decider.Decide(EnumDecisionType.eOkDecision, "Base Action BakBackupDialogShow() finished with errors", "CustomBakBackupDialogShowAction", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
			}
		}
		else {
			decider.Decide(EnumDecisionType.eOkDecision, "The Base Action BakBackupDialogShow() not found!", "CustomBakBackupDialogShowAction", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
		}

        decider.Dispose();
		decider = null;

	    return;
    }
}
