namespace PersonalPlanner.GUI
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
            components = new System.ComponentModel.Container();
            MainBarManager = new DevExpress.XtraBars.BarManager(components);
            TopBar = new DevExpress.XtraBars.Bar();
            NewMemo = new DevExpress.XtraBars.BarButtonItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            MdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(components);
            ((System.ComponentModel.ISupportInitialize)MainBarManager).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MdiManager).BeginInit();
            SuspendLayout();
            // 
            // MainBarManager
            // 
            MainBarManager.AllowCustomization = false;
            MainBarManager.AllowMoveBarOnToolbar = false;
            MainBarManager.AllowQuickCustomization = false;
            MainBarManager.AllowShowToolbarsPopup = false;
            MainBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] { TopBar });
            MainBarManager.DockControls.Add(barDockControlTop);
            MainBarManager.DockControls.Add(barDockControlBottom);
            MainBarManager.DockControls.Add(barDockControlLeft);
            MainBarManager.DockControls.Add(barDockControlRight);
            MainBarManager.Form = this;
            MainBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] { NewMemo });
            MainBarManager.MaxItemId = 1;
            // 
            // TopBar
            // 
            TopBar.BarName = "Tools";
            TopBar.DockCol = 0;
            TopBar.DockRow = 0;
            TopBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            TopBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(NewMemo) });
            TopBar.OptionsBar.AllowQuickCustomization = false;
            TopBar.OptionsBar.DisableClose = true;
            TopBar.OptionsBar.DisableCustomization = true;
            TopBar.OptionsBar.DrawDragBorder = false;
            TopBar.Text = "Tools";
            // 
            // NewMemo
            // 
            NewMemo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            NewMemo.Caption = "New Memo";
            NewMemo.Id = 0;
            NewMemo.Name = "NewMemo";
            NewMemo.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            NewMemo.ItemClick += NewMemo_ItemClick;
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = MainBarManager;
            barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            barDockControlTop.Size = new System.Drawing.Size(800, 22);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 600);
            barDockControlBottom.Manager = MainBarManager;
            barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            barDockControlBottom.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            barDockControlLeft.Manager = MainBarManager;
            barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            barDockControlLeft.Size = new System.Drawing.Size(0, 578);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(800, 22);
            barDockControlRight.Manager = MainBarManager;
            barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            barDockControlRight.Size = new System.Drawing.Size(0, 578);
            // 
            // MdiManager
            // 
            MdiManager.AppearancePage.Header.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            MdiManager.AppearancePage.Header.Options.UseBackColor = true;
            MdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            MdiManager.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;
            MdiManager.FloatPageDragMode = DevExpress.XtraTabbedMdi.FloatPageDragMode.Preview;
            MdiManager.MdiParent = this;
            MdiManager.ShowFloatingDropHint = DevExpress.Utils.DefaultBoolean.True;
            // 
            // MemoForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(800, 600);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            IsMdiContainer = true;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MemoForm";
            Text = "Memo Window";
            ((System.ComponentModel.ISupportInitialize)MainBarManager).EndInit();
            ((System.ComponentModel.ISupportInitialize)MdiManager).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem NewMemo;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager MdiManager;
    }
}