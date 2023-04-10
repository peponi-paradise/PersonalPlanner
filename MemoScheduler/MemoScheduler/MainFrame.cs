using DevExpress.LookAndFeel;
using System;
using System.Reflection;
using System.Windows.Forms;
using MemoScheduler.Data;
using MemoScheduler.GUI;

namespace MemoScheduler
{
    public partial class MainFrame : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private MemoForm MemoForm;
        private DevExpress.XtraScheduler.SchedulerGroupType GroupType;

        public MainFrame()
        {
            InitializeComponent();
            SetUILayout();
            this.FormClosing += MainFrame_FormClosing;
        }

        private async void ScheduleImportButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await CalendarData.ReadCalendarAsync(fileDialog.FileName, MainSchedulerDataStorage);
                }
                catch
                {
                    MessageBox.Show("Could not import calendar file");
                    return;
                }
            }
        }

        private async void ScheduleSaveButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "iCalendar (*.ics)|*.ics";
            saveFileDialog.DefaultExt = "ics";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await CalendarData.WriteCalendarAsync(saveFileDialog.FileName, MainSchedulerDataStorage);
                }
                catch
                {
                    MessageBox.Show("Could not save calendar file");
                    return;
                }
            }
        }

        private async void MemoImportButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                await MemoData.LoadDataAsync(fileDialog.FileName);
                if (MemoForm.Visible) MemoForm.SetMemos();
            }
        }

        private async void MemoSaveButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "YAML file (*.yaml)|*.yaml";
            saveFileDialog.DefaultExt = "yaml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) await MemoData.SaveDataAsync(saveFileDialog.FileName);
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            SkinData.SaveAllSkinData();
            var settings = Properties.Settings.Default;
            MemoData.SaveData();
            CalendarData.WriteCalendar(settings.CalendarFilePath, MainSchedulerDataStorage);
            SaveUILayout();
        }

        private void OpenLabelEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenLabelEditForm();

        private void OpenStatusEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenStatusEditForm();

        private void OpenResourceEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenResourceEditForm();

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadingForm.OpenDialog();
            LoadingForm.SetVersion(Assembly.GetExecutingAssembly().GetName().Version.ToString());
            this.SuspendLayout();
            var settings = Properties.Settings.Default;

            LoadingForm.SetProgress("Set Skin...");
            // Set Skin
            if (!string.IsNullOrEmpty(settings.SkinName))
            {
                if (!string.IsNullOrEmpty(settings.Palette)) UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, settings.Palette);
                else UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, "DefaultSkinPalette");
            }
            LoadingForm.SetProgress("Set Skin Done...");

            LoadingForm.SetProgress("Loading Environments...");
            // Import Environments
            try
            {
                AppointmentSettingData.LoadLabelData(MainScheduler.DataStorage.Appointments.Labels);
            }
            catch
            {
                MessageBox.Show("Could not import Label file");
            }

            try
            {
                AppointmentSettingData.LoadStatusData(MainScheduler.DataStorage.Appointments.Statuses);
            }
            catch
            {
                MessageBox.Show("Could not import Status file");
            }

            try
            {
                AppointmentSettingData.LoadResourceData(MainSchedulerDataStorage.Resources);
            }
            catch
            {
                MessageBox.Show("Could not import Resource file");
            }
            LoadingForm.SetProgress("Loading Environments Done...");

            LoadingForm.SetProgress("Loading Memos...");
            // Import Memo
            try
            {
                // First execute check
                if (string.IsNullOrEmpty(settings.MemoFilePath)) settings.MemoFilePath = $@"{Environment.CurrentDirectory}\Data\Memo.yaml";
                await MemoData.LoadDataAsync();
            }
            catch
            {
                MessageBox.Show("Could not import memo file");
            }
            LoadingForm.SetProgress("Loading Memos Done...");

            LoadingForm.SetProgress("Loading Calendar...");
            // Import Calendar
            try
            {
                if (string.IsNullOrEmpty(settings.CalendarFilePath)) settings.CalendarFilePath = $@"{Environment.CurrentDirectory}\Data\Calendar.ics";
                CalendarData.ReadCalendar(settings.CalendarFilePath, MainSchedulerDataStorage);
            }
            catch
            {
                MessageBox.Show("Could not import calendar file");
            }
            LoadingForm.SetProgress("Loading Calendar Done...");

            LoadingForm.SetProgress("Program Start...");

            this.ResumeLayout(false);

            LoadingForm.CloseDialog();
        }

        private void OpenMemoForm()
        {
            if (MemoForm != null) { MemoData.SaveData(); MemoForm.Close(); }
            MemoForm = new MemoForm();
            MemoForm.SetMemos();
            MemoForm.Show();
        }

        private void OpenLabelEditForm()
        {
            LabelEditForm labelEditForm = new();
            labelEditForm.FormClosing += LabelEditForm_FormClosing;
            labelEditForm.SetDataSources(AppointmentSettingData.GetLabelDataSet());
            labelEditForm.Show();
        }

        private void LabelEditForm_FormClosing(object sender, FormClosingEventArgs e) => UpdateAppointmentLabelList();

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

        private void StatusEditForm_FormClosing(object sender, FormClosingEventArgs e) => UpdateAppointmentStatusList();

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

        private void ResourceEditForm_FormClosing(object sender, FormClosingEventArgs e) => UpdateAppointmentResourceList();

        private void UpdateAppointmentResourceList()
        {
            AppointmentSettingData.SaveResourceData();
            AppointmentSettingData.UpdateResourceData(MainSchedulerDataStorage.Resources);
            MainScheduler.ResourceCategories.Clear();
        }

        private void OpenMemo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenMemoForm();
        }

        private void AppointmentGroupSelector_EditValueChanged(object sender, EventArgs e)
        {
            MainScheduler.ResourceCategories.Clear();
            GroupType = (DevExpress.XtraScheduler.SchedulerGroupType)(int)AppointmentGroupSelector.EditValue;
            MainScheduler.GroupType = GroupType;
        }

        private void WorkTimeStart_EditValueChanged(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            settings.OfficeStart = (TimeSpan)WorkTimeStart.EditValue;
            settings.Save();
            SetWorkTime();
        }

        private void WorkTimeEnd_EditValueChanged(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            settings.OfficeEnd = (TimeSpan)WorkTimeEnd.EditValue;
            settings.Save();
            SetWorkTime();
        }

        private void SetWorkTime()
        {
            var settings = Properties.Settings.Default;
            MainScheduler.DayView.WorkTime.Start = settings.OfficeStart;
            MainScheduler.WorkWeekView.WorkTime.Start = settings.OfficeStart;
            MainScheduler.FullWeekView.WorkTime.Start = settings.OfficeStart;
            MainScheduler.TimelineView.WorkTime.Start = settings.OfficeStart;

            MainScheduler.DayView.WorkTime.End = settings.OfficeEnd;
            MainScheduler.WorkWeekView.WorkTime.End = settings.OfficeEnd;
            MainScheduler.FullWeekView.WorkTime.End = settings.OfficeEnd;
            MainScheduler.TimelineView.WorkTime.End = settings.OfficeEnd;
        }

        private void SetUILayout()
        {
            var settings = Properties.Settings.Default;
            MainScheduler.GoToToday();
            MainScheduler.DayView.ShowWorkTimeOnly = settings.DayViewWorktimeShow;
            MainScheduler.WorkWeekView.ShowWorkTimeOnly = settings.WorkweekViewWorktimeShow;
            MainScheduler.FullWeekView.ShowWorkTimeOnly = settings.FullweekViewWorktimeShow;
            MainScheduler.ActiveViewType = (DevExpress.XtraScheduler.SchedulerViewType)settings.SchedulerViewType;
            WorkTimeStart.EditValue = settings.OfficeStart;
            WorkTimeEnd.EditValue = settings.OfficeEnd;
            SetWorkTime();

            AppointmentGroupSelector.EditValue = 0;
            MainScheduler.OptionsView.ResourceCategories.ResourceDisplayStyle = DevExpress.XtraScheduler.ResourceDisplayStyle.Tabs;
            MainScheduler.OptionsView.ResourceCategories.ShowCloseButton = true;
        }

        private void SaveUILayout()
        {
            var settings = Properties.Settings.Default;
            settings.SchedulerViewType = (int)MainScheduler.ActiveViewType;
            settings.DayViewWorktimeShow = MainScheduler.DayView.ShowWorkTimeOnly;
            settings.WorkweekViewWorktimeShow = MainScheduler.WorkWeekView.ShowWorkTimeOnly;
            settings.FullweekViewWorktimeShow = MainScheduler.FullWeekView.ShowWorkTimeOnly;
            settings.Save();
        }
    }
}