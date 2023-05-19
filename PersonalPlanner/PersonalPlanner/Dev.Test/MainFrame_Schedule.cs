using DevExpress.Data;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraScheduler;
using PersonalPlanner.Data;
using PersonalPlanner.GUI;
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

        private void MainScheduler_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            AppointmentEditForm form = new AppointmentEditForm(scheduler, e.Appointment, e.OpenRecurrenceForm);
            try
            {
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }
        }

        private void MainScheduler_RemindersFormShowing(object sender, DevExpress.XtraScheduler.RemindersFormEventArgs e)
        {
            if (ShellHelper.IsApplicationShortcutExist(Application.ProductName))
            {
                NotificationsManager.ApplicationName = Application.ProductName;
                NotificationsManager.Notifications[0].AttributionText = $"©ClockStrikes, {DateTime.Now.Year}";
                foreach (ReminderAlertNotification alert in e.AlertNotifications)
                {
                    NotificationsManager.Notifications[0].Header = alert.ActualAppointment.Subject ?? "Empty subject";
                    NotificationsManager.Notifications[0].Body = alert.ActualAppointment.Description ?? "Empty Description";
                    NotificationsManager.Notifications[0].Body2 = alert.ActualAppointment.Location ?? "Empty Location";
                    NotificationsManager.ShowNotification(NotificationsManager.Notifications[0]);
                }
            }
        }

        private void AppointmentLabelButton_Click(object sender, DevExpress.Utils.ContextItemClickEventArgs e) => OpenLabelEditForm();

        private void AppointmentStatusButton_Click(object sender, DevExpress.Utils.ContextItemClickEventArgs e) => OpenStatusEditForm();

        private void AppointmentResourceButton_Click(object sender, DevExpress.Utils.ContextItemClickEventArgs e) => OpenResourceEditForm();

        private void LabelEditForm_FormClosing(object sender, FormClosingEventArgs e) => UpdateAppointmentLabelList();

        private void StatusEditForm_FormClosing(object sender, FormClosingEventArgs e) => UpdateAppointmentStatusList();

        private void ResourceEditForm_FormClosing(object sender, FormClosingEventArgs e) => UpdateAppointmentResourceList();

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

        private void OpenLabelEditForm()
        {
            LabelEditForm labelEditForm = new();
            labelEditForm.FormClosing += LabelEditForm_FormClosing;
            labelEditForm.SetDataSources(AppointmentSettingData.GetLabelDataSet());
            labelEditForm.Show();
        }

        private void UpdateAppointmentLabelList()
        {
            AppointmentSettingData.SaveLabelData();
            AppointmentSettingData.UpdateLabelData(MainScheduler.DataStorage.Appointments.Labels);
        }

        private void OpenStatusEditForm()
        {
            StatusEditForm statusEditForm = new();
            statusEditForm.FormClosing += StatusEditForm_FormClosing;
            statusEditForm.SetDataSources(AppointmentSettingData.GetStatusDataSet());
            statusEditForm.Show();
        }

        private void UpdateAppointmentStatusList()
        {
            AppointmentSettingData.SaveStatusData();
            AppointmentSettingData.UpdateStatusData(MainScheduler.DataStorage.Appointments.Statuses);
        }

        private void OpenResourceEditForm()
        {
            ResourceEditForm resourceEditForm = new();
            resourceEditForm.FormClosing += ResourceEditForm_FormClosing;
            resourceEditForm.SetDataSources(AppointmentSettingData.GetResourceDataSet());
            resourceEditForm.Show();
        }

        private void UpdateAppointmentResourceList()
        {
            AppointmentSettingData.SaveResourceData();
            AppointmentSettingData.UpdateResourceData(MainSchedulerDataStorage.Resources);
            MainScheduler.ResourceCategories.Clear();
        }

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/

        private void InitScheduler()
        {
            //MainSchedulerDataStorage.AppointmentDependencies.AutoReload = true;
            //MainSchedulerDataStorage.Appointments.Labels.Clear();
            MainSchedulerDataStorage.Appointments.ResourceSharing = true;

            MainScheduler.DateNavigationBar.CalendarButton.Show = true;
            MainScheduler.DateNavigationBar.ShowTodayButton = true;
            MainScheduler.DateNavigationBar.ShowViewSelectorButton = false;

            MainScheduler.GoToToday();
            SetWorkingTime();
            MainScheduler.DayView.ShowWorkTimeOnly = GlobalData.Parameters.WorktimeShow;
            MainScheduler.WorkWeekView.ShowWorkTimeOnly = GlobalData.Parameters.WorktimeShow;
            MainScheduler.FullWeekView.ShowWorkTimeOnly = GlobalData.Parameters.WorktimeShow;
            MainScheduler.ActiveViewType = (DevExpress.XtraScheduler.SchedulerViewType)GlobalData.Parameters.SchedulerViewType;

            MainScheduler.OptionsView.ResourceCategories.ResourceDisplayStyle = DevExpress.XtraScheduler.ResourceDisplayStyle.Tabs;
            MainScheduler.OptionsView.ResourceCategories.ShowCloseButton = true;
            MainScheduler.RemindersFormShowing += MainScheduler_RemindersFormShowing;

            MainScheduler.Dock = System.Windows.Forms.DockStyle.Fill;
            MainScheduler.MenuManager = FormManager;
            MainScheduler.Name = "MainScheduler";
            MainScheduler.Views.FullWeekView.Enabled = true;
            MainScheduler.Views.GanttView.Enabled = false;
            MainScheduler.Views.YearView.UseOptimizedScrolling = false;
            MainScheduler.EditAppointmentFormShowing += MainScheduler_EditAppointmentFormShowing;

            MainCalendar.SchedulerControl = MainScheduler;
            SchedulerContainer.Controls.Add(MainScheduler);

            if (GlobalData.Parameters.IsCalendarShow) AddOrActivateCalendar();
            if (GlobalData.Parameters.IsSchedulerShow) AddOrActivateScheduler();
        }

        private void InitSchedulerOnly()
        {
            MainScheduler = new SchedulerControl();
            MainScheduler.DataStorage = MainSchedulerDataStorage;
            MainScheduler.DateNavigationBar.CalendarButton.Show = true;
            MainScheduler.DateNavigationBar.ShowTodayButton = true;
            MainScheduler.DateNavigationBar.ShowViewSelectorButton = false;

            MainScheduler.Start = MainCalendar.SelectionStart;

            SetWorkingTime();
            MainScheduler.DayView.ShowWorkTimeOnly = GlobalData.Parameters.WorktimeShow;
            MainScheduler.WorkWeekView.ShowWorkTimeOnly = GlobalData.Parameters.WorktimeShow;
            MainScheduler.FullWeekView.ShowWorkTimeOnly = GlobalData.Parameters.WorktimeShow;
            MainScheduler.ActiveViewType = (DevExpress.XtraScheduler.SchedulerViewType)GlobalData.Parameters.SchedulerViewType;

            MainScheduler.OptionsView.ResourceCategories.ResourceDisplayStyle = DevExpress.XtraScheduler.ResourceDisplayStyle.Tabs;
            MainScheduler.OptionsView.ResourceCategories.ShowCloseButton = true;
            MainScheduler.RemindersFormShowing += MainScheduler_RemindersFormShowing;

            MainScheduler.Dock = System.Windows.Forms.DockStyle.Fill;
            MainScheduler.MenuManager = FormManager;
            MainScheduler.Name = "MainScheduler";
            MainScheduler.Views.FullWeekView.Enabled = true;
            MainScheduler.Views.GanttView.Enabled = false;
            MainScheduler.Views.YearView.UseOptimizedScrolling = false;
            MainScheduler.EditAppointmentFormShowing += MainScheduler_EditAppointmentFormShowing;

            MainCalendar.SchedulerControl = MainScheduler;
            if (ActivateWidget(CalendarDoc)) WidgetNavigator.SchedulerControl = MainScheduler;
            SchedulerContainer.Controls.Add(MainScheduler);
            Navigation.Controls.Add(SchedulerContainer);
            Scheduler.ContentContainer = SchedulerContainer;
        }
    }
}