namespace WorkCalendar.GUI
{
    partial class MemoUI
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
            this.components = new System.ComponentModel.Container();
            this.MainBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.TopBar = new DevExpress.XtraBars.Bar();
            this.BackGroundColor = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemColorPickEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.FontDialogCall = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.Memo = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.MainBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Memo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MainBarManager
            // 
            this.MainBarManager.AllowCustomization = false;
            this.MainBarManager.AllowMoveBarOnToolbar = false;
            this.MainBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.TopBar});
            this.MainBarManager.DockControls.Add(this.barDockControlTop);
            this.MainBarManager.DockControls.Add(this.barDockControlBottom);
            this.MainBarManager.DockControls.Add(this.barDockControlLeft);
            this.MainBarManager.DockControls.Add(this.barDockControlRight);
            this.MainBarManager.Form = this;
            this.MainBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BackGroundColor,
            this.FontDialogCall});
            this.MainBarManager.MaxItemId = 3;
            this.MainBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEdit1});
            // 
            // TopBar
            // 
            this.TopBar.BarName = "Tools";
            this.TopBar.DockCol = 0;
            this.TopBar.DockRow = 0;
            this.TopBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.TopBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BackGroundColor),
            new DevExpress.XtraBars.LinkPersistInfo(this.FontDialogCall)});
            this.TopBar.OptionsBar.AllowQuickCustomization = false;
            this.TopBar.OptionsBar.DisableClose = true;
            this.TopBar.OptionsBar.DisableCustomization = true;
            this.TopBar.OptionsBar.DrawDragBorder = false;
            this.TopBar.OptionsBar.MultiLine = true;
            this.TopBar.Text = "Tools";
            // 
            // BackGroundColor
            // 
            this.BackGroundColor.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.BackGroundColor.Caption = "Memo Color";
            this.BackGroundColor.Edit = this.repositoryItemColorPickEdit1;
            this.BackGroundColor.Id = 0;
            this.BackGroundColor.Name = "BackGroundColor";
            this.BackGroundColor.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.BackGroundColor.EditValueChanged += new System.EventHandler(this.BackGroundColor_EditValueChanged);
            // 
            // repositoryItemColorPickEdit1
            // 
            this.repositoryItemColorPickEdit1.AutoHeight = false;
            this.repositoryItemColorPickEdit1.AutomaticColor = System.Drawing.Color.Black;
            this.repositoryItemColorPickEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEdit1.Name = "repositoryItemColorPickEdit1";
            // 
            // FontDialogCall
            // 
            this.FontDialogCall.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.FontDialogCall.Caption = "Font";
            this.FontDialogCall.Id = 2;
            this.FontDialogCall.Name = "FontDialogCall";
            this.FontDialogCall.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.FontDialogCall_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.MainBarManager;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlTop.Size = new System.Drawing.Size(737, 21);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 299);
            this.barDockControlBottom.Manager = this.MainBarManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlBottom.Size = new System.Drawing.Size(737, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 21);
            this.barDockControlLeft.Manager = this.MainBarManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 278);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(737, 21);
            this.barDockControlRight.Manager = this.MainBarManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 278);
            // 
            // Memo
            // 
            this.Memo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Memo.Location = new System.Drawing.Point(0, 21);
            this.Memo.MenuManager = this.MainBarManager;
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(737, 278);
            this.Memo.TabIndex = 4;
            // 
            // MemoUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(737, 299);
            this.Controls.Add(this.Memo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MemoUI";
            this.Text = "MemoUI";
            ((System.ComponentModel.ISupportInitialize)(this.MainBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Memo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager MainBarManager;
        private DevExpress.XtraBars.Bar TopBar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem BackGroundColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit1;
        private DevExpress.XtraBars.BarButtonItem FontDialogCall;
        private DevExpress.XtraEditors.MemoEdit Memo;
    }
}