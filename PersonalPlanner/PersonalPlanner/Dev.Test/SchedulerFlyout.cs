using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalPlanner.Dev.Test
{
    public partial class SchedulerFlyout : XtraUserControl
    {
        /*-------------------------------------------
         *
         *      Design time properties
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Events
         *
         -------------------------------------------*/

        public delegate void ShowClickEventHandler();

        public event ShowClickEventHandler ShowClicked;

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

        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        public SchedulerFlyout()
        {
            InitializeComponent();
        }

        public SchedulerFlyout(SchedulerDataStorage dataStorage, MainFrame mainFrame)
        {
            InitializeComponent();
            var schedulerControl = InitSchedulerOnly(dataStorage, mainFrame);
            schedulerControl.RemindersFormShowing += SchedulerControl_RemindersFormShowing;
            FlyoutControl.Controls.Add(schedulerControl);
        }

        private void SchedulerControl_RemindersFormShowing(object sender, RemindersFormEventArgs e)
        {
            e.Handled = true;
        }

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public void Show(Form parentForm, Point point)
        {
            Flyout.ParentForm = parentForm;
            Flyout.OwnerControl = parentForm;
            Flyout.ShowBeakForm(point);
        }

        private void Flyout_ButtonClick(object sender, DevExpress.Utils.FlyoutPanelButtonClickEventArgs e)
        {
            ShowClicked?.Invoke();
            Flyout.HideBeakForm();
        }

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/

        private SchedulerControl InitSchedulerOnly(SchedulerDataStorage dataStorage, MainFrame mainFrame)
        {
            var MainScheduler = new SchedulerControl();
            MainScheduler.DataStorage = dataStorage;
            MainScheduler.DateNavigationBar.CalendarButton.Show = true;
            MainScheduler.DateNavigationBar.ShowTodayButton = true;
            MainScheduler.DateNavigationBar.ShowViewSelectorButton = false;
            MainScheduler.Dock = System.Windows.Forms.DockStyle.Fill;
            MainScheduler.MenuManager = mainFrame.FormManager;
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

            return MainScheduler;
        }
    }
}