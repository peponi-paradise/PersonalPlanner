using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraScheduler;
using PersonalPlanner.Data;
using PersonalPlanner.GUI.Components;
using PersonalPlanner.GUI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace PersonalPlanner.GUI.Frame
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

        private List<(string Name, DateTime Time)> DismissList = new List<(string Name, DateTime Time)>();
        private List<(string Name, System.Timers.Timer Timer)> SnoozeList = new List<(string Name, System.Timers.Timer Timer)>();

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

        private void MainScheduler_DateNavigatorQueryActiveViewType(object sender, DateNavigatorQueryActiveViewTypeEventArgs e)
        {
            MainScheduler.ActiveViewType = e.NewViewType;
            GlobalData.Parameters.SchedulerViewType = (int)e.NewViewType;
        }

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
            e.Handled = true;
            int handledCount = 0;
            foreach (ReminderAlertNotification item in e.AlertNotifications)
            {
                if (item.Handled) handledCount++;
            }
            if (handledCount == e.AlertNotifications.Count)
            {
                foreach (ReminderAlertNotification item in e.AlertNotifications) item.Handled = false;
                return;
            }

            ReminderAlertNotificationCollection copied = new ReminderAlertNotificationCollection();
            foreach (ReminderAlertNotification item in e.AlertNotifications)
            {
                if (!item.Handled) copied.Add(item);
            }
            foreach (ReminderAlertNotification item in e.AlertNotifications) item.Handled = false;

            foreach (ReminderAlertNotification alert in copied)
            {
                NotificationData.Caption = alert.ActualAppointment.Subject ?? "Empty subject";
                NotificationData.Description1 = alert.ActualAppointment.Description ?? "Empty Description";
                NotificationData.Description2 = alert.ActualAppointment.Location ?? "Empty Location";
                NotificationWindow.Show(this);
            }

            CustomRemindersForm remindersForm = new CustomRemindersForm(MainScheduler);
            var args = new ReminderEventArgs(copied);
            remindersForm.SnoozeOccurred += RemindersForm_SnoozeOccurred;
            remindersForm.DismissOccurred += RemindersForm_DismissOccurred;
            remindersForm.OnReminderAlert(args);
            if (remindersForm.WindowState == FormWindowState.Minimized) remindersForm.WindowState = FormWindowState.Normal;
            remindersForm.BringToFront();
        }

        private void RemindersForm_SnoozeOccurred(ReminderCollection reminders, TimeSpan span)
        {
            foreach (var item in reminders)
            {
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = span.TotalMilliseconds;
                timer.Elapsed += (object sender, ElapsedEventArgs e) => DismissTimer_Elapsed(sender, e, item.Subject);
                timer.Start();
                SnoozeList.Add((item.Subject, timer));
            }
        }

        private void RemindersForm_DismissOccurred(ReminderCollection reminders)
        {
            foreach (var item in reminders)
            {
                if (item.Appointment.IsRecurring) DismissList.Add((item.Subject, item.AlertTime));
            }
        }

        private void DismissTimer_Elapsed(object sender, ElapsedEventArgs e, string subject)
        {
            var item = SnoozeList.Find(x => x.Name == subject);
            SnoozeList.Remove(item);
            (sender as System.Timers.Timer).Stop();
        }

        private void MainSchedulerDataStorage_ReminderAlert(object sender, ReminderEventArgs e)
        {
            foreach (var item in SnoozeList)
            {
                var result = AlertContains(item.Name, e.AlertNotifications);
                if (result.isFound)
                {
                    result.notification.Handled = true;
                    result.notification.Reminder.Snooze(TimeSpan.Zero);
                }
            }

            List<(string, DateTime)> dismissRemoveList = new List<(string, DateTime)>();
            for (int i = 0; i < DismissList.Count; i++)
            {
                var item = DismissList[i];
                var result = AlertContains(item.Name, e.AlertNotifications);
                if (result.isFound)
                {
                    if (!result.notification.Handled)
                    {
                        if (item.Time >= result.notification.Reminder.AlertTime)
                        {
                            result.notification.Handled = true;
                            result.notification.Reminder.Snooze(TimeSpan.Zero);
                        }
                        else item.Time = result.notification.Reminder.AlertTime;
                    }
                }
                else dismissRemoveList.Add(item);
            }
            foreach (var item in dismissRemoveList) DismissList.Remove(item);
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
            doc.ImageOptions.ImageUri = "Actions_Calendar;Size16x16";
            CalendarDoc = doc;
        }

        private void AddSchedulerWidget(string name)
        {
            SchedulerUI schedulerUI = new SchedulerUI(MainScheduler);
            var doc = View.AddDocument(schedulerUI, name) as Document;
            doc.ImageOptions.ImageUri = "ShortDate;Size16x16";
            doc.CustomHeaderButtons.Add(new CustomHeaderButton("Working Hours", "WorkingHours;Size16x16", HorizontalImageLocation.Default, ButtonStyle.CheckButton, "Show working hours only", false, 0, -1));
            doc.CustomHeaderButtons[0].Properties.Checked = GlobalData.Parameters.WorktimeShow;
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
            MainSchedulerDataStorage.Appointments.ResourceSharing = true;
            MainSchedulerDataStorage.ReminderAlert += MainSchedulerDataStorage_ReminderAlert;

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
            MainScheduler.DateNavigatorQueryActiveViewType += MainScheduler_DateNavigatorQueryActiveViewType;

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
            if (View.Documents.Contains(CalendarDoc)) WidgetNavigator.SchedulerControl = MainScheduler;
            MainScheduler.DateNavigatorQueryActiveViewType += MainScheduler_DateNavigatorQueryActiveViewType;

            SchedulerContainer.Controls.Add(MainScheduler);
            Navigation.Controls.Add(SchedulerContainer);
            Scheduler.ContentContainer = SchedulerContainer;
        }

        private (bool isFound, ReminderAlertNotification notification) AlertContains(string subject, ReminderAlertNotificationCollection collection)
        {
            bool isFound = false;
            foreach (ReminderAlertNotification notification in collection)
            {
                if (!notification.Handled)
                {
                    if (notification.ActualAppointment.Subject == subject)
                    {
                        isFound = true;
                        return (isFound, notification);
                    }
                }
            }
            return (isFound, null);
        }
    }
}