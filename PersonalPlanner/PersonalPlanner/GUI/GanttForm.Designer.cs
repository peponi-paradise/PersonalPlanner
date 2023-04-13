namespace PersonalPlanner.GUI
{
    partial class GanttForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GanttForm));
            MainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            NewGantt = new DevExpress.XtraBars.BarButtonItem();
            TabColor = new DevExpress.XtraBars.BarEditItem();
            repositoryItemColorPickEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            NewTask = new DevExpress.XtraBars.BarButtonItem();
            RemoveTask = new DevExpress.XtraBars.BarButtonItem();
            RemoveGantt = new DevExpress.XtraBars.BarButtonItem();
            ZoomIn = new DevExpress.XtraBars.BarButtonItem();
            ZoomOut = new DevExpress.XtraBars.BarButtonItem();
            ZoomReset = new DevExpress.XtraBars.BarButtonItem();
            MainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            RibbonPageGroupNewGantt = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            RibbonPageGroupCurrentTab = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            RibbonGroupView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            MainControl = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)MainRibbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemColorPickEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainControl).BeginInit();
            SuspendLayout();
            // 
            // MainRibbonControl
            // 
            MainRibbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 32, 35, 32);
            MainRibbonControl.ExpandCollapseItem.Id = 0;
            MainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { MainRibbonControl.ExpandCollapseItem, MainRibbonControl.SearchEditItem, NewGantt, TabColor, NewTask, RemoveTask, RemoveGantt, ZoomIn, ZoomOut, ZoomReset });
            MainRibbonControl.Location = new System.Drawing.Point(0, 0);
            MainRibbonControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MainRibbonControl.MaxItemId = 20;
            MainRibbonControl.Name = "MainRibbonControl";
            MainRibbonControl.OptionsMenuMinWidth = 385;
            MainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { MainRibbonPage });
            MainRibbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemColorPickEdit1 });
            MainRibbonControl.Size = new System.Drawing.Size(1022, 160);
            // 
            // NewGantt
            // 
            NewGantt.Caption = "New Chart";
            NewGantt.Id = 12;
            NewGantt.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("NewGantt.ImageOptions.SvgImage");
            NewGantt.Name = "NewGantt";
            NewGantt.ItemClick += NewGantt_ItemClick;
            // 
            // TabColor
            // 
            TabColor.Caption = "Tab Color";
            TabColor.Edit = repositoryItemColorPickEdit1;
            TabColor.Id = 13;
            TabColor.Name = "TabColor";
            TabColor.EditValueChanged += TabColor_EditValueChanged;
            // 
            // repositoryItemColorPickEdit1
            // 
            repositoryItemColorPickEdit1.AutoHeight = false;
            repositoryItemColorPickEdit1.AutomaticColor = System.Drawing.Color.Black;
            repositoryItemColorPickEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemColorPickEdit1.Name = "repositoryItemColorPickEdit1";
            // 
            // NewTask
            // 
            NewTask.Caption = "New Task";
            NewTask.Id = 14;
            NewTask.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("NewTask.ImageOptions.SvgImage");
            NewTask.Name = "NewTask";
            NewTask.ItemClick += NewTask_ItemClick;
            // 
            // RemoveTask
            // 
            RemoveTask.Caption = "Remove Task";
            RemoveTask.Id = 15;
            RemoveTask.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("RemoveTask.ImageOptions.SvgImage");
            RemoveTask.Name = "RemoveTask";
            RemoveTask.ItemClick += RemoveTask_ItemClick;
            // 
            // RemoveGantt
            // 
            RemoveGantt.Caption = "Remove Chart";
            RemoveGantt.Id = 16;
            RemoveGantt.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("RemoveGantt.ImageOptions.SvgImage");
            RemoveGantt.Name = "RemoveGantt";
            RemoveGantt.ItemClick += RemoveGantt_ItemClick;
            // 
            // ZoomIn
            // 
            ZoomIn.Caption = "Zoom In";
            ZoomIn.Id = 17;
            ZoomIn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ZoomIn.ImageOptions.SvgImage");
            ZoomIn.Name = "ZoomIn";
            ZoomIn.ItemClick += ZoomIn_ItemClick;
            // 
            // ZoomOut
            // 
            ZoomOut.Caption = "Zoom Out";
            ZoomOut.Id = 18;
            ZoomOut.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ZoomOut.ImageOptions.SvgImage");
            ZoomOut.Name = "ZoomOut";
            ZoomOut.ItemClick += ZoomOut_ItemClick;
            // 
            // ZoomReset
            // 
            ZoomReset.Caption = "Reset";
            ZoomReset.Id = 19;
            ZoomReset.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ZoomReset.ImageOptions.SvgImage");
            ZoomReset.Name = "ZoomReset";
            ZoomReset.ItemClick += ZoomReset_ItemClick;
            // 
            // MainRibbonPage
            // 
            MainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { RibbonPageGroupNewGantt, RibbonPageGroupCurrentTab, RibbonGroupView });
            MainRibbonPage.Name = "MainRibbonPage";
            MainRibbonPage.Text = "Options";
            // 
            // RibbonPageGroupNewGantt
            // 
            RibbonPageGroupNewGantt.ItemLinks.Add(NewGantt);
            RibbonPageGroupNewGantt.ItemLinks.Add(RemoveGantt);
            RibbonPageGroupNewGantt.Name = "RibbonPageGroupNewGantt";
            RibbonPageGroupNewGantt.Text = "Gantt Chart Options";
            // 
            // RibbonPageGroupCurrentTab
            // 
            RibbonPageGroupCurrentTab.ItemLinks.Add(TabColor);
            RibbonPageGroupCurrentTab.ItemLinks.Add(NewTask);
            RibbonPageGroupCurrentTab.ItemLinks.Add(RemoveTask);
            RibbonPageGroupCurrentTab.Name = "RibbonPageGroupCurrentTab";
            RibbonPageGroupCurrentTab.Text = "Gantt Item Options";
            // 
            // RibbonGroupView
            // 
            RibbonGroupView.ItemLinks.Add(ZoomIn);
            RibbonGroupView.ItemLinks.Add(ZoomOut);
            RibbonGroupView.ItemLinks.Add(ZoomReset);
            RibbonGroupView.Name = "RibbonGroupView";
            RibbonGroupView.Text = "View";
            // 
            // MainControl
            // 
            MainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            MainControl.HeaderButtons = DevExpress.XtraTab.TabButtons.None;
            MainControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            MainControl.Location = new System.Drawing.Point(0, 160);
            MainControl.MultiLine = DevExpress.Utils.DefaultBoolean.True;
            MainControl.Name = "MainControl";
            MainControl.Size = new System.Drawing.Size(1022, 607);
            MainControl.TabIndex = 1;
            // 
            // GanttForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(1022, 767);
            Controls.Add(MainControl);
            Controls.Add(MainRibbonControl);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "GanttForm";
            Ribbon = MainRibbonControl;
            Text = "Gantt Window";
            ((System.ComponentModel.ISupportInitialize)MainRibbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemColorPickEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainControl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl MainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage MainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RibbonPageGroupNewGantt;
        private DevExpress.XtraTab.XtraTabControl MainControl;
        private DevExpress.XtraBars.BarButtonItem NewGantt;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RibbonPageGroupCurrentTab;
        private DevExpress.XtraBars.BarEditItem TabColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit1;
        private DevExpress.XtraBars.BarButtonItem NewTask;
        private DevExpress.XtraBars.BarButtonItem RemoveTask;
        private DevExpress.XtraBars.BarButtonItem RemoveGantt;
        private DevExpress.XtraBars.BarButtonItem ZoomIn;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RibbonGroupView;
        private DevExpress.XtraBars.BarButtonItem ZoomOut;
        private DevExpress.XtraBars.BarButtonItem ZoomReset;
    }
}

