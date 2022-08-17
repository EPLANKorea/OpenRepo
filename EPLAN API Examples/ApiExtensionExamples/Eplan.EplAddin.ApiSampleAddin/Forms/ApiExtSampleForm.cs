using Eplan.EplAddin.ApiSampleAddin.Extensions;
using Eplan.EplAddin.ApiSampleAddin.Helpers;
using Eplan.EplAddin.ApiSampleAddin.Logging;
using Eplan.EplAddin.ApiSampleAddin.ViewModels;
using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.E3D;
using Eplan.EplApi.HEServices;
using Eplan.EplApi.System;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Eplan.EplApi.DataModel.DocumentTypeManager;

namespace Eplan.EplAddin.ApiSampleAddin.Forms
{
    public partial class ApiExtSampleForm : Form
    {
        private readonly ISOCode _locale = null;
        private readonly ILog _logger = null;

        public ApiExtSampleForm()
        {
            InitializeComponent();

            this._logger = LoggerFactory.GetLogger(this.GetType());
            this._locale = ApiExtHelpers.GetEplanGUILanguage();
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
                if (this._logger.IsDebugEnabled)
                    this._logger.DebugFormat("ApiExtSampleForm_Shown(), ProjectLinkFilePath=[{0}]", ProjectHelper.GetCurrentProject().ProjectLinkFilePath);

                this.txtProject.Text = ProjectHelper.GetCurrentProject().ProjectLinkFilePath;
            }
            catch (Exception ex)
            {
                if (this._logger.IsErrorEnabled)
                    this._logger.Error(string.Format("ApiExtSampleForm_Shown(), ex=[{0}]", ex.Message), ex);

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

        #region TabControl

        private void tabControlSamples_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControlSamples.SelectedTab.Name.Equals("tabPagePage", StringComparison.OrdinalIgnoreCase))
                RefreshProjectPages(this.cBoxPagePages);

            if (this.tabControlSamples.SelectedTab.Name.Equals("tabPagePage2", StringComparison.OrdinalIgnoreCase))
                RefreshProjectPages(this.cBoxPageCreatePages);

            if (this.tabControlSamples.SelectedTab.Name.Equals("tabPagePart", StringComparison.OrdinalIgnoreCase))
                RefreshProjectPages(this.cBoxPartPages);

            if (this.tabControlSamples.SelectedTab.Name.Equals("tabPageLayoutSpace", StringComparison.OrdinalIgnoreCase))
                RefreshLayoutSpaceMountingPanels(this.cBoxMountingPanels);

            if (this.tabControlSamples.SelectedTab.Name.Equals("tabPageBOM", StringComparison.OrdinalIgnoreCase))
                RefreshProjectPages(this.cBoxBOMPages);
        }

        #endregion

        #region Etc.

