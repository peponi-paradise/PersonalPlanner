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
            this.MainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.NewGantt = new DevExpress.XtraBars.BarButtonItem();
            this.TabColor = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemColorPickEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.NewTask = new DevExpress.XtraBars.BarButtonItem();
            this.RemoveTask = new DevExpress.XtraBars.BarButtonItem();
            this.MainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroupNewGantt = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RibbonPageGroupCurrentTab = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.MainControl = new DevExpress.XtraTab.XtraTabControl();
            this.RemoveGantt = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.MainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainControl)).BeginInit();
            this.SuspendLayout();
            // 
            // MainRibbonControl
            // 
            this.MainRibbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 32, 35, 32);
            this.MainRibbonControl.ExpandCollapseItem.Id = 0;
            this.MainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.MainRibbonControl.ExpandCollapseItem,
            this.MainRibbonControl.SearchEditItem,
            this.NewGantt,
            this.TabColor,
            this.NewTask,
            this.RemoveTask,
            this.RemoveGantt});
            this.MainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.MainRibbonControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MainRibbonControl.MaxItemId = 17;
            this.MainRibbonControl.Name = "MainRibbonControl";
            this.MainRibbonControl.OptionsMenuMinWidth = 385;
            this.MainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.MainRibbonPage});
            this.MainRibbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEdit1});
            this.MainRibbonControl.Size = new System.Drawing.Size(1022, 160);
            // 
            // NewGantt
            // 
            this.NewGantt.Caption = "New Chart";
            this.NewGantt.Id = 12;
            this.NewGantt.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NewGantt.ImageOptions.SvgImage")));
            this.NewGantt.Name = "NewGantt";
            this.NewGantt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NewGantt_ItemClick);
            // 
            // TabColor
            // 
            this.TabColor.Caption = "Tab Color";
            this.TabColor.Edit = this.repositoryItemColorPickEdit1;
            this.TabColor.Id = 13;
            this.TabColor.Name = "TabColor";
            this.TabColor.EditValueChanged += new System.EventHandler(this.TabColor_EditValueChanged);
            // 
            // repositoryItemColorPickEdit1
            // 
            this.repositoryItemColorPickEdit1.AutoHeight = false;
            this.repositoryItemColorPickEdit1.AutomaticColor = System.Drawing.Color.Black;
            this.repositoryItemColorPickEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEdit1.Name = "repositoryItemColorPickEdit1";
            // 
            // NewTask
            // 
            this.NewTask.Caption = "New Task";
            this.NewTask.Id = 14;
            this.NewTask.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NewTask.ImageOptions.SvgImage")));
            this.NewTask.Name = "NewTask";
            this.NewTask.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NewTask_ItemClick);
            // 
            // RemoveTask
            // 
            this.RemoveTask.Caption = "Remove Task";
            this.RemoveTask.Id = 15;
            this.RemoveTask.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("RemoveTask.ImageOptions.SvgImage")));
            this.RemoveTask.Name = "RemoveTask";
            this.RemoveTask.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RemoveTask_ItemClick);
            // 
            // MainRibbonPage
            // 
            this.MainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroupNewGantt,
            this.RibbonPageGroupCurrentTab});
            this.MainRibbonPage.Name = "MainRibbonPage";
            this.MainRibbonPage.Text = "Options";
            // 
            // RibbonPageGroupNewGantt
            // 
            this.RibbonPageGroupNewGantt.ItemLinks.Add(this.NewGantt);
            this.RibbonPageGroupNewGantt.ItemLinks.Add(this.RemoveGantt);
            this.RibbonPageGroupNewGantt.Name = "RibbonPageGroupNewGantt";
            this.RibbonPageGroupNewGantt.Text = "Gantt Chart Options";
            // 
            // RibbonPageGroupCurrentTab
            // 
            this.RibbonPageGroupCurrentTab.ItemLinks.Add(this.TabColor);
            this.RibbonPageGroupCurrentTab.ItemLinks.Add(this.NewTask);
            this.RibbonPageGroupCurrentTab.ItemLinks.Add(this.RemoveTask);
            this.RibbonPageGroupCurrentTab.Name = "RibbonPageGroupCurrentTab";
            this.RibbonPageGroupCurrentTab.Text = "Gantt Item Options";
            // 
            // MainControl
            // 
            this.MainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainControl.HeaderButtons = DevExpress.XtraTab.TabButtons.None;
            this.MainControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.MainControl.Location = new System.Drawing.Point(0, 160);
            this.MainControl.MultiLine = DevExpress.Utils.DefaultBoolean.True;
            this.MainControl.Name = "MainControl";
            this.MainControl.Size = new System.Drawing.Size(1022, 607);
            this.MainControl.TabIndex = 1;
            // 
            // RemoveGantt
            // 
            this.RemoveGantt.Caption = "Remove Chart";
            this.RemoveGantt.Id = 16;
            this.RemoveGantt.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("RemoveGantt.ImageOptions.SvgImage")));
            this.RemoveGantt.Name = "RemoveGantt";
            this.RemoveGantt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RemoveGantt_ItemClick);
            // 
            // GanttForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1022, 767);
            this.Controls.Add(this.MainControl);
            this.Controls.Add(this.MainRibbonControl);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "GanttForm";
            this.Ribbon = this.MainRibbonControl;
            this.Text = "Gantt Window";
            ((System.ComponentModel.ISupportInitialize)(this.MainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

