public class CreatePDFActionScript
{
    [DeclareAction("CreatePDFAction")]
    public void FunctionCreatePDFAction()
    {
        string sProject = string.Empty;

        ActionCallingContext oCTX1 = new ActionCallingContext();
        CommandLineInterpreter oCLI1 = new CommandLineInterpreter();
		
        oCTX1.AddParameter("TYPE", "PROJECT");
        oCLI1.Execute("selectionset", oCTX1);
        oCTX1.GetParameter("PROJECT", ref sProject);
		
        if (!string.IsNullOrEmpty(sProject)) {
            MessageBoxShow(string.Format("Project [{0}] selected!", sProject), "CreatePDFAction");
			ExecutePDFExport(sProject);
		}
		else
            MessageBoxShow("No project or several projects selected\nPlease select exactly one project!", "CreatePDFAction", EnumDecisionIcon.eEXCLAMATION);

        return;
    }
	
	private void ExecutePDFExport(string projectFullPath)
    {
        EnumDecisionReturn result = MessageBoxShow(EnumDecisionType.eYesNoDecision, string.Format("Do you want to create PDF for {0}?", projectFullPath), "PDF-Export", EnumDecisionReturn.eYES, EnumDecisionIcon.eQUESTION);

        if (result == EnumDecisionReturn.eYES) {
            Progress oProgress = new Progress("SimpleProgress");
            oProgress.SetAllowCancel(true);
            oProgress.SetAskOnCancel(true);
            oProgress.BeginPart(100, "");
            oProgress.ShowImmediately();

            CommandLineInterpreter oCLI = new CommandLineInterpreter();
            ActionCallingContext acc = new ActionCallingContext();

            acc.AddParameter("TYPE", "PDFPROJECTSCHEME");
            acc.AddParameter("PROJECTNAME", projectFullPath);
            acc.AddParameter("EXPORTFILE", string.Format("{0}\\EPLANScript\\{1}_{2}.pdf", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), PathMap.SubstitutePath("$(PROJECTNAME)"), DateTime.Now.ToString("yyMMdd.HHmmssfff")));
            acc.AddParameter("EXPORTSCHEME", "EPLAN_default_value");

            oCLI.Execute("export", acc);

            oProgress.EndPart(true);
        }

        return;
    }
	
	private EnumDecisionReturn MessageBoxShow(string message, string caption, EnumDecisionIcon icon = EnumDecisionIcon.eINFORMATION)
    {
        return MessageBoxShow(EnumDecisionType.eOkDecision, message, caption, EnumDecisionReturn.eOK, icon);
    }
		
	private EnumDecisionReturn MessageBoxShow(EnumDecisionType decision, string message, string caption, EnumDecisionReturn decisionReturn, EnumDecisionIcon icon)
    {
        using (Decider decider = new Decider())
        {
            return decider.Decide(decision, message, caption, decisionReturn, decisionReturn, "MessageDisplayHelper", false, icon);
        }
    }
}