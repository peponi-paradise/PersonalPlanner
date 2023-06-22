//namespace PersonalPlanner.GUI
//{
//    partial class GanttForm
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GanttForm));
//            MainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
//            NewGantt = new DevExpress.XtraBars.BarButtonItem();
//            TabColor = new DevExpress.XtraBars.BarEditItem();
//            repositoryItemColorPickEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
//            NewTask = new DevExpress.XtraBars.BarButtonItem();
//            RemoveTask = new DevExpress.XtraBars.BarButtonItem();
//            RemoveGantt = new DevExpress.XtraBars.BarButtonItem();
//            ZoomIn = new DevExpress.XtraBars.BarButtonItem();
//            ZoomOut = new DevExpress.XtraBars.BarButtonItem();
//            ZoomReset = new DevExpress.XtraBars.BarButtonItem();
//            ChartViewStart = new DevExpress.XtraBars.BarEditItem();
//            repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
//            ChartViewFinish = new DevExpress.XtraBars.BarEditItem();
//            repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
//            ShowHelp = new DevExpress.XtraBars.BarButtonItem();
//            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
//            MainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
//            RibbonPageGroupNewGantt = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
//            RibbonPageGroupCurrentTab = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
//            RibbonGroupView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
//            HelpRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
//            HelpRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
//            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
//            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
//            MainControl = new DevExpress.XtraTab.XtraTabControl();
//            ((System.ComponentModel.ISupportInitialize)MainRibbonControl).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)repositoryItemColorPickEdit1).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit1).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit1.CalendarTimeProperties).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit2).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit2.CalendarTimeProperties).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)MainControl).BeginInit();
//            SuspendLayout();
//            // 
//            // MainRibbonControl
//            // 
//            MainRibbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 32, 35, 32);
//            MainRibbonControl.ExpandCollapseItem.Id = 0;
//            MainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { MainRibbonControl.ExpandCollapseItem, MainRibbonControl.SearchEditItem, NewGantt, TabColor, NewTask, RemoveTask, RemoveGantt, ZoomIn, ZoomOut, ZoomReset, ChartViewStart, ChartViewFinish, ShowHelp, barButtonItem1 });
//            MainRibbonControl.Location = new System.Drawing.Point(0, 0);
//            MainRibbonControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
//            MainRibbonControl.MaxItemId = 24;
//            MainRibbonControl.Name = "MainRibbonControl";
//            MainRibbonControl.OptionsMenuMinWidth = 385;
//            MainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { MainRibbonPage, HelpRibbonPage, ribbonPage1 });
//            MainRibbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemColorPickEdit1, repositoryItemDateEdit1, repositoryItemDateEdit2 });
//            MainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
//            MainRibbonControl.ShowQatLocationSelector = false;
//            MainRibbonControl.ShowToolbarCustomizeItem = false;
//            MainRibbonControl.Size = new System.Drawing.Size(1022, 160);
//            MainRibbonControl.Toolbar.ShowCustomizeItem = false;
//            // 
//            // NewGantt
//            // 
//            NewGantt.Caption = "New Chart";
//            NewGantt.Id = 12;
//            NewGantt.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("NewGantt.ImageOptions.SvgImage");
//            NewGantt.Name = "NewGantt";
//            NewGantt.ItemClick += NewGantt_ItemClick;
//            // 
//            // TabColor
//            // 
//            TabColor.Caption = "Tab Color";
//            TabColor.Edit = repositoryItemColorPickEdit1;
//            TabColor.Id = 13;
//            TabColor.Name = "TabColor";
//            TabColor.EditValueChanged += TabColor_EditValueChanged;
//            // 
//            // repositoryItemColorPickEdit1
//            // 
//            repositoryItemColorPickEdit1.AutoHeight = false;
//            repositoryItemColorPickEdit1.AutomaticColor = System.Drawing.Color.Black;
//            repositoryItemColorPickEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
//            repositoryItemColorPickEdit1.Name = "repositoryItemColorPickEdit1";
//            // 
//            // NewTask
//            // 
//            NewTask.Caption = "New Task";
//            NewTask.Id = 14;
//            NewTask.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("NewTask.ImageOptions.SvgImage");
//            NewTask.Name = "NewTask";
//            NewTask.ItemClick += NewTask_ItemClick;
//            // 
//            // RemoveTask
//            // 
//            RemoveTask.Caption = "Remove Task";
//            RemoveTask.Id = 15;
//            RemoveTask.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("RemoveTask.ImageOptions.SvgImage");
//            RemoveTask.Name = "RemoveTask";
//            RemoveTask.ItemClick += RemoveTask_ItemClick;
//            // 
//            // RemoveGantt
//            // 
//            RemoveGantt.Caption = "Remove Chart";
//            RemoveGantt.Id = 16;
//            RemoveGantt.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("RemoveGantt.ImageOptions.SvgImage");
//            RemoveGantt.Name = "RemoveGantt";
//            RemoveGantt.ItemClick += RemoveGantt_ItemClick;
//            // 
//            // ZoomIn
//            // 
//            ZoomIn.Caption = "Zoom In";
//            ZoomIn.Id = 17;
//            ZoomIn.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ZoomIn.ImageOptions.SvgImage");
//            ZoomIn.Name = "ZoomIn";
//            ZoomIn.ItemClick += ZoomIn_ItemClick;
//            // 
//            // ZoomOut
//            // 
//            ZoomOut.Caption = "Zoom Out";
//            ZoomOut.Id = 18;
//            ZoomOut.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ZoomOut.ImageOptions.SvgImage");
//            ZoomOut.Name = "ZoomOut";
//            ZoomOut.ItemClick += ZoomOut_ItemClick;
//            // 
//            // ZoomReset
//            // 
//            ZoomReset.Caption = "Reset";
//            ZoomReset.Id = 19;
//            ZoomReset.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ZoomReset.ImageOptions.SvgImage");
//            ZoomReset.Name = "ZoomReset";
//            ZoomReset.ItemClick += ZoomReset_ItemClick;
//            // 
//            // ChartViewStart
//            // 
//            ChartViewStart.Caption = "Start Date";
//            ChartViewStart.Edit = repositoryItemDateEdit1;
//            ChartViewStart.EditWidth = 100;
//            ChartViewStart.Id = 20;
//            ChartViewStart.Name = "ChartViewStart";
//            ChartViewStart.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
//            ChartViewStart.EditValueChanged += ChartViewStart_EditValueChanged;
//            // 
//            // repositoryItemDateEdit1
//            // 
//            repositoryItemDateEdit1.AutoHeight = false;
//            repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
//            repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
//            repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
//            // 
//            // ChartViewFinish
//            // 
//            ChartViewFinish.Caption = "Finish Date";
//            ChartViewFinish.Edit = repositoryItemDateEdit2;
//            ChartViewFinish.EditWidth = 100;
//            ChartViewFinish.Id = 21;
//            ChartViewFinish.Name = "ChartViewFinish";
//            ChartViewFinish.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
//            ChartViewFinish.EditValueChanged += ChartViewFinish_EditValueChanged;
//            // 
//            // repositoryItemDateEdit2
//            // 
//            repositoryItemDateEdit2.AutoHeight = false;
//            repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
//            repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
//            repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
//            // 
//            // ShowHelp
//            // 
//            ShowHelp.Caption = "Show Help";
//            ShowHelp.Id = 22;
//            ShowHelp.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ShowHelp.ImageOptions.SvgImage");
//            ShowHelp.Name = "ShowHelp";
//            ShowHelp.ItemClick += ShowHelp_ItemClick;
//            // 
//            // barButtonItem1
//            // 
//            barButtonItem1.Caption = "barButtonItem1";
//            barButtonItem1.Id = 23;
//            barButtonItem1.Name = "barButtonItem1";
//            barButtonItem1.ItemClick += barButtonItem1_ItemClick;
//            // 
//            // MainRibbonPage
//            // 
//            MainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { RibbonPageGroupNewGantt, RibbonPageGroupCurrentTab, RibbonGroupView });
//            MainRibbonPage.Name = "MainRibbonPage";
//            MainRibbonPage.Text = "Options";
//            // 
//            // RibbonPageGroupNewGantt
//            // 
//            RibbonPageGroupNewGantt.ItemLinks.Add(NewGantt);
//            RibbonPageGroupNewGantt.ItemLinks.Add(RemoveGantt);
//            RibbonPageGroupNewGantt.Name = "RibbonPageGroupNewGantt";
//            RibbonPageGroupNewGantt.Text = "Gantt Chart Options";
//            // 
//            // RibbonPageGroupCurrentTab
//            // 
//            RibbonPageGroupCurrentTab.ItemLinks.Add(TabColor);
//            RibbonPageGroupCurrentTab.ItemLinks.Add(NewTask);
//            RibbonPageGroupCurrentTab.ItemLinks.Add(RemoveTask);
//            RibbonPageGroupCurrentTab.Name = "RibbonPageGroupCurrentTab";
//            RibbonPageGroupCurrentTab.Text = "Gantt Item Options";
//            // 
//            // RibbonGroupView
//            // 
//            RibbonGroupView.ItemLinks.Add(ZoomIn);
//            RibbonGroupView.ItemLinks.Add(ZoomOut);
//            RibbonGroupView.ItemLinks.Add(ZoomReset);
//            RibbonGroupView.ItemLinks.Add(ChartViewStart);
//            RibbonGroupView.ItemLinks.Add(ChartViewFinish);
//            RibbonGroupView.Name = "RibbonGroupView";
//            RibbonGroupView.Text = "View";
//            // 
//            // HelpRibbonPage
//            // 
//            HelpRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { HelpRibbonPageGroup });
//            HelpRibbonPage.Name = "HelpRibbonPage";
//            HelpRibbonPage.Text = "Help";
//            // 
//            // HelpRibbonPageGroup
//            // 
//            HelpRibbonPageGroup.ItemLinks.Add(ShowHelp);
//            HelpRibbonPageGroup.Name = "HelpRibbonPageGroup";
//            HelpRibbonPageGroup.Text = "Help";
//            // 
//            // ribbonPage1
//            // 
//            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
//            ribbonPage1.Name = "ribbonPage1";
//            ribbonPage1.Text = "ribbonPage1";
//            ribbonPage1.Visible = false;
//            // 
//            // ribbonPageGroup1
//            // 
//            ribbonPageGroup1.ItemLinks.Add(barButtonItem1);
//            ribbonPageGroup1.Name = "ribbonPageGroup1";
//            ribbonPageGroup1.Text = "ribbonPageGroup1";
//            // 
//            // MainControl
//            // 
//            MainControl.Dock = System.Windows.Forms.DockStyle.Fill;
//            MainControl.HeaderButtons = DevExpress.XtraTab.TabButtons.None;
//            MainControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
//            MainControl.Location = new System.Drawing.Point(0, 160);
//            MainControl.MultiLine = DevExpress.Utils.DefaultBoolean.True;
//            MainControl.Name = "MainControl";
//            MainControl.Size = new System.Drawing.Size(1022, 607);
//            MainControl.TabIndex = 1;
//            // 
//            // GanttForm
//            // 
//            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
//            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
//            ClientSize = new System.Drawing.Size(1022, 767);
//            Controls.Add(MainControl);
//            Controls.Add(MainRibbonControl);
//            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GanttForm.IconOptions.SvgImage");
//            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
//            Name = "GanttForm";
//            Ribbon = MainRibbonControl;
//            Text = "Gantt Window";
//            ((System.ComponentModel.ISupportInitialize)MainRibbonControl).EndInit();
//            ((System.ComponentModel.ISupportInitialize)repositoryItemColorPickEdit1).EndInit();
//            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit1.CalendarTimeProperties).EndInit();
//            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit1).EndInit();
//            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit2.CalendarTimeProperties).EndInit();
//            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit2).EndInit();
//            ((System.ComponentModel.ISupportInitialize)MainControl).EndInit();
//            ResumeLayout(false);
//            PerformLayout();
//        }

