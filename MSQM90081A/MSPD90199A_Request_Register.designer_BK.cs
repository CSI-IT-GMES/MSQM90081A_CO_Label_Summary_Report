namespace CSI.GMES.PD
{
    partial class MSPD90199A_Request_Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSPD90199A_Request_Register));
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.grpRequest = new JPlatform.Client.Controls6.GroupControlEx();
            this.grdMain = new JPlatform.Client.Controls6.GridControlEx();
            this.gvwMain = new JPlatform.Client.Controls6.BandedGridViewEx();
            this.repositoryItemMemoEditEx4 = new JPlatform.Client.Controls6.RepositoryItemMemoEditEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboBudgetCode = new JPlatform.Client.Controls6.LookUpEditEx();
            this.cboAccCode = new JPlatform.Client.Controls6.LookUpEditEx();
            this.cboPartGroup = new JPlatform.Client.Controls6.LookUpEditEx();
            this.labelEx4 = new JPlatform.Client.Controls6.LabelEx();
            this.labelEx2 = new JPlatform.Client.Controls6.LabelEx();
            this.labelEx1 = new JPlatform.Client.Controls6.LabelEx();
            this.lblAccCD = new JPlatform.Client.Controls6.LabelEx();
            this.cboPartCode = new JPlatform.Client.Controls6.LookUpEditEx();
            ((System.ComponentModel.ISupportInitialize)(this.FormMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FoemComboInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseTextEditEx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRequest)).BeginInit();
            this.grpRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditEx4)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPartGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPartCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BaseTextEditEx
            // 
            this.BaseTextEditEx.Properties.Appearance.Font = new System.Drawing.Font("DotumChe", 9F);
            this.BaseTextEditEx.Properties.Appearance.Options.UseFont = true;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(951, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 36);
            this.btnSave.TabIndex = 198;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // grpRequest
            // 
            this.grpRequest.AllowBlank = true;
            this.grpRequest.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRequest.Appearance.Options.UseFont = true;
            this.grpRequest.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.grpRequest.AppearanceCaption.Options.UseFont = true;
            this.grpRequest.Controls.Add(this.grdMain);
            this.grpRequest.Controls.Add(this.panel2);
            this.grpRequest.Controls.Add(this.panel1);
            this.grpRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRequest.Location = new System.Drawing.Point(0, 0);
            this.grpRequest.Name = "grpRequest";
            this.grpRequest.Size = new System.Drawing.Size(1072, 332);
            this.grpRequest.TabIndex = 504;
            this.grpRequest.Text = "Request Information";
            // 
            // grdMain
            // 
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.Location = new System.Drawing.Point(2, 100);
            this.grdMain.MainView = this.gvwMain;
            this.grdMain.Name = "grdMain";
            this.grdMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEditEx4});
            this.grdMain.Size = new System.Drawing.Size(1068, 188);
            this.grdMain.TabIndex = 572;
            this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwMain});
            // 
            // gvwMain
            // 
            this.gvwMain.ActionMode = JPlatform.Client.Controls6.ActionMode.View;
            this.gvwMain.Appearance.HeaderPanel.Font = new System.Drawing.Font("Calibri", 12F);
            this.gvwMain.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwMain.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvwMain.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvwMain.Appearance.Row.Font = new System.Drawing.Font("Calibri", 12F);
            this.gvwMain.Appearance.Row.Options.UseFont = true;
            this.gvwMain.GridControl = this.grdMain;
            this.gvwMain.Name = "gvwMain";
            this.gvwMain.OptionsSelection.MultiSelect = true;
            this.gvwMain.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvwMain.OptionsView.ColumnAutoWidth = false;
            this.gvwMain.OptionsView.ShowColumnHeaders = false;
            this.gvwMain.OptionsView.ShowGroupPanel = false;
            this.gvwMain.RowHeight = 30;
            this.gvwMain.SaveSPName = null;
            this.gvwMain.ViewSPName = null;
            this.gvwMain.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvwMain_RowCellStyle);
            // 
            // repositoryItemMemoEditEx4
            // 
            this.repositoryItemMemoEditEx4.Name = "repositoryItemMemoEditEx4";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(2, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1068, 42);
            this.panel2.TabIndex = 571;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(514, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 29);
            this.btnClose.TabIndex = 198;
            this.btnClose.Text = "Close";
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboBudgetCode);
            this.panel1.Controls.Add(this.cboAccCode);
            this.panel1.Controls.Add(this.cboPartGroup);
            this.panel1.Controls.Add(this.labelEx4);
            this.panel1.Controls.Add(this.labelEx2);
            this.panel1.Controls.Add(this.labelEx1);
            this.panel1.Controls.Add(this.lblAccCD);
            this.panel1.Controls.Add(this.cboPartCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 74);
            this.panel1.TabIndex = 570;
            // 
            // cboBudgetCode
            // 
            this.cboBudgetCode.ControlValue = null;
            this.cboBudgetCode.Location = new System.Drawing.Point(116, 8);
            this.cboBudgetCode.Name = "cboBudgetCode";
            this.cboBudgetCode.Properties.AddEmptyRow = false;
            this.cboBudgetCode.Properties.AllowBlank = false;
            this.cboBudgetCode.Properties.Appearance.BackColor = System.Drawing.Color.MistyRose;
            this.cboBudgetCode.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBudgetCode.Properties.Appearance.Options.UseBackColor = true;
            this.cboBudgetCode.Properties.Appearance.Options.UseFont = true;
            this.cboBudgetCode.Properties.BeforeEditValue = null;
            this.cboBudgetCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBudgetCode.Properties.NullText = "";
            this.cboBudgetCode.Size = new System.Drawing.Size(268, 25);
            this.cboBudgetCode.TabIndex = 555;
            // 
            // cboAccCode
            // 
            this.cboAccCode.ControlValue = null;
            this.cboAccCode.Location = new System.Drawing.Point(883, 19);
            this.cboAccCode.Name = "cboAccCode";
            this.cboAccCode.Properties.AddEmptyRow = false;
            this.cboAccCode.Properties.AllowBlank = false;
            this.cboAccCode.Properties.Appearance.BackColor = System.Drawing.Color.MistyRose;
            this.cboAccCode.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAccCode.Properties.Appearance.Options.UseBackColor = true;
            this.cboAccCode.Properties.Appearance.Options.UseFont = true;
            this.cboAccCode.Properties.BeforeEditValue = null;
            this.cboAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAccCode.Properties.NullText = "";
            this.cboAccCode.Size = new System.Drawing.Size(152, 25);
            this.cboAccCode.TabIndex = 555;
            this.cboAccCode.Visible = false;
            // 
            // cboPartGroup
            // 
            this.cboPartGroup.ControlValue = null;
            this.cboPartGroup.Location = new System.Drawing.Point(498, 8);
            this.cboPartGroup.Name = "cboPartGroup";
            this.cboPartGroup.Properties.AddEmptyRow = false;
            this.cboPartGroup.Properties.AllowBlank = false;
            this.cboPartGroup.Properties.Appearance.BackColor = System.Drawing.Color.MistyRose;
            this.cboPartGroup.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPartGroup.Properties.Appearance.Options.UseBackColor = true;
            this.cboPartGroup.Properties.Appearance.Options.UseFont = true;
            this.cboPartGroup.Properties.BeforeEditValue = null;
            this.cboPartGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPartGroup.Properties.NullText = "";
            this.cboPartGroup.Size = new System.Drawing.Size(268, 25);
            this.cboPartGroup.TabIndex = 555;
            this.cboPartGroup.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.cbo_Closed);
            // 
            // labelEx4
            // 
            this.labelEx4.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEx4.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelEx4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelEx4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelEx4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelEx4.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.labelEx4.Location = new System.Drawing.Point(392, 8);
            this.labelEx4.Name = "labelEx4";
            this.labelEx4.Size = new System.Drawing.Size(99, 26);
            this.labelEx4.TabIndex = 524;
            this.labelEx4.Text = "Part Group";
            // 
            // labelEx2
            // 
            this.labelEx2.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEx2.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelEx2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelEx2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelEx2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelEx2.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.labelEx2.Location = new System.Drawing.Point(15, 38);
            this.labelEx2.Name = "labelEx2";
            this.labelEx2.Size = new System.Drawing.Size(94, 26);
            this.labelEx2.TabIndex = 524;
            this.labelEx2.Text = "Part Name";
            // 
            // labelEx1
            // 
            this.labelEx1.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEx1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelEx1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelEx1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelEx1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelEx1.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.labelEx1.Location = new System.Drawing.Point(7, 8);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(104, 26);
            this.labelEx1.TabIndex = 524;
            this.labelEx1.Text = "Account Title";
            // 
            // lblAccCD
            // 
            this.lblAccCD.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccCD.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAccCD.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblAccCD.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblAccCD.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblAccCD.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.lblAccCD.Location = new System.Drawing.Point(797, 42);
            this.lblAccCD.Name = "lblAccCD";
            this.lblAccCD.Size = new System.Drawing.Size(80, 26);
            this.lblAccCD.TabIndex = 524;
            this.lblAccCD.Text = "Account Code";
            this.lblAccCD.Visible = false;
            // 
            // cboPartCode
            // 
            this.cboPartCode.ControlValue = null;
            this.cboPartCode.Location = new System.Drawing.Point(116, 39);
            this.cboPartCode.Name = "cboPartCode";
            this.cboPartCode.Properties.AddEmptyRow = false;
            this.cboPartCode.Properties.AllowBlank = false;
            this.cboPartCode.Properties.Appearance.BackColor = System.Drawing.Color.MistyRose;
            this.cboPartCode.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPartCode.Properties.Appearance.Options.UseBackColor = true;
            this.cboPartCode.Properties.Appearance.Options.UseFont = true;
            this.cboPartCode.Properties.BeforeEditValue = null;
            this.cboPartCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPartCode.Properties.NullText = "";
            this.cboPartCode.Size = new System.Drawing.Size(650, 25);
            this.cboPartCode.TabIndex = 561;
            this.cboPartCode.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.cbo_Closed);
            // 
            // MSPD90199A_Request_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1072, 332);
            this.Controls.Add(this.grpRequest);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MSPD90199A_Request_Register";
            this.Text = "Request Register";
            this.Controls.SetChildIndex(this.grpRequest, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FormMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FoemComboInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseTextEditEx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRequest)).EndInit();
            this.grpRequest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditEx4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboBudgetCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPartGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPartCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private JPlatform.Client.Controls6.GroupControlEx grpRequest;
        private JPlatform.Client.Controls6.LookUpEditEx cboPartGroup;
        private JPlatform.Client.Controls6.LookUpEditEx cboPartCode;
        private JPlatform.Client.Controls6.GridControlEx grdMain;
        private JPlatform.Client.Controls6.BandedGridViewEx gvwMain;
        private JPlatform.Client.Controls6.RepositoryItemMemoEditEx repositoryItemMemoEditEx4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private JPlatform.Client.Controls6.LookUpEditEx cboBudgetCode;
        private JPlatform.Client.Controls6.LookUpEditEx cboAccCode;
        private JPlatform.Client.Controls6.LabelEx labelEx4;
        private JPlatform.Client.Controls6.LabelEx labelEx2;
        private JPlatform.Client.Controls6.LabelEx labelEx1;
        private JPlatform.Client.Controls6.LabelEx lblAccCD;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}

