using EplAction = Eplan.EplApi.ApplicationFramework.Action;

public class CustomBackupProjectDialogShow
{
	[DeclareAction("BackupProjectDialogShow", 50)]
    public void CustomBackupProjectDialogShowAction(ActionCallingContext ctx)
    {
		Decider decider = new Decider();
        decider.Decide(EnumDecisionType.eOkDecision, "CustomBackupProjectDialogShowAction() was called!", "CustomBackupProjectDialogShowAction", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
		
		ActionManager manager = new ActionManager();
        EplAction baseAction = manager.FindBaseActionFromFunctionAction(true);

        if (baseAction != null) {
			bool toReturn = baseAction.Execute(ctx);
			
			if (toReturn) {
				decider.Decide(EnumDecisionType.eOkDecision, "Base Action BackupProjectDialogShow() finished successfully", "CustomBackupProjectDialogShowAction", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
			}
			else {
				decider.Decide(EnumDecisionType.eOkDecision, "Base Action BackupProjectDialogShow() finished with errors", "CustomBackupProjectDialogShowAction", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
			}
		}
		else {
			decider.Decide(EnumDecisionType.eOkDecision, "The Base Action BackupProjectDialogShow() not found!", "CustomBackupProjectDialogShowAction", EnumDecisionReturn.eOK, EnumDecisionReturn.eOK);
		}

        decider.Dispose();
		decider = null;

	    return;
    }
}