//        #endregion

//        private DevExpress.XtraBars.Ribbon.RibbonControl MainRibbonControl;
//        private DevExpress.XtraBars.Ribbon.RibbonPage MainRibbonPage;
//        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RibbonPageGroupNewGantt;
//        private DevExpress.XtraTab.XtraTabControl MainControl;
//        private DevExpress.XtraBars.BarButtonItem NewGantt;
//        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RibbonPageGroupCurrentTab;
//        private DevExpress.XtraBars.BarEditItem TabColor;
//        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit1;
//        private DevExpress.XtraBars.BarButtonItem NewTask;
//        private DevExpress.XtraBars.BarButtonItem RemoveTask;
//        private DevExpress.XtraBars.BarButtonItem RemoveGantt;
//        private DevExpress.XtraBars.BarButtonItem ZoomIn;
//        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RibbonGroupView;
//        private DevExpress.XtraBars.BarButtonItem ZoomOut;
//        private DevExpress.XtraBars.BarButtonItem ZoomReset;
//        private DevExpress.XtraBars.BarEditItem ChartViewStart;
//        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
//        private DevExpress.XtraBars.BarEditItem ChartViewFinish;
//        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
//        private DevExpress.XtraBars.BarButtonItem ShowHelp;
//        private DevExpress.XtraBars.Ribbon.RibbonPage HelpRibbonPage;
//        private DevExpress.XtraBars.Ribbon.RibbonPageGroup HelpRibbonPageGroup;
//        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
//        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
//        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
//    }
//}

