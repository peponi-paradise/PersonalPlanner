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
            DevExpress.XtraBars.Navigation.AccordionContextButton accordionContextButton3 = new DevExpress.XtraBars.Navigation.AccordionContextButton();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            DevExpress.XtraBars.Navigation.AccordionContextButton accordionContextButton1 = new DevExpress.XtraBars.Navigation.AccordionContextButton();
            ViewContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            Navigation = new CustomAccordionControl();
            CalendarContainer = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            MainCalendar = new DevExpress.XtraScheduler.DateNavigator();
            SchedulerContainer = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            GroupSchedules = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            Calendar = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator1 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            Scheduler = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            GroupMemos = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            NewMemo = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            GroupMemoLists = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            GroupGantts = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            NewGantt = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            GroupGanttLists = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            GroupSettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            FormControlBar = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            FormManager = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(components);
            DocManager = new DevExpress.XtraBars.Docking2010.DocumentManager(components);
            View = new DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView(components);
            ((System.ComponentModel.ISupportInitialize)Navigation).BeginInit();
            Navigation.SuspendLayout();
            CalendarContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainCalendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainCalendar.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FormControlBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FormManager).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DocManager).BeginInit();
            ((System.ComponentModel.ISupportInitialize)View).BeginInit();
            SuspendLayout();
            // 
            // ViewContainer
            // 
            ViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            ViewContainer.Location = new System.Drawing.Point(250, 31);
            ViewContainer.Name = "ViewContainer";
            ViewContainer.Size = new System.Drawing.Size(1028, 928);
            ViewContainer.TabIndex = 0;
            // 
            // Navigation
            // 
            Navigation.ContextButtonsOptions.AllowGlyphSkinning = true;
            Navigation.Controls.Add(CalendarContainer);
            Navigation.Controls.Add(SchedulerContainer);
            Navigation.Dock = System.Windows.Forms.DockStyle.Left;
            Navigation.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { GroupSchedules, GroupMemos, GroupGantts, GroupSettings });
            Navigation.Location = new System.Drawing.Point(0, 31);
            Navigation.Name = "Navigation";
            Navigation.OptionsFooter.ActiveGroupDisplayMode = DevExpress.XtraBars.Navigation.ActiveGroupDisplayMode.GroupHeaderAndContent;
            Navigation.OptionsMinimizing.PopupFormAutoHeightMode = DevExpress.XtraBars.Navigation.AccordionPopupFormAutoHeightMode.FitContent;
            Navigation.RootDisplayMode = DevExpress.XtraBars.Navigation.AccordionControlRootDisplayMode.Footer;
            Navigation.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            Navigation.Size = new System.Drawing.Size(250, 928);
            Navigation.TabIndex = 1;
            Navigation.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // CalendarContainer
            // 
            CalendarContainer.Controls.Add(MainCalendar);
            CalendarContainer.Name = "CalendarContainer";
            CalendarContainer.Size = new System.Drawing.Size(231, 249);
            CalendarContainer.TabIndex = 3;
            // 
            // MainCalendar
            // 
            MainCalendar.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            MainCalendar.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            MainCalendar.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            MainCalendar.ContextButtonOptions.AllowGlyphSkinning = true;
            MainCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            MainCalendar.FirstDayOfWeek = System.DayOfWeek.Sunday;
            MainCalendar.Location = new System.Drawing.Point(0, 0);
            MainCalendar.Name = "MainCalendar";
            MainCalendar.Size = new System.Drawing.Size(231, 249);
            MainCalendar.TabIndex = 0;
            // 
            // SchedulerContainer
            // 
            SchedulerContainer.Name = "SchedulerContainer";
            SchedulerContainer.Size = new System.Drawing.Size(231, 462);
            SchedulerContainer.TabIndex = 7;
            // 
            // GroupSchedules
            // 
            GroupSchedules.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { Calendar, accordionControlSeparator1, Scheduler });
            GroupSchedules.Expanded = true;
            GroupSchedules.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GroupSchedules.ImageOptions.SvgImage");
            GroupSchedules.Name = "GroupSchedules";
            GroupSchedules.Text = "Schedule";
            // 
            // Calendar
            // 
            Calendar.ContentContainer = CalendarContainer;
            accordionContextButton3.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            accordionContextButton3.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            accordionContextButton3.Id = new System.Guid("26839f67-5c88-4a5a-b725-1f5741ff34bf");
            accordionContextButton3.ImageOptionsCollection.ItemNormal.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("resource.SvgImage");
            accordionContextButton3.Name = "CalendarShowButton";
            Calendar.ContextButtons.Add(accordionContextButton3);
            Calendar.Expanded = true;
            Calendar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("Calendar.ImageOptions.SvgImage");
            Calendar.Name = "Calendar";
            Calendar.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            Calendar.Text = "Calendar";
            // 
            // accordionControlSeparator1
            // 
            accordionControlSeparator1.Name = "accordionControlSeparator1";
            // 
            // Scheduler
            // 
            Scheduler.ContentContainer = SchedulerContainer;
            accordionContextButton1.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center;
            accordionContextButton1.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            accordionContextButton1.Id = new System.Guid("3b025ea0-260a-422b-8108-c70efe634387");
            accordionContextButton1.ImageOptionsCollection.ItemNormal.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("resource.SvgImage1");
            accordionContextButton1.Name = "SchedulerShowButton";
            Scheduler.ContextButtons.Add(accordionContextButton1);
            Scheduler.Expanded = true;
            Scheduler.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("Scheduler.ImageOptions.SvgImage");
            Scheduler.Name = "Scheduler";
            Scheduler.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            Scheduler.Text = "Scheduler";
            // 
            // GroupMemos
            // 
            GroupMemos.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { NewMemo, GroupMemoLists });
            GroupMemos.Expanded = true;
            GroupMemos.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GroupMemos.ImageOptions.SvgImage");
            GroupMemos.Name = "GroupMemos";
            GroupMemos.Text = "Memo";
            // 
            // NewMemo
            // 
            NewMemo.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("NewMemo.ImageOptions.SvgImage");
            NewMemo.Name = "NewMemo";
            NewMemo.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            NewMemo.Text = "New Memo";
            // 
            // GroupMemoLists
            // 
            GroupMemoLists.Expanded = true;
            GroupMemoLists.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GroupMemoLists.ImageOptions.SvgImage");
            GroupMemoLists.Name = "GroupMemoLists";
            GroupMemoLists.Text = "Memo List";
            GroupMemoLists.VisibleInFooter = false;
            // 
            // GroupGantts
            // 
            GroupGantts.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { NewGantt, GroupGanttLists });
            GroupGantts.Expanded = true;
            GroupGantts.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GroupGantts.ImageOptions.SvgImage");
            GroupGantts.Name = "GroupGantts";
            GroupGantts.Text = "Gantt";
            // 
            // NewGantt
            // 
            NewGantt.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("NewGantt.ImageOptions.SvgImage");
            NewGantt.Name = "NewGantt";
            NewGantt.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            NewGantt.Text = "New Gantt";
            // 
            // GroupGanttLists
            // 
            GroupGanttLists.Expanded = true;
            GroupGanttLists.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GroupGanttLists.ImageOptions.SvgImage");
            GroupGanttLists.Name = "GroupGanttLists";
            GroupGanttLists.Text = "Gantt Lists";
            // 
            // GroupSettings
            // 
            GroupSettings.ControlFooterAlignment = DevExpress.XtraBars.Navigation.AccordionItemFooterAlignment.Far;
            GroupSettings.Expanded = true;
            GroupSettings.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GroupSettings.ImageOptions.SvgImage");
            GroupSettings.Name = "GroupSettings";
            GroupSettings.Text = "Settings";
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
            FormManager.MaxItemId = 2;
            // 
            // DocManager
            // 
            DocManager.ContainerControl = this;
            DocManager.MenuManager = FormManager;
            DocManager.View = View;
            DocManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] { View });
            // 
            // View
            // 
            View.AllowDocumentStateChangeAnimation = DevExpress.Utils.DefaultBoolean.True;
            View.DocumentProperties.AllowFloat = false;
            View.LayoutMode = DevExpress.XtraBars.Docking2010.Views.Widget.LayoutMode.FreeLayout;
            View.RootContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
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
            Navigation.ResumeLayout(false);
            CalendarContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainCalendar.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainCalendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)FormControlBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)FormManager).EndInit();
            ((System.ComponentModel.ISupportInitialize)DocManager).EndInit();
            ((System.ComponentModel.ISupportInitialize)View).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer ViewContainer;
        private CustomAccordionControl Navigation;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl FormControlBar;
        private DevExpress.XtraBars.Navigation.AccordionControlElement GroupSettings;
        private DevExpress.XtraBars.Navigation.AccordionControlElement GroupMemos;
        private DevExpress.XtraBars.Navigation.AccordionControlElement GroupMemoLists;
        private DevExpress.XtraBars.Navigation.AccordionControlElement GroupSchedules;
        private DevExpress.XtraBars.Navigation.AccordionControlElement GroupGantts;
        private DevExpress.XtraBars.Navigation.AccordionControlElement NewMemo;
        private DevExpress.XtraBars.Docking2010.DocumentManager DocManager;
        private DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView View;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer CalendarContainer;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Calendar;
        private DevExpress.XtraBars.Navigation.AccordionControlElement NewGantt;
        private DevExpress.XtraBars.Navigation.AccordionControlElement GroupGanttLists;
        private DevExpress.XtraScheduler.DateNavigator MainCalendar;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Scheduler;
        public DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager FormManager;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer SchedulerContainer;
    }
}