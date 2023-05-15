namespace PersonalPlanner.Dev.Test
{
    partial class MainFrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            ViewContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            Navigation = new DevExpress.XtraBars.Navigation.AccordionControl();
            GroupSettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            GroupMemos = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            GroupMemoLists = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            GroupAppointments = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            GroupGantts = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            FormControlBar = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            FormManager = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(components);
            NewMemo = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)Navigation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FormControlBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FormManager).BeginInit();
            SuspendLayout();
            // 
            // ViewContainer
            // 
            ViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            ViewContainer.Location = new System.Drawing.Point(260, 31);
            ViewContainer.Name = "ViewContainer";
            ViewContainer.Size = new System.Drawing.Size(1018, 928);
            ViewContainer.TabIndex = 0;
            // 
            // Navigation
            // 
            Navigation.AllowItemSelection = true;
            Navigation.ContextButtonsOptions.AllowGlyphSkinning = true;
            Navigation.Dock = System.Windows.Forms.DockStyle.Left;
            Navigation.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { GroupMemos, GroupAppointments, GroupGantts, GroupSettings });
            Navigation.Location = new System.Drawing.Point(0, 31);
            Navigation.Name = "Navigation";
            Navigation.OptionsFooter.ActiveGroupDisplayMode = DevExpress.XtraBars.Navigation.ActiveGroupDisplayMode.GroupHeaderAndContent;
            Navigation.OptionsMinimizing.PopupFormAutoHeightMode = DevExpress.XtraBars.Navigation.AccordionPopupFormAutoHeightMode.FitContent;
            Navigation.RootDisplayMode = DevExpress.XtraBars.Navigation.AccordionControlRootDisplayMode.Footer;
            Navigation.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            Navigation.Size = new System.Drawing.Size(260, 928);
            Navigation.TabIndex = 1;
            Navigation.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // GroupSettings
            // 
            GroupSettings.ControlFooterAlignment = DevExpress.XtraBars.Navigation.AccordionItemFooterAlignment.Far;
            GroupSettings.Expanded = true;
            GroupSettings.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GroupSettings.ImageOptions.SvgImage");
            GroupSettings.Name = "GroupSettings";
            GroupSettings.Text = "Settings";
            // 
            // GroupMemos
            // 
            GroupMemos.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { NewMemo, GroupMemoLists });
            GroupMemos.Expanded = true;
            GroupMemos.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GroupMemos.ImageOptions.SvgImage");
            GroupMemos.Name = "GroupMemos";
            GroupMemos.Text = "Memo";
            // 
            // GroupMemoLists
            // 
            GroupMemoLists.Expanded = true;
            GroupMemoLists.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GroupMemoLists.ImageOptions.SvgImage");
            GroupMemoLists.Name = "GroupMemoLists";
            GroupMemoLists.Text = "Memo List";
            GroupMemoLists.VisibleInFooter = false;
            // 
            // GroupAppointments
            // 
            GroupAppointments.Expanded = true;
            GroupAppointments.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GroupAppointments.ImageOptions.SvgImage");
            GroupAppointments.Name = "GroupAppointments";
            GroupAppointments.Text = "Appointment";
            // 
            // GroupGantts
            // 
            GroupGantts.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GroupGantts.ImageOptions.SvgImage");
            GroupGantts.Name = "GroupGantts";
            GroupGantts.Text = "Gantt";
            // 
            // FormControlBar
            // 
            FormControlBar.FluentDesignForm = this;
            FormControlBar.Location = new System.Drawing.Point(0, 0);
            FormControlBar.Manager = FormManager;
            FormControlBar.Name = "FormControlBar";
            FormControlBar.Size = new System.Drawing.Size(1278, 31);
            FormControlBar.TabIndex = 2;
            FormControlBar.TabStop = false;
            // 
            // FormManager
            // 
            FormManager.AllowGlyphSkinning = true;
            FormManager.Form = this;
            // 
            // NewMemo
            // 
            NewMemo.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("NewMemo.ImageOptions.SvgImage");
            NewMemo.Name = "NewMemo";
            NewMemo.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            NewMemo.Text = "New Memo";
            // 
            // MainFrame
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(1278, 959);
            ControlContainer = ViewContainer;
            Controls.Add(ViewContainer);
            Controls.Add(Navigation);
            Controls.Add(FormControlBar);
            FluentDesignFormControl = FormControlBar;
            IconOptions.Image = (System.Drawing.Image)resources.GetObject("MainFrame.IconOptions.Image");
            Name = "MainFrame";
            NavigationControl = Navigation;
            Text = "Personal Planner";
            ((System.ComponentModel.ISupportInitialize)Navigation).EndInit();
            ((System.ComponentModel.ISupportInitialize)FormControlBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)FormManager).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer ViewContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl Navigation;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl FormControlBar;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager FormManager;
        private DevExpress.XtraBars.Navigation.AccordionControlElement GroupSettings;
        private DevExpress.XtraBars.Navigation.AccordionControlElement GroupMemos;
        private DevExpress.XtraBars.Navigation.AccordionControlElement GroupMemoLists;
        private DevExpress.XtraBars.Navigation.AccordionControlElement GroupAppointments;
        private DevExpress.XtraBars.Navigation.AccordionControlElement GroupGantts;
        private DevExpress.XtraBars.Navigation.AccordionControlElement NewMemo;
    }
}