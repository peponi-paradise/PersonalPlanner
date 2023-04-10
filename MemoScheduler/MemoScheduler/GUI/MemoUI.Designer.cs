namespace MemoScheduler.GUI
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
            components = new System.ComponentModel.Container();
            MainBarManager = new DevExpress.XtraBars.BarManager(components);
            TopBar = new DevExpress.XtraBars.Bar();
            BackGroundColor = new DevExpress.XtraBars.BarEditItem();
            repositoryItemColorPickEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            FontDialogCall = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            Memo = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)MainBarManager).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemColorPickEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Memo.Properties).BeginInit();
            SuspendLayout();
            // 
            // MainBarManager
            // 
            MainBarManager.AllowCustomization = false;
            MainBarManager.AllowMoveBarOnToolbar = false;
            MainBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] { TopBar });
            MainBarManager.DockControls.Add(barDockControlTop);
            MainBarManager.DockControls.Add(barDockControlBottom);
            MainBarManager.DockControls.Add(barDockControlLeft);
            MainBarManager.DockControls.Add(barDockControlRight);
            MainBarManager.Form = this;
            MainBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] { BackGroundColor, FontDialogCall });
            MainBarManager.MaxItemId = 3;
            MainBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemColorPickEdit1 });
            // 
            // TopBar
            // 
            TopBar.BarName = "Tools";
            TopBar.DockCol = 0;
            TopBar.DockRow = 0;
            TopBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            TopBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(BackGroundColor), new DevExpress.XtraBars.LinkPersistInfo(FontDialogCall) });
            TopBar.OptionsBar.AllowQuickCustomization = false;
            TopBar.OptionsBar.DisableClose = true;
            TopBar.OptionsBar.DisableCustomization = true;
            TopBar.OptionsBar.DrawDragBorder = false;
            TopBar.OptionsBar.MultiLine = true;
            TopBar.Text = "Tools";
            // 
            // BackGroundColor
            // 
            BackGroundColor.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            BackGroundColor.Caption = "Memo Color";
            BackGroundColor.Edit = repositoryItemColorPickEdit1;
            BackGroundColor.Id = 0;
            BackGroundColor.Name = "BackGroundColor";
            BackGroundColor.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            BackGroundColor.EditValueChanged += BackGroundColor_EditValueChanged;
            // 
            // repositoryItemColorPickEdit1
            // 
            repositoryItemColorPickEdit1.AutoHeight = false;
            repositoryItemColorPickEdit1.AutomaticColor = System.Drawing.Color.Black;
            repositoryItemColorPickEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemColorPickEdit1.Name = "repositoryItemColorPickEdit1";
            // 
            // FontDialogCall
            // 
            FontDialogCall.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            FontDialogCall.Caption = "Font";
            FontDialogCall.Id = 2;
            FontDialogCall.Name = "FontDialogCall";
            FontDialogCall.ItemClick += FontDialogCall_ItemClick;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = MainBarManager;
            barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            barDockControlTop.Size = new System.Drawing.Size(737, 21);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 299);
            barDockControlBottom.Manager = MainBarManager;
            barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            barDockControlBottom.Size = new System.Drawing.Size(737, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 21);
            barDockControlLeft.Manager = MainBarManager;
            barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            barDockControlLeft.Size = new System.Drawing.Size(0, 278);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(737, 21);
            barDockControlRight.Manager = MainBarManager;
            barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            barDockControlRight.Size = new System.Drawing.Size(0, 278);
            // 
            // Memo
            // 
            Memo.Dock = System.Windows.Forms.DockStyle.Fill;
            Memo.Location = new System.Drawing.Point(0, 21);
            Memo.MenuManager = MainBarManager;
            Memo.Name = "Memo";
            Memo.Properties.AcceptsTab = true;
            Memo.Size = new System.Drawing.Size(737, 278);
            Memo.TabIndex = 14;
            // 
            // MemoUI
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(737, 299);
            Controls.Add(Memo);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MemoUI";
            Text = "MemoUI";
            ((System.ComponentModel.ISupportInitialize)MainBarManager).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemColorPickEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Memo.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
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