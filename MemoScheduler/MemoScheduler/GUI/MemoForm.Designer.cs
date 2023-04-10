namespace MemoScheduler.GUI
{
    partial class MemoForm
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
            this.NewMemo = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.MdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // MainBarManager
            // 
            this.MainBarManager.AllowCustomization = false;
            this.MainBarManager.AllowMoveBarOnToolbar = false;
            this.MainBarManager.AllowQuickCustomization = false;
            this.MainBarManager.AllowShowToolbarsPopup = false;
            this.MainBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.TopBar});
            this.MainBarManager.DockControls.Add(this.barDockControlTop);
            this.MainBarManager.DockControls.Add(this.barDockControlBottom);
            this.MainBarManager.DockControls.Add(this.barDockControlLeft);
            this.MainBarManager.DockControls.Add(this.barDockControlRight);
            this.MainBarManager.Form = this;
            this.MainBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.NewMemo});
            this.MainBarManager.MaxItemId = 1;
            // 
            // TopBar
            // 
            this.TopBar.BarName = "Tools";
            this.TopBar.DockCol = 0;
            this.TopBar.DockRow = 0;
            this.TopBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.TopBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.NewMemo)});
            this.TopBar.OptionsBar.AllowQuickCustomization = false;
            this.TopBar.OptionsBar.DisableClose = true;
            this.TopBar.OptionsBar.DisableCustomization = true;
            this.TopBar.OptionsBar.DrawDragBorder = false;
            this.TopBar.Text = "Tools";
            // 
            // NewMemo
            // 
            this.NewMemo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.NewMemo.Caption = "New Memo";
            this.NewMemo.Id = 0;
            this.NewMemo.Name = "NewMemo";
            this.NewMemo.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.NewMemo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NewMemo_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.MainBarManager;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlTop.Size = new System.Drawing.Size(800, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 600);
            this.barDockControlBottom.Manager = this.MainBarManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Manager = this.MainBarManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 578);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 22);
            this.barDockControlRight.Manager = this.MainBarManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 578);
            // 
            // MdiManager
            // 
            this.MdiManager.AppearancePage.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.MdiManager.AppearancePage.Header.Options.UseBackColor = true;
            this.MdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            this.MdiManager.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;
            this.MdiManager.FloatPageDragMode = DevExpress.XtraTabbedMdi.FloatPageDragMode.Preview;
            this.MdiManager.MdiParent = this;
            this.MdiManager.ShowFloatingDropHint = DevExpress.Utils.DefaultBoolean.True;
            // 
            // MemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MemoForm";
            this.Text = "MemoForm";
            ((System.ComponentModel.ISupportInitialize)(this.MainBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MdiManager)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem NewMemo;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager MdiManager;
    }
}