using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraScheduler;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalPlanner.Dev.Test
{
    public partial class MainFrame
    {
        /*-------------------------------------------
         *
         *      Events
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Public members
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Private members
         *
         -------------------------------------------*/

        private SchedulerControl MainScheduler;
        private SchedulerDataStorage MainSchedulerDataStorage;
        private DateNavigator WidgetNavigator;
        private Document SchedulerDoc;
        private Document CalendarDoc;

        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        private void CalendarLabel_Click(object sender, EventArgs e)
        {
            if (Navigation.OptionsMinimizing.State == AccordionControlState.Minimized)
            {
                if (ActivateWidget(CalendarDoc)) return;
                var info = Navigation.CalcHitInfo(Navigation.PointToClient(Cursor.Position)).ItemInfo;
                if (info != null)
                {
                    CalendarFlyout flyout = new CalendarFlyout(MainScheduler);
                    var bounds = info.HeaderBounds;
                    var point = Navigation.PointToScreen(new Point(bounds.Right, (bounds.Top + bounds.Bottom) / 2));
                    flyout.ShowClicked += AddOrActivateCalendar;
                    flyout.Show(this, point);
                }
            }
        }

        private void Scheduler_Click(object sender, EventArgs e)
        {
            if (Navigation.OptionsMinimizing.State == AccordionControlState.Minimized)
            {
                if (ActivateWidget(SchedulerDoc)) return;
                var info = Navigation.CalcHitInfo(Navigation.PointToClient(Cursor.Position)).ItemInfo;
                if (info != null)
                {
                    SchedulerFlyout flyout = new SchedulerFlyout(MainSchedulerDataStorage, this);
                    var bounds = info.HeaderBounds;
                    var point = Navigation.PointToScreen(new Point(bounds.Right, (bounds.Top + bounds.Bottom) / 2));
                    flyout.ShowClicked += AddOrActivateScheduler;
                    flyout.Show(this, point);
                }
            }
        }

        private void CalendarShowButton_Click(object sender, DevExpress.Utils.ContextItemClickEventArgs e) => AddOrActivateCalendar();

        private void SchedulerShowButton_Click(object sender, DevExpress.Utils.ContextItemClickEventArgs e) => AddOrActivateScheduler();

        private void Doc_CustomButtonUnchecked(object sender, ButtonEventArgs e)
        {
            if (e.Button == (sender as Document).CustomHeaderButtons[0])
            {
                MainScheduler.Views.DayView.ShowWorkTimeOnly = false;
                MainScheduler.Views.FullWeekView.ShowWorkTimeOnly = false;
                MainScheduler.Views.WorkWeekView.ShowWorkTimeOnly = false;
            }
        }

        private void Doc_CustomButtonChecked(object sender, ButtonEventArgs e)
        {
            if (e.Button == (sender as Document).CustomHeaderButtons[0])
            {
                MainScheduler.Views.DayView.ShowWorkTimeOnly = true;
                MainScheduler.Views.FullWeekView.ShowWorkTimeOnly = true;
                MainScheduler.Views.WorkWeekView.ShowWorkTimeOnly = true;
            }
        }

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        private void AddOrActivateCalendar()
        {
            // Add or activate widget
            if (ActivateWidget(CalendarDoc)) return;
            else
            {
                // Add widget
                AddCalendarWidget(Calendar.Name);
            }
        }

        private void AddOrActivateScheduler()
        {
            // Add or activate widget
            if (ActivateWidget(SchedulerDoc)) return;
            else
            {
                // Add widget
                AddSchedulerWidget(Scheduler.Name);
            }
        }

        private void AddCalendarWidget(string name)
        {
            WidgetNavigator = new DateNavigator();
            WidgetNavigator.SchedulerControl = MainScheduler;
            WidgetNavigator.Name = name;
            var doc = View.AddDocument(WidgetNavigator, name) as Document;
            CalendarDoc = doc;
        }

        private void AddSchedulerWidget(string name)
        {
            SchedulerUI schedulerUI = new SchedulerUI(MainScheduler);
            var doc = View.AddDocument(schedulerUI, name) as Document;
            doc.CustomHeaderButtons.Add(new CustomHeaderButton("Working Hours", "WorkingHours;Size16x16", HorizontalImageLocation.Default, ButtonStyle.CheckButton, "Show working hours only", false, 0, -1));
            doc.CustomButtonChecked += Doc_CustomButtonChecked;
            doc.CustomButtonUnchecked += Doc_CustomButtonUnchecked;
            SchedulerDoc = doc;
            Navigation.Controls.Remove(SchedulerContainer);
            Scheduler.ContentContainer = null;
        }

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/

        private void InitScheduler()
        {
            MainScheduler = new SchedulerControl();
            MainSchedulerDataStorage = new SchedulerDataStorage(components);

            MainSchedulerDataStorage.AppointmentDependencies.AutoReload = false;
            MainSchedulerDataStorage.Appointments.Labels.CreateNewLabel(0, "None", "&None", System.Drawing.SystemColors.Window);
            MainSchedulerDataStorage.Appointments.Labels.CreateNewLabel(1, "Important", "&Important", System.Drawing.Color.FromArgb(255, 194, 190));
            MainSchedulerDataStorage.Appointments.Labels.CreateNewLabel(2, "Business", "&Business", System.Drawing.Color.FromArgb(168, 213, 255));
            MainSchedulerDataStorage.Appointments.Labels.CreateNewLabel(3, "Personal", "&Personal", System.Drawing.Color.FromArgb(193, 244, 156));
            MainSchedulerDataStorage.Appointments.Labels.CreateNewLabel(4, "Vacation", "&Vacation", System.Drawing.Color.FromArgb(243, 228, 199));
            MainSchedulerDataStorage.Appointments.Labels.CreateNewLabel(5, "Must Attend", "Must &Attend", System.Drawing.Color.FromArgb(244, 206, 147));
            MainSchedulerDataStorage.Appointments.Labels.CreateNewLabel(6, "Travel Required", "&Travel Required", System.Drawing.Color.FromArgb(199, 244, 255));
            MainSchedulerDataStorage.Appointments.Labels.CreateNewLabel(7, "Needs Preparation", "&Needs Preparation", System.Drawing.Color.FromArgb(207, 219, 152));
            MainSchedulerDataStorage.Appointments.Labels.CreateNewLabel(8, "Birthday", "&Birthday", System.Drawing.Color.FromArgb(224, 207, 233));
            MainSchedulerDataStorage.Appointments.Labels.CreateNewLabel(9, "Anniversary", "&Anniversary", System.Drawing.Color.FromArgb(141, 233, 223));
            MainSchedulerDataStorage.Appointments.Labels.CreateNewLabel(10, "Phone Call", "Phone &Call", System.Drawing.Color.FromArgb(255, 247, 165));
            MainSchedulerDataStorage.Appointments.ResourceSharing = true;

            MainScheduler.DataStorage = MainSchedulerDataStorage;
            MainScheduler.DateNavigationBar.CalendarButton.Show = true;
            MainScheduler.DateNavigationBar.ShowTodayButton = true;
            MainScheduler.DateNavigationBar.ShowViewSelectorButton = false;
            MainScheduler.Dock = System.Windows.Forms.DockStyle.Fill;
            MainScheduler.MenuManager = FormManager;
            MainScheduler.Name = "MainScheduler";
            MainScheduler.Start = DateTime.Today;
            MainScheduler.Views.DayView.WorkTime = new DevExpress.XtraScheduler.WorkTimeInterval(System.TimeSpan.Parse("08:00:00"), System.TimeSpan.Parse("17:00:00"));
            MainScheduler.Views.FullWeekView.Enabled = true;
            MainScheduler.Views.FullWeekView.WorkTime = new DevExpress.XtraScheduler.WorkTimeInterval(System.TimeSpan.Parse("08:00:00"), System.TimeSpan.Parse("17:00:00"));
            MainScheduler.Views.GanttView.Enabled = false;
            MainScheduler.Views.GanttView.WorkTime = new DevExpress.XtraScheduler.WorkTimeInterval(System.TimeSpan.Parse("08:00:00"), System.TimeSpan.Parse("17:00:00"));
            MainScheduler.Views.TimelineView.WorkTime = new DevExpress.XtraScheduler.WorkTimeInterval(System.TimeSpan.Parse("08:00:00"), System.TimeSpan.Parse("17:00:00"));
            MainScheduler.Views.WorkWeekView.WorkTime = new DevExpress.XtraScheduler.WorkTimeInterval(System.TimeSpan.Parse("08:00:00"), System.TimeSpan.Parse("17:00:00"));
            MainScheduler.Views.YearView.UseOptimizedScrolling = false;
            //MainScheduler.EditAppointmentFormShowing += MainScheduler_EditAppointmentFormShowing;

            MainCalendar.SchedulerControl = MainScheduler;
            SchedulerContainer.Controls.Add(MainScheduler);
        }

        private void InitSchedulerOnly()
        {
            MainScheduler = new SchedulerControl();
            MainScheduler.DataStorage = MainSchedulerDataStorage;
            MainScheduler.DateNavigationBar.CalendarButton.Show = true;
            MainScheduler.DateNavigationBar.ShowTodayButton = true;
            MainScheduler.DateNavigationBar.ShowViewSelectorButton = false;
            MainScheduler.Dock = System.Windows.Forms.DockStyle.Fill;
            MainScheduler.MenuManager = FormManager;
            MainScheduler.Name = "MainScheduler";
            MainScheduler.Start = MainCalendar.SelectionStart;

            MainScheduler.Views.DayView.WorkTime = new DevExpress.XtraScheduler.WorkTimeInterval(System.TimeSpan.Parse("08:00:00"), System.TimeSpan.Parse("17:00:00"));
            MainScheduler.Views.FullWeekView.Enabled = true;
            MainScheduler.Views.FullWeekView.WorkTime = new DevExpress.XtraScheduler.WorkTimeInterval(System.TimeSpan.Parse("08:00:00"), System.TimeSpan.Parse("17:00:00"));
            MainScheduler.Views.GanttView.Enabled = false;
            MainScheduler.Views.GanttView.WorkTime = new DevExpress.XtraScheduler.WorkTimeInterval(System.TimeSpan.Parse("08:00:00"), System.TimeSpan.Parse("17:00:00"));
            MainScheduler.Views.TimelineView.WorkTime = new DevExpress.XtraScheduler.WorkTimeInterval(System.TimeSpan.Parse("08:00:00"), System.TimeSpan.Parse("17:00:00"));
            MainScheduler.Views.WorkWeekView.WorkTime = new DevExpress.XtraScheduler.WorkTimeInterval(System.TimeSpan.Parse("08:00:00"), System.TimeSpan.Parse("17:00:00"));
            MainScheduler.Views.YearView.UseOptimizedScrolling = false;
            //MainScheduler.EditAppointmentFormShowing += MainScheduler_EditAppointmentFormShowing;

            MainCalendar.SchedulerControl = MainScheduler;
            if (ActivateWidget(CalendarDoc)) WidgetNavigator.SchedulerControl = MainScheduler;
            SchedulerContainer.Controls.Add(MainScheduler);
            Navigation.Controls.Add(SchedulerContainer);
            Scheduler.ContentContainer = SchedulerContainer;
        }
    }
}