        private void txtProjectRestoreZw1_TextChanged(object sender, EventArgs e)
        {
            this.txtProjectOpenElk.Text = string.Empty;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Page Create & Delete

        private void btnPage2Search_Click(object sender, EventArgs e)
        {
            if (!ValidateProjectSelected(this.txtProject))
                return;

            try
            {
                using (PagePropertyList properties = new PagePropertyList())
                {
                    if (!string.IsNullOrWhiteSpace(this.txtPage2HLF.Text)) properties.DESIGNATION_PLANT = this.txtPage2HLF.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(this.txtPage2ML.Text)) properties.DESIGNATION_LOCATION = this.txtPage2ML.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(this.txtPage2PageName.Text)) properties.PAGE_NAME = this.txtPage2PageName.Text.Trim();

                    Page[] resultPages = SerachPage(ProjectHelper.GetProject(this.txtProject.Text), properties);

                    if (resultPages.Length == 0)
                        MessageDisplayHelper.Show("No Page Found", "::: Page Search");
                    else
                        foreach (var page in resultPages)
                        {
                            MessageDisplayHelper.Show(string.Format("{0} <{1}>", page.Name, page.Properties[Properties.Page.PAGE_NOMINATIOMN]), "::: Page Search");
                        }
                }
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(string.Format("Search Page Failed!{0}{1}", Environment.NewLine, ex.Message), "::: Page Search", EnumDecisionIcon.eEXCLAMATION);
            }
        }

        private void btnPage2Create_Click(object sender, EventArgs e)
        {
            #region Validation

            if (!ValidateProjectSelected(this.txtProject))
                return;

            if (!ValidateProjectSelected(this.txtPage2PageName)) {
                MessageDisplayHelper.Show("Please Input Page Name!", "::: Page Create");
                this.txtPage2PageName.Focus();
                return;
            }

            if (!ValidateProjectSelected(this.txtPage2Description)) {
                MessageDisplayHelper.Show("Please Input Page Description!", "::: Page Create");
                this.txtPage2Description.Focus();
                return;
            }

            #endregion

            try
            {
                using (Project targetProject = ProjectHelper.GetProject(this.txtProject.Text))
                using (PagePropertyList properties = new PagePropertyList())
                {
                    if (!string.IsNullOrWhiteSpace(this.txtPage2HLF.Text)) properties.DESIGNATION_PLANT = this.txtPage2HLF.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(this.txtPage2ML.Text)) properties.DESIGNATION_LOCATION = this.txtPage2ML.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(this.txtPage2PageName.Text)) properties.PAGE_COUNTER = this.txtPage2PageName.Text.Trim();

                    Page[] resultPages = SerachByFullPageName(ProjectHelper.GetProject(this.txtProject.Text), BulidSearchPageName(properties));

                    if (resultPages.Length > 0)
                        DeletePage(resultPages);

                    CreatePage(targetProject, properties, string.IsNullOrWhiteSpace(this.txtPage2Description.Text) ? string.Empty : this.txtPage2Description.Text.Trim(), DocumentType.Circuit);
                    RefreshProjectPages(this.cBoxPageCreatePages);

                    MessageDisplayHelper.Show("Page Created!", "::: Page Create");
                }
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(string.Format("Create Page Failed!{0}{1}", Environment.NewLine, ex.Message), "::: Page Create", EnumDecisionIcon.eEXCLAMATION);
            }
        }

        private void btnPage2Delete_Click(object sender, EventArgs e)
        {
            if (!ValidatePageSelected(this.cBoxPageCreatePages))
                return;

            try
            {
                Page targetPage = ((EplanPageViewModel)this.cBoxPageCreatePages.SelectedItem).Page;
                DeletePage(new[] { targetPage });

                RefreshProjectPages(this.cBoxPageCreatePages);
                MessageDisplayHelper.Show("Page Deleted!", "::: Page Delete");
            }
            catch (Exception ex)
            {
                MessageDisplayHelper.Show(string.Format("Delete Page Failed!{0}{1}", Environment.NewLine, ex.Message), "::: Page Delete", EnumDecisionIcon.eEXCLAMATION);
            }
        }

        #endregion

        #region 3D Layout Spaces

        private void cBoxMountingPanels_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBoxPlaced3DObjects.SelectedIndex = -1;
            cBoxPlaced3DObjects.Items.Clear();

            if (cBoxMountingPanels.SelectedIndex == -1)
                return;

            EplanMountingPanelViewModel selectedItem = this.cBoxMountingPanels.SelectedItem as EplanMountingPanelViewModel;

            if (selectedItem == null)
                return;

            IEnumerable<Function3D> function3DList = null;

            if (checkBox3DBarItemsOnly.Checked)
                function3DList = GetLayoutSpaceBarBaseObjects(selectedItem.MountingPanel);
            else
                function3DList = GetLayoutSpaceFunction3DObjects(selectedItem.MountingPanel);

            foreach (Function3D function3D in function3DList)
            {
                cBoxPlaced3DObjects.Items.Add(new EplanFunction3DViewModel(function3D));
            }
        }

        private void cBoxPlaced3DObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtPlacement3DFullDT.Text = string.Empty;
            this.txtPlacement3DLength.Text = string.Empty;
            this.txtPlacement3DType.Text = string.Empty;

            this.txtPlacement3DPositionX.Text = string.Empty;
            this.txtPlacement3DPositionY.Text = string.Empty;
            this.txtPlacement3DPositionZ.Text = string.Empty;

            this.txtPlacement3DSizeX.Text = string.Empty;
            this.txtPlacement3DSizeY.Text = string.Empty;
            this.txtPlacement3DSizeZ.Text = string.Empty;

            this.btnGoToGraphics.Enabled = false;

            if (cBoxPlaced3DObjects.SelectedIndex == -1)
                return;

            EplanFunction3DViewModel selectedItem = this.cBoxPlaced3DObjects.SelectedItem as EplanFunction3DViewModel;

            if (selectedItem == null)
                return;

            this.txtPlacement3DFullDT.Text = selectedItem.Function3D.Name;
            this.txtPlacement3DLength.Text = selectedItem.GetLengthText();
            this.txtPlacement3DType.Text = selectedItem.Function3D.Properties[Properties.Placement3D.FUNC_COMPONENTTYPE].ToLocaleText(this._locale);

            var boundingBox = selectedItem.GetBoundingBox();

            this.txtPlacement3DPositionX.Text = boundingBox.X.ToString("0.00");
            this.txtPlacement3DPositionY.Text = boundingBox.Y.ToString("0.00");
            this.txtPlacement3DPositionZ.Text = boundingBox.Z.ToString("0.00");

            this.txtPlacement3DSizeX.Text = boundingBox.SizeX.ToString("0.00");
            this.txtPlacement3DSizeY.Text = boundingBox.SizeY.ToString("0.00");
            this.txtPlacement3DSizeZ.Text = boundingBox.SizeZ.ToString("0.00");

            this.btnGoToGraphics.Enabled = true;
        }

        private void btnGoToGraphics_Click(object sender, EventArgs e)
        {
            if (cBoxPlaced3DObjects.SelectedIndex == -1)
                return;

            EplanFunction3DViewModel selectedItem = this.cBoxPlaced3DObjects.SelectedItem as EplanFunction3DViewModel;

            if (selectedItem == null)
                return;

            ApiExtHelpers.OpenInstallationSpaceWithPlacement3D(selectedItem.Function3D);
        }

        #endregion

        #region Part/BOM via API

        private void cBoxBOMPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBoxBOMFunctions.SelectedIndex = -1;
            cBoxBOMFunctions.Items.Clear();

            if (cBoxBOMPages.SelectedIndex == -1)
                return;

            Page targetPage = ((EplanPageViewModel)this.cBoxBOMPages.SelectedItem).Page;

            if (targetPage == null)
                return;

            foreach (Function function in targetPage.Functions.Where(f => f.CanHaveBOMPart()))
            {
                cBoxBOMFunctions.Items.Add(new EplanFunctionViewModel(function));
            }
        }

        private void cBoxBOMFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBoxBOMParts.SelectedIndex = -1;
            cBoxBOMParts.Items.Clear();

            if (cBoxBOMFunctions.SelectedIndex == -1)
                return;

            Function targetFunction = ((EplanFunctionViewModel)this.cBoxBOMFunctions.SelectedItem).Function;

            if (targetFunction == null)
                return;

            foreach (ArticleReference articleReference in targetFunction.ArticleReferences)
            {
                cBoxBOMParts.Items.Add(new EplanArticleReferenceViewModel(articleReference));
            }
        }

        private void cBoxBOMParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtBOMPartNumber.Text = string.Empty;
            this.txtBOMPartQuantity.Text = string.Empty;

            if (cBoxBOMParts.SelectedIndex == -1)
                return;

            EplanArticleReferenceViewModel articleReference = this.cBoxBOMParts.SelectedItem as EplanArticleReferenceViewModel;

            if (articleReference == null)
                return;

            this.txtBOMPartNumber.Text = articleReference.PartNumber;
            this.txtBOMPartQuantity.Text = articleReference.Quantity?.ToString() ?? string.Empty;
        }

        private void btnBOMDeletePart_Click(object sender, EventArgs e)
        {
            if (cBoxBOMParts.SelectedIndex == -1)
                return;

            EplanArticleReferenceViewModel articleReference = this.cBoxBOMParts.SelectedItem as EplanArticleReferenceViewModel;

            if (articleReference == null)
                return;

            Function targetFunction = ((EplanFunctionViewModel)this.cBoxBOMFunctions.SelectedItem).Function;

            if (targetFunction == null)
                return;

            targetFunction.RemoveArticleReference(articleReference.ArticleReference);

            int functionIndex = cBoxBOMFunctions.SelectedIndex;
            cBoxBOMFunctions.SelectedIndex = -1;
            cBoxBOMFunctions.SelectedIndex = functionIndex;

            // Refresh Part Reference List
            RefreshPartReferenceList(this.cBoxBOMFunctions);

            // Refresh Drawing
            ApiExtHelpers.RefreshDrawing();
        }

        private void btnBOMAddNewPart_Click(object sender, EventArgs e)
        {
            Function targetFunction = ((EplanFunctionViewModel)this.cBoxBOMFunctions.SelectedItem).Function;

            if (targetFunction == null)
                return;

            string selectedPartNumber = string.Empty;
            string selectedPartVariant = string.Empty;

            new EplApplication().ShowPartSelectionDialog(ref selectedPartNumber, ref selectedPartVariant);

            if (this._logger.IsDebugEnabled)
                this._logger.DebugFormat("btnBOMAddNewPart_Click(), selectedPartNumber=[{0}], selectedPartVariant=[{1}]", selectedPartNumber, selectedPartVariant);

            if (string.IsNullOrEmpty(selectedPartNumber))
                return;

            if (string.IsNullOrEmpty(selectedPartVariant))
                targetFunction.AddArticleReference(selectedPartNumber);
            else
                targetFunction.AddArticleReference(selectedPartNumber, selectedPartVariant, 1, true);

            // Refresh Part Reference List
            RefreshPartReferenceList(this.cBoxBOMFunctions);

            // Refresh Drawing
            ApiExtHelpers.RefreshDrawing();
        }

        private void btnBOMReplacePart_Click(object sender, EventArgs e)
        {
            // 01. Get Current Selected Part Reference
            if (cBoxBOMParts.SelectedIndex == -1)
                return;

            EplanArticleReferenceViewModel articleReference = this.cBoxBOMParts.SelectedItem as EplanArticleReferenceViewModel;

            if (articleReference == null)
                return;

            // 02. Get Current Function to replce against
            Function targetFunction = ((EplanFunctionViewModel)this.cBoxBOMFunctions.SelectedItem).Function;

            if (targetFunction == null)
                return;

            // 03. Get New Part
            string selectedPartNumber = string.Empty;
            string selectedPartVariant = string.Empty;

            new EplApplication().ShowPartSelectionDialog(ref selectedPartNumber, ref selectedPartVariant);

            if (this._logger.IsDebugEnabled)
                this._logger.DebugFormat("btnBOMReplacePart_Click(), selectedPartNumber=[{0}], selectedPartVariant=[{1}]", selectedPartNumber, selectedPartVariant);

            if (string.IsNullOrEmpty(selectedPartNumber))
                return;

            // 04. Info from Current Part Reference
            int articleReferenceIndex = articleReference.ArticleReference.ReferencePos;

            if (this._logger.IsDebugEnabled)
                this._logger.DebugFormat("btnBOMReplacePart_Click(), articleReference.PartNr=[{0}], articleReference.Index=[{1}]",
                                          articleReference.ArticleReference.PartNr, articleReferenceIndex);

            // 05. Replace the Part Number with New One
            articleReference.ArticleReference.PartNr = selectedPartNumber;
            articleReference.ArticleReference.StoreToObject();

            // 06. Refresh Part Reference List
            RefreshPartReferenceList(this.cBoxBOMFunctions);

            // 07. Refresh Drawing
            ApiExtHelpers.RefreshDrawing();
        }

        #endregion

        #endregion

        #region Private Methods

        #region Projects

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

        #endregion

        #region Project Page List

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

        #endregion

        #region Validation

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

        private bool ValidateTextInput(Control control)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
                return false;

            return true;
        }

        #endregion

        #region Page Related Methods

        /// <summary>
        /// 페이지를 다시 생성하기 위하여 존재하는 페이지를 삭제하는 경우, 검색하기 위한 정확한 페이지 이름 생성
        /// - To Page Creation, Serach Existing Page with its full page name
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        private string BulidSearchPageName(PagePropertyList namePartproperties)
        {
            StringBuilder nameBuilder = new StringBuilder();

            if (!namePartproperties.DESIGNATION_PLANT.IsEmpty) nameBuilder.AppendFormat("={0}", namePartproperties.DESIGNATION_PLANT);
            if (!namePartproperties.DESIGNATION_LOCATION.IsEmpty) nameBuilder.AppendFormat("+{0}", namePartproperties.DESIGNATION_LOCATION);
            if (!namePartproperties.PAGE_COUNTER.IsEmpty) nameBuilder.AppendFormat("/{0}", namePartproperties.PAGE_COUNTER);

            return nameBuilder.ToString();
        }

        private Page[] SerachPage(Project targetProject, PagePropertyList properties, bool exactNameMatching = false)
        {
            #region Parameter Validation

            if (targetProject == null)
                throw new ArgumentNullException(nameof(targetProject));

            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            #endregion

            using (DMObjectsFinder finder = new DMObjectsFinder(targetProject))
            using (PagesFilter filter = new PagesFilter())
            {
                filter.ExactNameMatching = exactNameMatching;
                filter.SetFilteredPropertyList(properties);

                return finder.GetPages(filter);
            }
        }

        private Page[] SerachByFullPageName(Project targetProject, string pageName, bool exactNameMatching = true)
        {
            #region Parameter Validation

            if (targetProject == null)
                throw new ArgumentNullException(nameof(targetProject));

            if (string.IsNullOrWhiteSpace(pageName))
                throw new ArgumentNullException(nameof(pageName));

            #endregion

            using (DMObjectsFinder finder = new DMObjectsFinder(targetProject))
            using (PagesFilter filter = new PagesFilter())
            {
                filter.ExactNameMatching = exactNameMatching;
                filter.Name = pageName;

                return finder.GetPages(filter);
            }
        }

        private Page CreatePage(Project targetProject, PagePropertyList namePartproperties, string pageDescription, DocumentType documentType = DocumentType.Circuit)
        {
            Page newPage = new Page();

            newPage.Create(targetProject, documentType, namePartproperties);
            newPage.Properties.PAGE_NOMINATIOMN = pageDescription;

            return newPage;
        }

        private void DeletePage(IEnumerable<Page> pages)
        {
            if (pages == null || pages.Count() == 0)
                return;

            foreach (var page in pages)
            {
                page.Remove();
            }
        }


        #endregion

        #region Layout Space Related Methods

        private void RefreshLayoutSpaceMountingPanels(ComboBox mountingPanelListBox)
        {
            mountingPanelListBox.SelectedIndex = -1;
            mountingPanelListBox.Items.Clear();

            if (string.IsNullOrWhiteSpace(this.txtProject.Text))
                return;

            Project project = ProjectHelper.GetProject(this.txtProject.Text);

            if (project == null)
                return;

            IEnumerable<MountingPanel> mountingPanelList = GetMountingPanelList(project);

            foreach (MountingPanel mountingPanel in mountingPanelList)
            {
                mountingPanelListBox.Items.Add(new EplanMountingPanelViewModel(mountingPanel));
            }
        }

        /// <summary>
        /// Get All Mounting Panels from Project InstallationSpaces
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        private IEnumerable<MountingPanel> GetMountingPanelList(Project project)
        {
            List<MountingPanel> toReturn = new List<MountingPanel>();

            foreach (InstallationSpace installationSpace in project.InstallationSpaces)
            {
                toReturn.AddRange(GetMountingPanels(installationSpace));
            }

            return toReturn;
        }

        /// <summary>
        /// Get All Mounting Panels from a InstallationSpace
        /// </summary>
        /// <param name="installationSpace"></param>
        /// <returns></returns>
        private IEnumerable<MountingPanel> GetMountingPanels(Placement3D parentPlacement3D)
        {
            List<MountingPanel> toReturn = new List<MountingPanel>();

            if (parentPlacement3D.Children.Length == 0)
                return toReturn;

            var mountingPanels = parentPlacement3D.Children.OfType<MountingPanel>();

            // 01. Get the MountingPanel among Children
            if (mountingPanels != null && mountingPanels.Count() > 0)
                toReturn.AddRange(mountingPanels);

            // 02. Get the MountingPanel from Children of a Child
            foreach (Placement3D placement3D in parentPlacement3D.Children)
            {
                // Skip for MountingPanel itself
                if (placement3D is MountingPanel)
                    continue;

                toReturn.AddRange(GetMountingPanels(placement3D));
            }

            return toReturn;
        }

        /// <summary>
        /// Get the Function3D list from Childern of MountingPanel
        /// - All Placement3D Items
        /// </summary>
        /// <param name="mountingPanel"></param>
        /// <returns></returns>
        private IEnumerable<Function3D> GetLayoutSpaceFunction3DObjects(Placement3D parentPlacement3D)
        {
            List<Function3D> toReturn = new List<Function3D>();

            if (parentPlacement3D.Children.Length == 0)
                return toReturn;

            var barBaseList = parentPlacement3D.Children.OfType<Function3D>();

            // Get the Function3D among Children
            if (barBaseList != null && barBaseList.Count() > 0) {
                toReturn.AddRange(barBaseList);
            }

            // Get the Function3D from Children of a Child
            foreach (Placement3D placement3D in parentPlacement3D.Children)
            {
                toReturn.AddRange(GetLayoutSpaceFunction3DObjects(placement3D));
            }

            return toReturn;
        }

        /// <summary>
        /// Get the BarBase list from Childern of MountingPanel
        /// - BusBar
        /// - Duct
        /// - MountingRail
        /// </summary>
        /// <param name="mountingPanel"></param>
        /// <returns></returns>
        private IEnumerable<BarBase> GetLayoutSpaceBarBaseObjects(Placement3D parentPlacement3D)
        {
            List<BarBase> toReturn = new List<BarBase>();

            if (parentPlacement3D.Children.Length == 0)
                return toReturn;

            var barBaseList = parentPlacement3D.Children.OfType<BarBase>();

            // Get the BarBase among Children
            if (barBaseList != null && barBaseList.Count() > 0)
            {
                toReturn.AddRange(barBaseList);
            }
            else
            {
                // Get the BarBase from Children of a Child
                foreach (Placement3D placement3D in parentPlacement3D.Children)
                {
                    toReturn.AddRange(GetLayoutSpaceBarBaseObjects(placement3D));
                }
            }

            return toReturn;
        }

        #endregion

        #region Part/BOM vai API Related Methods

        private void RefreshPartReferenceList(ComboBox functionListBox)
        {
            int functionIndex = functionListBox.SelectedIndex;
            functionListBox.SelectedIndex = -1;
            functionListBox.SelectedIndex = functionIndex;
        }

        #endregion

        #endregion
    }
}
