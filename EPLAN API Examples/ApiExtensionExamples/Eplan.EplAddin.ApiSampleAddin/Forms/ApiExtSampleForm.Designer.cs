namespace Eplan.EplAddin.ApiSampleAddin.Forms
{
    partial class ApiExtSampleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutSample = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlSamples = new System.Windows.Forms.TabControl();
            this.tabPageProject = new System.Windows.Forms.TabPage();
            this.tableLayoutProject = new System.Windows.Forms.TableLayoutPanel();
            this.lblProjectExportPDF = new System.Windows.Forms.Label();
            this.lblProjectProperties = new System.Windows.Forms.Label();
            this.btnProjectExportPDF = new System.Windows.Forms.Button();
            this.btnProjectReadProperties = new System.Windows.Forms.Button();
            this.btnProjectSetProperties = new System.Windows.Forms.Button();
            this.btnProjectSelectElk = new System.Windows.Forms.Button();
            this.txtProjectOpenElk = new System.Windows.Forms.TextBox();
            this.lblProjectOpenElk = new System.Windows.Forms.Label();
            this.btnProjectOpenElk = new System.Windows.Forms.Button();
            this.btnProjectRestoreZw1 = new System.Windows.Forms.Button();
            this.txtProjectRestoreZw1 = new System.Windows.Forms.TextBox();
            this.lblProjectRestoreZw1 = new System.Windows.Forms.Label();
            this.btnProjectSelectZw1 = new System.Windows.Forms.Button();
            this.checkBoxProjectInclude3D = new System.Windows.Forms.CheckBox();
            this.tabPagePage = new System.Windows.Forms.TabPage();
            this.tableLayoutPage = new System.Windows.Forms.TableLayoutPanel();
            this.lblPageProperties = new System.Windows.Forms.Label();
            this.lblPageExportPDF = new System.Windows.Forms.Label();
            this.checkBoxPageInclude3D = new System.Windows.Forms.CheckBox();
            this.btnPageExportPDF = new System.Windows.Forms.Button();
            this.btnPageReadProperties = new System.Windows.Forms.Button();
            this.btnPageSetProperties = new System.Windows.Forms.Button();
            this.lblPagePages = new System.Windows.Forms.Label();
            this.cBoxPagePages = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblProject = new System.Windows.Forms.Label();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.tabPagePart = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPartPages = new System.Windows.Forms.Label();
            this.cBoxPartPages = new System.Windows.Forms.ComboBox();
            this.btnPartShowUsageInProject = new System.Windows.Forms.Button();
            this.btnPartShowUsageInPage = new System.Windows.Forms.Button();
            this.lblPartPartUsage = new System.Windows.Forms.Label();
            this.tableLayoutSample.SuspendLayout();
            this.tabControlSamples.SuspendLayout();
            this.tabPageProject.SuspendLayout();
            this.tableLayoutProject.SuspendLayout();
            this.tabPagePage.SuspendLayout();
            this.tableLayoutPage.SuspendLayout();
            this.tabPagePart.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutSample
            // 
            this.tableLayoutSample.ColumnCount = 5;
            this.tableLayoutSample.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutSample.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutSample.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSample.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutSample.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutSample.Controls.Add(this.tabControlSamples, 0, 2);
            this.tableLayoutSample.Controls.Add(this.btnOK, 3, 3);
            this.tableLayoutSample.Controls.Add(this.lblProject, 1, 1);
            this.tableLayoutSample.Controls.Add(this.txtProject, 2, 1);
            this.tableLayoutSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSample.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutSample.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutSample.Name = "tableLayoutSample";
            this.tableLayoutSample.RowCount = 4;
            this.tableLayoutSample.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutSample.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutSample.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSample.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutSample.Size = new System.Drawing.Size(873, 551);
            this.tableLayoutSample.TabIndex = 0;
            // 
            // tabControlSamples
            // 
            this.tableLayoutSample.SetColumnSpan(this.tabControlSamples, 5);
            this.tabControlSamples.Controls.Add(this.tabPageProject);
            this.tabControlSamples.Controls.Add(this.tabPagePage);
            this.tabControlSamples.Controls.Add(this.tabPagePart);
            this.tabControlSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSamples.Location = new System.Drawing.Point(3, 91);
            this.tabControlSamples.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControlSamples.Name = "tabControlSamples";
            this.tabControlSamples.SelectedIndex = 0;
            this.tabControlSamples.Size = new System.Drawing.Size(867, 394);
            this.tabControlSamples.TabIndex = 0;
            this.tabControlSamples.SelectedIndexChanged += new System.EventHandler(this.tabControlSamples_SelectedIndexChanged);
            // 
            // tabPageProject
            // 
            this.tabPageProject.Controls.Add(this.tableLayoutProject);
            this.tabPageProject.Location = new System.Drawing.Point(4, 25);
            this.tabPageProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageProject.Name = "tabPageProject";
            this.tabPageProject.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageProject.Size = new System.Drawing.Size(859, 365);
            this.tabPageProject.TabIndex = 0;
            this.tabPageProject.Text = "  Project  ";
            this.tabPageProject.UseVisualStyleBackColor = true;
            // 
            // tableLayoutProject
            // 
            this.tableLayoutProject.ColumnCount = 9;
            this.tableLayoutProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutProject.Controls.Add(this.lblProjectExportPDF, 1, 4);
            this.tableLayoutProject.Controls.Add(this.lblProjectProperties, 1, 3);
            this.tableLayoutProject.Controls.Add(this.btnProjectExportPDF, 3, 4);
            this.tableLayoutProject.Controls.Add(this.btnProjectReadProperties, 4, 3);
            this.tableLayoutProject.Controls.Add(this.btnProjectSetProperties, 2, 3);
            this.tableLayoutProject.Controls.Add(this.btnProjectSelectElk, 6, 2);
            this.tableLayoutProject.Controls.Add(this.txtProjectOpenElk, 2, 2);
            this.tableLayoutProject.Controls.Add(this.lblProjectOpenElk, 1, 2);
            this.tableLayoutProject.Controls.Add(this.btnProjectOpenElk, 7, 2);
            this.tableLayoutProject.Controls.Add(this.btnProjectRestoreZw1, 7, 1);
            this.tableLayoutProject.Controls.Add(this.txtProjectRestoreZw1, 2, 1);
            this.tableLayoutProject.Controls.Add(this.lblProjectRestoreZw1, 1, 1);
            this.tableLayoutProject.Controls.Add(this.btnProjectSelectZw1, 6, 1);
            this.tableLayoutProject.Controls.Add(this.checkBoxProjectInclude3D, 2, 4);
            this.tableLayoutProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutProject.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutProject.Name = "tableLayoutProject";
            this.tableLayoutProject.RowCount = 7;
            this.tableLayoutProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutProject.Size = new System.Drawing.Size(853, 357);
            this.tableLayoutProject.TabIndex = 0;
            // 
            // lblProjectExportPDF
            // 
            this.lblProjectExportPDF.AutoSize = true;
            this.lblProjectExportPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProjectExportPDF.Location = new System.Drawing.Point(17, 168);
            this.lblProjectExportPDF.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblProjectExportPDF.Name = "lblProjectExportPDF";
            this.lblProjectExportPDF.Size = new System.Drawing.Size(137, 38);
            this.lblProjectExportPDF.TabIndex = 17;
            this.lblProjectExportPDF.Text = "Export PDF:";
            this.lblProjectExportPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProjectProperties
            // 
            this.lblProjectProperties.AutoSize = true;
            this.lblProjectProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProjectProperties.Location = new System.Drawing.Point(17, 118);
            this.lblProjectProperties.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblProjectProperties.Name = "lblProjectProperties";
            this.lblProjectProperties.Size = new System.Drawing.Size(137, 38);
            this.lblProjectProperties.TabIndex = 16;
            this.lblProjectProperties.Text = "Project Properties:";
            this.lblProjectProperties.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnProjectExportPDF
            // 
            this.tableLayoutProject.SetColumnSpan(this.btnProjectExportPDF, 2);
            this.btnProjectExportPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProjectExportPDF.Location = new System.Drawing.Point(292, 168);
            this.btnProjectExportPDF.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnProjectExportPDF.Name = "btnProjectExportPDF";
            this.btnProjectExportPDF.Size = new System.Drawing.Size(292, 38);
            this.btnProjectExportPDF.TabIndex = 15;
            this.btnProjectExportPDF.Text = "Export PDF";
            this.btnProjectExportPDF.UseVisualStyleBackColor = true;
            this.btnProjectExportPDF.Click += new System.EventHandler(this.btnProjectExportPDF_Click);
            // 
            // btnProjectReadProperties
            // 
            this.tableLayoutProject.SetColumnSpan(this.btnProjectReadProperties, 2);
            this.btnProjectReadProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProjectReadProperties.Location = new System.Drawing.Point(444, 118);
            this.btnProjectReadProperties.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnProjectReadProperties.Name = "btnProjectReadProperties";
            this.btnProjectReadProperties.Size = new System.Drawing.Size(266, 38);
            this.btnProjectReadProperties.TabIndex = 12;
            this.btnProjectReadProperties.Text = "Read Properties";
            this.btnProjectReadProperties.UseVisualStyleBackColor = true;
            this.btnProjectReadProperties.Click += new System.EventHandler(this.btnProjectReadProperties_Click);
            // 
            // btnProjectSetProperties
            // 
            this.tableLayoutProject.SetColumnSpan(this.btnProjectSetProperties, 2);
            this.btnProjectSetProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProjectSetProperties.Location = new System.Drawing.Point(166, 118);
            this.btnProjectSetProperties.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnProjectSetProperties.Name = "btnProjectSetProperties";
            this.btnProjectSetProperties.Size = new System.Drawing.Size(266, 38);
            this.btnProjectSetProperties.TabIndex = 11;
            this.btnProjectSetProperties.Text = "Set Properties";
            this.btnProjectSetProperties.UseVisualStyleBackColor = true;
            this.btnProjectSetProperties.Click += new System.EventHandler(this.btnProjectSetProperties_Click);
            // 
            // btnProjectSelectElk
            // 
            this.btnProjectSelectElk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProjectSelectElk.Location = new System.Drawing.Point(722, 68);
            this.btnProjectSelectElk.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnProjectSelectElk.Name = "btnProjectSelectElk";
            this.btnProjectSelectElk.Size = new System.Drawing.Size(34, 38);
            this.btnProjectSelectElk.TabIndex = 10;
            this.btnProjectSelectElk.Text = "...";
            this.btnProjectSelectElk.UseVisualStyleBackColor = true;
            this.btnProjectSelectElk.Click += new System.EventHandler(this.btnProjectSelectElk_Click);
            // 
            // txtProjectOpenElk
            // 
            this.tableLayoutProject.SetColumnSpan(this.txtProjectOpenElk, 4);
            this.txtProjectOpenElk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectOpenElk.Location = new System.Drawing.Point(163, 74);
            this.txtProjectOpenElk.Margin = new System.Windows.Forms.Padding(3, 12, 3, 4);
            this.txtProjectOpenElk.Name = "txtProjectOpenElk";
            this.txtProjectOpenElk.ReadOnly = true;
            this.txtProjectOpenElk.Size = new System.Drawing.Size(550, 25);
            this.txtProjectOpenElk.TabIndex = 9;
            this.txtProjectOpenElk.Text = "ELK Project Full Path";
            // 
            // lblProjectOpenElk
            // 
            this.lblProjectOpenElk.AutoSize = true;
            this.lblProjectOpenElk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProjectOpenElk.Location = new System.Drawing.Point(17, 68);
            this.lblProjectOpenElk.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblProjectOpenElk.Name = "lblProjectOpenElk";
            this.lblProjectOpenElk.Size = new System.Drawing.Size(137, 38);
            this.lblProjectOpenElk.TabIndex = 8;
            this.lblProjectOpenElk.Text = "ELK Project:";
            this.lblProjectOpenElk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnProjectOpenElk
            // 
            this.btnProjectOpenElk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProjectOpenElk.Location = new System.Drawing.Point(768, 68);
            this.btnProjectOpenElk.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnProjectOpenElk.Name = "btnProjectOpenElk";
            this.btnProjectOpenElk.Size = new System.Drawing.Size(68, 38);
            this.btnProjectOpenElk.TabIndex = 7;
            this.btnProjectOpenElk.Text = "Open";
            this.btnProjectOpenElk.UseVisualStyleBackColor = true;
            this.btnProjectOpenElk.Click += new System.EventHandler(this.btnProjectOpenElk_Click);
            // 
            // btnProjectRestoreZw1
            // 
            this.btnProjectRestoreZw1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProjectRestoreZw1.Location = new System.Drawing.Point(768, 18);
            this.btnProjectRestoreZw1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnProjectRestoreZw1.Name = "btnProjectRestoreZw1";
            this.btnProjectRestoreZw1.Size = new System.Drawing.Size(68, 38);
            this.btnProjectRestoreZw1.TabIndex = 6;
            this.btnProjectRestoreZw1.Text = "Restore";
            this.btnProjectRestoreZw1.UseVisualStyleBackColor = true;
            this.btnProjectRestoreZw1.Click += new System.EventHandler(this.btnProjectRestoreZw1_Click);
            // 
            // txtProjectRestoreZw1
            // 
            this.tableLayoutProject.SetColumnSpan(this.txtProjectRestoreZw1, 4);
            this.txtProjectRestoreZw1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectRestoreZw1.Location = new System.Drawing.Point(163, 24);
            this.txtProjectRestoreZw1.Margin = new System.Windows.Forms.Padding(3, 12, 3, 4);
            this.txtProjectRestoreZw1.Name = "txtProjectRestoreZw1";
            this.txtProjectRestoreZw1.ReadOnly = true;
            this.txtProjectRestoreZw1.Size = new System.Drawing.Size(550, 25);
            this.txtProjectRestoreZw1.TabIndex = 4;
            this.txtProjectRestoreZw1.Text = "Zw1 Project Full Path";
            this.txtProjectRestoreZw1.TextChanged += new System.EventHandler(this.txtProjectRestoreZw1_TextChanged);
            // 
            // lblProjectRestoreZw1
            // 
            this.lblProjectRestoreZw1.AutoSize = true;
            this.lblProjectRestoreZw1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProjectRestoreZw1.Location = new System.Drawing.Point(17, 18);
            this.lblProjectRestoreZw1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblProjectRestoreZw1.Name = "lblProjectRestoreZw1";
            this.lblProjectRestoreZw1.Size = new System.Drawing.Size(137, 38);
            this.lblProjectRestoreZw1.TabIndex = 0;
            this.lblProjectRestoreZw1.Text = "Zw1 Project:";
            this.lblProjectRestoreZw1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnProjectSelectZw1
            // 
            this.btnProjectSelectZw1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProjectSelectZw1.Location = new System.Drawing.Point(722, 18);
            this.btnProjectSelectZw1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnProjectSelectZw1.Name = "btnProjectSelectZw1";
            this.btnProjectSelectZw1.Size = new System.Drawing.Size(34, 38);
            this.btnProjectSelectZw1.TabIndex = 5;
            this.btnProjectSelectZw1.Text = "...";
            this.btnProjectSelectZw1.UseVisualStyleBackColor = true;
            this.btnProjectSelectZw1.Click += new System.EventHandler(this.btnProjectSelectZw1_Click);
            // 
            // checkBoxProjectInclude3D
            // 
            this.checkBoxProjectInclude3D.AutoSize = true;
            this.checkBoxProjectInclude3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxProjectInclude3D.Location = new System.Drawing.Point(168, 171);
            this.checkBoxProjectInclude3D.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.checkBoxProjectInclude3D.Name = "checkBoxProjectInclude3D";
            this.checkBoxProjectInclude3D.Size = new System.Drawing.Size(110, 32);
            this.checkBoxProjectInclude3D.TabIndex = 18;
            this.checkBoxProjectInclude3D.Text = "Include 3D";
            this.checkBoxProjectInclude3D.UseVisualStyleBackColor = true;
            // 
            // tabPagePage
            // 
            this.tabPagePage.Controls.Add(this.tableLayoutPage);
            this.tabPagePage.Location = new System.Drawing.Point(4, 25);
            this.tabPagePage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPagePage.Name = "tabPagePage";
            this.tabPagePage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPagePage.Size = new System.Drawing.Size(859, 365);
            this.tabPagePage.TabIndex = 1;
            this.tabPagePage.Text = "  Page  ";
            this.tabPagePage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPage
            // 
            this.tableLayoutPage.ColumnCount = 9;
            this.tableLayoutPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPage.Controls.Add(this.lblPageProperties, 1, 3);
            this.tableLayoutPage.Controls.Add(this.lblPageExportPDF, 1, 4);
            this.tableLayoutPage.Controls.Add(this.checkBoxPageInclude3D, 2, 4);
            this.tableLayoutPage.Controls.Add(this.btnPageExportPDF, 3, 4);
            this.tableLayoutPage.Controls.Add(this.btnPageReadProperties, 4, 3);
            this.tableLayoutPage.Controls.Add(this.btnPageSetProperties, 2, 3);
            this.tableLayoutPage.Controls.Add(this.lblPagePages, 1, 1);
            this.tableLayoutPage.Controls.Add(this.cBoxPagePages, 2, 1);
            this.tableLayoutPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPage.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPage.Name = "tableLayoutPage";
            this.tableLayoutPage.RowCount = 7;
            this.tableLayoutPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPage.Size = new System.Drawing.Size(853, 357);
            this.tableLayoutPage.TabIndex = 1;
            // 
            // lblPageProperties
            // 
            this.lblPageProperties.AutoSize = true;
            this.lblPageProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPageProperties.Location = new System.Drawing.Point(17, 118);
            this.lblPageProperties.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblPageProperties.Name = "lblPageProperties";
            this.lblPageProperties.Size = new System.Drawing.Size(137, 38);
            this.lblPageProperties.TabIndex = 21;
            this.lblPageProperties.Text = "Page Properties:";
            this.lblPageProperties.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPageExportPDF
            // 
            this.lblPageExportPDF.AutoSize = true;
            this.lblPageExportPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPageExportPDF.Location = new System.Drawing.Point(17, 168);
            this.lblPageExportPDF.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblPageExportPDF.Name = "lblPageExportPDF";
            this.lblPageExportPDF.Size = new System.Drawing.Size(137, 38);
            this.lblPageExportPDF.TabIndex = 20;
            this.lblPageExportPDF.Text = "Export PDF:";
            this.lblPageExportPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxPageInclude3D
            // 
            this.checkBoxPageInclude3D.AutoSize = true;
            this.checkBoxPageInclude3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxPageInclude3D.Location = new System.Drawing.Point(168, 171);
            this.checkBoxPageInclude3D.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.checkBoxPageInclude3D.Name = "checkBoxPageInclude3D";
            this.checkBoxPageInclude3D.Size = new System.Drawing.Size(110, 32);
            this.checkBoxPageInclude3D.TabIndex = 19;
            this.checkBoxPageInclude3D.Text = "Include 3D";
            this.checkBoxPageInclude3D.UseVisualStyleBackColor = true;
            // 
            // btnPageExportPDF
            // 
            this.tableLayoutPage.SetColumnSpan(this.btnPageExportPDF, 2);
            this.btnPageExportPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPageExportPDF.Location = new System.Drawing.Point(292, 168);
            this.btnPageExportPDF.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPageExportPDF.Name = "btnPageExportPDF";
            this.btnPageExportPDF.Size = new System.Drawing.Size(292, 38);
            this.btnPageExportPDF.TabIndex = 14;
            this.btnPageExportPDF.Text = "Export PDF";
            this.btnPageExportPDF.UseVisualStyleBackColor = true;
            this.btnPageExportPDF.Click += new System.EventHandler(this.btnPageExportPDF_Click);
            // 
            // btnPageReadProperties
            // 
            this.tableLayoutPage.SetColumnSpan(this.btnPageReadProperties, 2);
            this.btnPageReadProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPageReadProperties.Location = new System.Drawing.Point(444, 118);
            this.btnPageReadProperties.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPageReadProperties.Name = "btnPageReadProperties";
            this.btnPageReadProperties.Size = new System.Drawing.Size(266, 38);
            this.btnPageReadProperties.TabIndex = 12;
            this.btnPageReadProperties.Text = "Read Properties";
            this.btnPageReadProperties.UseVisualStyleBackColor = true;
            this.btnPageReadProperties.Click += new System.EventHandler(this.btnPageReadProperties_Click);
            // 
            // btnPageSetProperties
            // 
            this.tableLayoutPage.SetColumnSpan(this.btnPageSetProperties, 2);
            this.btnPageSetProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPageSetProperties.Location = new System.Drawing.Point(166, 118);
            this.btnPageSetProperties.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPageSetProperties.Name = "btnPageSetProperties";
            this.btnPageSetProperties.Size = new System.Drawing.Size(266, 38);
            this.btnPageSetProperties.TabIndex = 11;
            this.btnPageSetProperties.Text = "Set Properties";
            this.btnPageSetProperties.UseVisualStyleBackColor = true;
            this.btnPageSetProperties.Click += new System.EventHandler(this.btnPageSetProperties_Click);
            // 
            // lblPagePages
            // 
            this.lblPagePages.AutoSize = true;
            this.lblPagePages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPagePages.Location = new System.Drawing.Point(17, 18);
            this.lblPagePages.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblPagePages.Name = "lblPagePages";
            this.lblPagePages.Size = new System.Drawing.Size(137, 38);
            this.lblPagePages.TabIndex = 0;
            this.lblPagePages.Text = "Project Pages:";
            this.lblPagePages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cBoxPagePages
            // 
            this.tableLayoutPage.SetColumnSpan(this.cBoxPagePages, 5);
            this.cBoxPagePages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBoxPagePages.DropDownHeight = 120;
            this.cBoxPagePages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxPagePages.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cBoxPagePages.FormattingEnabled = true;
            this.cBoxPagePages.IntegralHeight = false;
            this.cBoxPagePages.ItemHeight = 16;
            this.cBoxPagePages.Location = new System.Drawing.Point(166, 24);
            this.cBoxPagePages.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
            this.cBoxPagePages.MaxDropDownItems = 9;
            this.cBoxPagePages.Name = "cBoxPagePages";
            this.cBoxPagePages.Size = new System.Drawing.Size(590, 24);
            this.cBoxPagePages.TabIndex = 13;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Location = new System.Drawing.Point(699, 498);
            this.btnOK.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(155, 44);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProject.Location = new System.Drawing.Point(31, 34);
            this.lblProject.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(98, 44);
            this.lblProject.TabIndex = 2;
            this.lblProject.Text = "Project:";
            this.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProject
            // 
            this.tableLayoutSample.SetColumnSpan(this.txtProject, 2);
            this.txtProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProject.Location = new System.Drawing.Point(138, 44);
            this.txtProject.Margin = new System.Windows.Forms.Padding(1, 19, 1, 12);
            this.txtProject.Name = "txtProject";
            this.txtProject.ReadOnly = true;
            this.txtProject.Size = new System.Drawing.Size(723, 25);
            this.txtProject.TabIndex = 3;
            this.txtProject.Text = "EPLAN Project Full Path";
            // 
            // tabPagePart
            // 
            this.tabPagePart.Controls.Add(this.tableLayoutPanel1);
            this.tabPagePart.Location = new System.Drawing.Point(4, 25);
            this.tabPagePart.Name = "tabPagePart";
            this.tabPagePart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePart.Size = new System.Drawing.Size(859, 365);
            this.tabPagePart.TabIndex = 2;
            this.tabPagePart.Text = "Part";
            this.tabPagePart.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.Controls.Add(this.lblPartPartUsage, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnPartShowUsageInProject, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnPartShowUsageInPage, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPartPages, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cBoxPartPages, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(853, 359);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblPartPages
            // 
            this.lblPartPages.AutoSize = true;
            this.lblPartPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPartPages.Location = new System.Drawing.Point(17, 18);
            this.lblPartPages.Margin = new System.Windows.Forms.Padding(6);
            this.lblPartPages.Name = "lblPartPages";
            this.lblPartPages.Size = new System.Drawing.Size(137, 38);
            this.lblPartPages.TabIndex = 0;
            this.lblPartPages.Text = "Project Pages:";
            this.lblPartPages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cBoxPartPages
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cBoxPartPages, 5);
            this.cBoxPartPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBoxPartPages.DropDownHeight = 120;
            this.cBoxPartPages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxPartPages.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cBoxPartPages.FormattingEnabled = true;
            this.cBoxPartPages.IntegralHeight = false;
            this.cBoxPartPages.ItemHeight = 16;
            this.cBoxPartPages.Location = new System.Drawing.Point(166, 24);
            this.cBoxPartPages.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
            this.cBoxPartPages.MaxDropDownItems = 9;
            this.cBoxPartPages.Name = "cBoxPartPages";
            this.cBoxPartPages.Size = new System.Drawing.Size(590, 24);
            this.cBoxPartPages.TabIndex = 13;
            // 
            // btnPartShowUsageInProject
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnPartShowUsageInProject, 2);
            this.btnPartShowUsageInProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPartShowUsageInProject.Location = new System.Drawing.Point(444, 118);
            this.btnPartShowUsageInProject.Margin = new System.Windows.Forms.Padding(6);
            this.btnPartShowUsageInProject.Name = "btnPartShowUsageInProject";
            this.btnPartShowUsageInProject.Size = new System.Drawing.Size(266, 38);
            this.btnPartShowUsageInProject.TabIndex = 12;
            this.btnPartShowUsageInProject.Text = "Project Part List";
            this.btnPartShowUsageInProject.UseVisualStyleBackColor = true;
            // 
            // btnPartShowUsageInPage
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnPartShowUsageInPage, 2);
            this.btnPartShowUsageInPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPartShowUsageInPage.Location = new System.Drawing.Point(166, 118);
            this.btnPartShowUsageInPage.Margin = new System.Windows.Forms.Padding(6);
            this.btnPartShowUsageInPage.Name = "btnPartShowUsageInPage";
            this.btnPartShowUsageInPage.Size = new System.Drawing.Size(266, 38);
            this.btnPartShowUsageInPage.TabIndex = 11;
            this.btnPartShowUsageInPage.Text = "Page Part List";
            this.btnPartShowUsageInPage.UseVisualStyleBackColor = true;
            this.btnPartShowUsageInPage.Click += new System.EventHandler(this.btnPartShowUsageInPage_Click);
            // 
            // lblPartPartUsage
            // 
            this.lblPartPartUsage.AutoSize = true;
            this.lblPartPartUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPartPartUsage.Location = new System.Drawing.Point(17, 118);
            this.lblPartPartUsage.Margin = new System.Windows.Forms.Padding(6);
            this.lblPartPartUsage.Name = "lblPartPartUsage";
            this.lblPartPartUsage.Size = new System.Drawing.Size(137, 38);
            this.lblPartPartUsage.TabIndex = 21;
            this.lblPartPartUsage.Text = "Part In Pages:";
            this.lblPartPartUsage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ApiExtSampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 551);
            this.Controls.Add(this.tableLayoutSample);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ApiExtSampleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "::: API Extension Samples";
            this.Load += new System.EventHandler(this.ApiExtSampleForm_Load);
            this.Shown += new System.EventHandler(this.ApiExtSampleForm_Shown);
            this.tableLayoutSample.ResumeLayout(false);
            this.tableLayoutSample.PerformLayout();
            this.tabControlSamples.ResumeLayout(false);
            this.tabPageProject.ResumeLayout(false);
            this.tableLayoutProject.ResumeLayout(false);
            this.tableLayoutProject.PerformLayout();
            this.tabPagePage.ResumeLayout(false);
            this.tableLayoutPage.ResumeLayout(false);
            this.tableLayoutPage.PerformLayout();
            this.tabPagePart.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutSample;
        private System.Windows.Forms.TabControl tabControlSamples;
        private System.Windows.Forms.TabPage tabPageProject;
        private System.Windows.Forms.TabPage tabPagePage;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.TableLayoutPanel tableLayoutProject;
        private System.Windows.Forms.Button btnProjectRestoreZw1;
        private System.Windows.Forms.TextBox txtProjectRestoreZw1;
        private System.Windows.Forms.Label lblProjectRestoreZw1;
        private System.Windows.Forms.Button btnProjectSelectZw1;
        private System.Windows.Forms.Button btnProjectReadProperties;
        private System.Windows.Forms.Button btnProjectSetProperties;
        private System.Windows.Forms.Button btnProjectSelectElk;
        private System.Windows.Forms.TextBox txtProjectOpenElk;
        private System.Windows.Forms.Label lblProjectOpenElk;
        private System.Windows.Forms.Button btnProjectOpenElk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPage;
        private System.Windows.Forms.Button btnPageReadProperties;
        private System.Windows.Forms.Button btnPageSetProperties;
        private System.Windows.Forms.Label lblPagePages;
        private System.Windows.Forms.ComboBox cBoxPagePages;
        private System.Windows.Forms.Button btnProjectExportPDF;
        private System.Windows.Forms.Button btnPageExportPDF;
        private System.Windows.Forms.Label lblProjectExportPDF;
        private System.Windows.Forms.Label lblProjectProperties;
        private System.Windows.Forms.CheckBox checkBoxProjectInclude3D;
        private System.Windows.Forms.Label lblPageProperties;
        private System.Windows.Forms.Label lblPageExportPDF;
        private System.Windows.Forms.CheckBox checkBoxPageInclude3D;
        private System.Windows.Forms.TabPage tabPagePart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblPartPartUsage;
        private System.Windows.Forms.Button btnPartShowUsageInProject;
        private System.Windows.Forms.Button btnPartShowUsageInPage;
        private System.Windows.Forms.Label lblPartPages;
        private System.Windows.Forms.ComboBox cBoxPartPages;
    }
}