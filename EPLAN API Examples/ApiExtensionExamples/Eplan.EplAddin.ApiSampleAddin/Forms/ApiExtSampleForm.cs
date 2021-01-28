using Eplan.EplAddin.ApiSampleAddin.Helpers;
using Eplan.EplAddin.ApiSampleAddin.ViewModels;
using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.HEServices;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Eplan.EplAddin.ApiSampleAddin.Forms
{
    public partial class ApiExtSampleForm : Form
    {
        public ApiExtSampleForm()
        {
            InitializeComponent();
        }

        #region Event Handlers

        #region Form

        private void ApiExtSampleForm_Load(object sender, EventArgs e)
        {
            this.txtProject.Text = string.Empty;
            this.txtProjectRestoreZw1.Text = string.Empty;
            this.txtProjectOpenElk.Text = string.Empty;
        }

        private void ApiExtSampleForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.txtProject.Text = ProjectHelper.GetCurrentProject().ProjectLinkFilePath;
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(ex.Message, "::: API Samples", EnumDecisionIcon.eEXCLAMATION);
            }
        }

        #endregion

        #region File Selection Buttons

        private void btnProjectSelectZw1_Click(object sender, EventArgs e)
        {
            SelecteEplanProject(this.txtProjectRestoreZw1, "::: Select ZW1", "EPLAN Data Backup (*.zw1)|*.zw1");
        }

        private void btnProjectSelectElk_Click(object sender, EventArgs e)
        {
            SelecteEplanProject(this.txtProjectOpenElk, "::: Select ELK", "EPLAN Project (*.elk)|*.elk");
        }

        #endregion

        #region Project Retore/Open Buttons

        private void btnProjectRestoreZw1_Click(object sender, EventArgs e)
        {
            if (!ValidateProjectSelected(this.txtProjectRestoreZw1))
                return;

            try
            {
                using (Restore restoreZw1 = new Restore())
                {
                    StringCollection targetZw1Path = new StringCollection();
                    targetZw1Path.Add(this.txtProjectRestoreZw1.Text);

                    string restorePath = string.Format("{0}\\EPLANApiExt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                    string restoredProjectName = string.Format("{0}_{1}", Path.GetFileNameWithoutExtension(this.txtProjectRestoreZw1.Text), DateTime.Now.ToString("yyMMdd.HHmmssfff"));

                    restoreZw1.Project(targetZw1Path, restorePath, restoredProjectName, false, false);
                    this.txtProjectOpenElk.Text = string.Format("{0}.elk", Path.Combine(restorePath, restoredProjectName));

                    MessageDisplayHelper.Show("Project Restore Completed!", "::: Restore Project");
                }
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(string.Format("Project Restore Failed!{0}{1}", Environment.NewLine, ex.Message), "::: Restore Project", EnumDecisionIcon.eEXCLAMATION);
            }
        }

        private void btnProjectOpenElk_Click(object sender, EventArgs e)
        {
            if (!ValidateProjectSelected(this.txtProjectOpenElk))
                return;

            try
            {
                using (ProjectManager projectManager = new ProjectManager())
                {
                    projectManager.OpenProject(this.txtProjectOpenElk.Text, ProjectManager.OpenMode.Standard, false);

                    if (string.IsNullOrWhiteSpace(this.txtProject.Text))
                        this.txtProject.Text = this.txtProjectOpenElk.Text;
                }

                MessageDisplayHelper.Show("Project Open Completed!", "::: Open Project");
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(string.Format("Project Open Failed!{0}{1}", Environment.NewLine, ex.Message), "::: Open Project", EnumDecisionIcon.eEXCLAMATION);
            }
        }

        #endregion

        #region PDF Create Buttons

        private void btnProjectExportPDF_Click(object sender, EventArgs e)
        {
            if (!ValidateProjectSelected(this.txtProject))
                return;

            try
            {
                using (Export pdfExport = new Export())
                {
                    string pdfFileName = string.Format("{0}_{1}.pdf", Path.GetFileNameWithoutExtension(this.txtProject.Text), DateTime.Now.ToString("yyMMdd.HHmmssfff"));
                    string pdfFullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "EPLANApiExt", pdfFileName);

                    pdfExport.PdfProject(ProjectHelper.GetProject(this.txtProject.Text), "EPLAN_default_value", pdfFullPath, Export.DegreeOfColor.Color, this.checkBoxPageInclude3D.Checked, string.Empty, true);

                    MessageDisplayHelper.Show("PDF Export Completed!", "::: Export PDF");
                }
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(string.Format("PDF Export Failed!{0}{1}", Environment.NewLine, ex.Message), "::: Export PDF", EnumDecisionIcon.eEXCLAMATION);
            }
        }

        private void btnPageExportPDF_Click(object sender, EventArgs e)
        {
            if (!ValidatePageSelected(this.cBoxPagePages))
                return;

            try
            {
                Page targetPage = ((EplanPageViewModel)this.cBoxPagePages.SelectedItem).Page;

                using (Export pdfExport = new Export())
                {
                    string pdfFileName = string.Format("{0}_{1}_{2}.pdf", Path.GetFileNameWithoutExtension(this.txtProject.Text), StringHelper.ReplaceNotAllowedFileNameCharsWith(targetPage.Name, '_'), DateTime.Now.ToString("yyMMdd.HHmmssfff"));
                    string pdfFullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "EPLANApiExt", pdfFileName);

                    pdfExport.PdfPages(new ArrayList { targetPage }, "EPLAN_default_value", pdfFullPath, Export.DegreeOfColor.Color, this.checkBoxPageInclude3D.Checked, string.Empty, true);

                    MessageDisplayHelper.Show("PDF Export Completed!", "::: Export PDF");
                }
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(string.Format("PDF Export Failed!{0}{1}", Environment.NewLine, ex.Message), "::: Export PDF", EnumDecisionIcon.eEXCLAMATION);
            }
        }

        #endregion

        #region Properties Buttons

        private void btnProjectSetProperties_Click(object sender, EventArgs e)
        {
            if (!ValidateProjectSelected(this.txtProject))
                return;

            try
            {
                Project targetProject = ProjectHelper.GetProject(this.txtProject.Text);

                targetProject.Properties[10013] = Path.GetFileNameWithoutExtension(this.txtProject.Text); // Job Number
                targetProject.Properties["EPLAN.Project.UserSupplementaryField1"] = string.Format("UserSupplementaryField1@{0}", DateTime.Now.ToString());
                targetProject.Properties[10901, 11] = string.Format("SupplementaryField[11]@{0}", DateTime.Now.ToString());

                MessageDisplayHelper.Show("Set Properties Completed!", "::: Set Project Properties");
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(string.Format("Set Properties Failed!{0}{1}", Environment.NewLine, ex.Message), "::: Set Project Properties", EnumDecisionIcon.eEXCLAMATION);
            }
        }

        private void btnProjectReadProperties_Click(object sender, EventArgs e)
        {
            if (!ValidateProjectSelected(this.txtProject))
                return;

            try
            {
                ISOCode guiLang = ApiExtHelpers.GetEplanGUILanguage();
                Project targetProject = ProjectHelper.GetProject(this.txtProject.Text);
                StringBuilder propertyText = new StringBuilder();
                propertyText.AppendFormat("Project [{1}] Properties{0}{0}", Environment.NewLine, targetProject.ProjectName);

                propertyText.AppendFormat("Job Number = [{1}]{0}", Environment.NewLine, targetProject.Properties[10013]);
                propertyText.AppendFormat("EPLAN.Project.UserSupplementaryField1 = [{1}]{0}{0}", Environment.NewLine, targetProject.Properties["EPLAN.Project.UserSupplementaryField1"]);

                propertyText.AppendFormat("SupplementaryField[11]{0}", Environment.NewLine);
                propertyText.AppendFormat(" ToString() = [{1}]{0}", Environment.NewLine, targetProject.Properties[10901, 11]);
                propertyText.AppendFormat(" ToString(Lang) = [{1}]{0}", Environment.NewLine, targetProject.Properties[10901, 11].ToString(guiLang.GetNumber()));
                propertyText.AppendFormat(" ToMultiLangString().GetStringToDisplay(Lang) = [{1}]{0}{0}", Environment.NewLine, targetProject.Properties[10901, 11].ToMultiLangString().GetStringToDisplay(guiLang.GetNumber()));

                propertyText.AppendFormat("Project Description = [{1}]{0}", Environment.NewLine, targetProject.Properties[10011]);

                MessageDisplayHelper.Show(propertyText.ToString(), "::: Read Project Properties");
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(string.Format("Read Properties Failed!{0}{1}", Environment.NewLine, ex.Message), "::: Read Project Properties", EnumDecisionIcon.eEXCLAMATION);
            }
        }

        private void btnPageSetProperties_Click(object sender, EventArgs e)
        {
            if (!ValidatePageSelected(this.cBoxPagePages))
                return;

            try
            {
                Page targetPage = ((EplanPageViewModel)this.cBoxPagePages.SelectedItem).Page;

                targetPage.Properties["EPLAN.Page.UserSupplementaryField11"] = string.Format("UserSupplementaryField11@{0}", DateTime.Now.ToString());
                targetPage.Properties[11901, 21] = string.Format("SupplementaryField[21]@{0}", DateTime.Now.ToString());

                MessageDisplayHelper.Show("Set Properties Completed!", "::: Set Page Properties");
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(string.Format("Set Properties Failed!{0}{1}", Environment.NewLine, ex.Message), "::: Set Page Properties", EnumDecisionIcon.eEXCLAMATION);
            }
        }

        private void btnPageReadProperties_Click(object sender, EventArgs e)
        {
            if (!ValidatePageSelected(this.cBoxPagePages))
                return;

            try
            {
                ISOCode guiLang = ApiExtHelpers.GetEplanGUILanguage();
                Page targetPage = ((EplanPageViewModel)this.cBoxPagePages.SelectedItem).Page;

                StringBuilder propertyText = new StringBuilder();
                propertyText.AppendFormat("Page [{1}] Properties{0}{0}", Environment.NewLine, targetPage.Name);

                propertyText.AppendFormat("PageType = [{1}]{0}", Environment.NewLine, targetPage.PageType);
                propertyText.AppendFormat("PageTypeName = [{1}]{0}{0}", Environment.NewLine, targetPage.PageTypeName);

                propertyText.AppendFormat("EPLAN.Page.UserSupplementaryField11 = [{1}]{0}{0}", Environment.NewLine, targetPage.Properties["EPLAN.Page.UserSupplementaryField11"]);

                propertyText.AppendFormat("SupplementaryField[21]{0}", Environment.NewLine);
                propertyText.AppendFormat(" ToString() = [{1}]{0}", Environment.NewLine, targetPage.Properties[11901, 21]);
                propertyText.AppendFormat(" ToString(Lang) = [{1}]{0}", Environment.NewLine, targetPage.Properties[11901, 21].ToString(guiLang.GetNumber()));
                propertyText.AppendFormat(" ToMultiLangString().GetStringToDisplay(Lang) = [{1}]{0}{0}", Environment.NewLine, targetPage.Properties[11901, 21].ToMultiLangString().GetStringToDisplay(guiLang.GetNumber()));

                propertyText.AppendFormat("Page Description{0}", Environment.NewLine);
                propertyText.AppendFormat(" ToString() = [{1}]{0}", Environment.NewLine, targetPage.Properties.PAGE_NOMINATIOMN);
                propertyText.AppendFormat(" ToString(Lang) = [{1}]{0}", Environment.NewLine, targetPage.Properties.PAGE_NOMINATIOMN.ToString(guiLang.GetNumber()));
                propertyText.AppendFormat(" ToMultiLangString().GetStringToDisplay(Lang) = [{1}]{0}", Environment.NewLine, targetPage.Properties.PAGE_NOMINATIOMN.ToMultiLangString().GetStringToDisplay(guiLang.GetNumber()));


                MessageDisplayHelper.Show(propertyText.ToString(), "::: Read Project Properties");
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(string.Format("Read Properties Failed!{0}{1}", Environment.NewLine, ex.Message), "::: Read Project Properties", EnumDecisionIcon.eEXCLAMATION);
            }

        }

        #endregion

        #region Part List Buttons

        private void btnPartShowUsageInPage_Click(object sender, EventArgs e)
        {
            if (!ValidatePageSelected(this.cBoxPartPages))
                return;

            try
            {
                ISOCode guiLang = ApiExtHelpers.GetEplanGUILanguage();
                Page targetPage = ((EplanPageViewModel)this.cBoxPartPages.SelectedItem).Page;

                foreach (var function in targetPage.Functions)
                {
                    foreach (var partReference in function.ArticleReferences)
                    {
                        Article part = partReference.Article;

                        StringBuilder propertyText = new StringBuilder();
                        propertyText.AppendFormat("partReference.PartNr [{1}]{0}{0}", Environment.NewLine, partReference.PartNr);

                        if (part != null) {
                            propertyText.AppendFormat("part.Properties.ARTICLE_DESCR1 = [{1}]{0}{0}", Environment.NewLine, part.Properties.ARTICLE_DESCR1.IsEmpty ? string.Empty : part.Properties.ARTICLE_DESCR1.ToString());
                            propertyText.AppendFormat("part.Properties.ARTICLE_DESCR2 = [{1}]{0}{0}", Environment.NewLine, part.Properties.ARTICLE_DESCR2.IsEmpty ? string.Empty : part.Properties.ARTICLE_DESCR2.ToString());
                            propertyText.AppendFormat("part.Properties.ARTICLE_DESCR3 = [{1}]{0}{0}", Environment.NewLine, part.Properties.ARTICLE_DESCR2.IsEmpty ? string.Empty : part.Properties.ARTICLE_DESCR2.ToString());

                            propertyText.AppendFormat("part.Properties.ARTICLE_NOTE = [{1}]{0}{0}", Environment.NewLine, part.Properties.ARTICLE_NOTE.IsEmpty ? string.Empty : part.Properties.ARTICLE_NOTE.ToString());
                        }

                        MessageDisplayHelper.Show(propertyText.ToString(), string.Format("[{0}] 속성", partReference.PartNr));
                    } 
                }
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(string.Format("Page Part Liist Failed!{0}{1}", Environment.NewLine, ex.Message), "::: Part Page List", EnumDecisionIcon.eEXCLAMATION);
            }
        }

        #endregion

        private void tabControlSamples_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControlSamples.SelectedTab.Name.Equals("tabPagePage", StringComparison.OrdinalIgnoreCase))
                RefreshProjectPages(this.cBoxPagePages);

            if (this.tabControlSamples.SelectedTab.Name.Equals("tabPagePart", StringComparison.OrdinalIgnoreCase))
                RefreshProjectPages(this.cBoxPartPages);
        }

        private void txtProjectRestoreZw1_TextChanged(object sender, EventArgs e)
        {
            this.txtProjectOpenElk.Text = string.Empty;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Private Methods

        private void SelecteEplanProject(TextBox projectName, string caption, string fileExtFilter = "EPLAN Project (*.elk)|*.elk")
        {
            projectName.Text = string.Empty;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = caption;
                dialog.Filter = fileExtFilter;

                if (DialogResult.OK == dialog.ShowDialog())
                    projectName.Text = dialog.FileName;
            }
        }

        private void RefreshProjectPages(ComboBox pageListBox)
        {
            pageListBox.SelectedIndex = -1;
            pageListBox.Items.Clear();

            if (string.IsNullOrWhiteSpace(this.txtProject.Text))
                return;

            Project project = ProjectHelper.GetProject(this.txtProject.Text);

            if (project == null)
                return;

            foreach (Page page in project.Pages)
            {
                pageListBox.Items.Add(new EplanPageViewModel(page));
            }
        }

        private bool ValidateProjectSelected(TextBox projectName)
        {
            if (string.IsNullOrWhiteSpace(projectName.Text)) {
                MessageDisplayHelper.Show("Please Select Project First!", "::: Select Project");
                return false;
            }

            return true;
        }

        private bool ValidatePageSelected(ComboBox cBoxPages)
        {
            if(cBoxPages.SelectedIndex == -1) {
                MessageDisplayHelper.Show("Please Select Page First!", "::: Select Page");
                return false;
            }

            return true;
        }

        #endregion
    }
}
