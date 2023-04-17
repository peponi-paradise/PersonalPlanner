﻿using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using PersonalPlanner.Data;
using PersonalPlanner.GUI;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace PersonalPlanner
{
    public partial class MainFrame : DevExpress.XtraBars.Ribbon.RibbonForm
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
        private MemoForm MemoForm;
        private GanttForm GanttForm;
        private DevExpress.XtraScheduler.SchedulerGroupType GroupType;
        private bool IsMinimized = false;

        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        public MainFrame()
        {
            InitializeComponent();
            SetUILayout();
            this.FormClosing += MainFrame_FormClosing;
            MainRibbonControl.MouseWheel += MainRibbonControl_MouseWheel;
        }

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadingForm.OpenDialog();
            LoadingForm.SetVersion(Assembly.GetExecutingAssembly().GetName().Version.ToString());
            this.SuspendLayout();
            var settings = Properties.Settings.Default;

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

            LoadingForm.SetProgress("Loading Gantt...");
            try
            {
                if (!GanttData.LoadData()) XtraMessageBox.Show("Could not import gantt file");
            }
            catch
            {
            }
            LoadingForm.SetProgress("Loading Gantt Done...");

            LoadingForm.SetProgress("Set Skin...");
            // Set Skin
            if (!string.IsNullOrEmpty(settings.SkinName))
            {
                if (!string.IsNullOrEmpty(settings.Palette)) UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, settings.Palette);
                else UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, "DefaultSkinPalette");
            }
            foreach (GalleryItem item in skinRibbonGalleryBarItem1.Gallery.GetAllItems())
            {
                if (item.Caption.Contains("Compact")) item.Visible = false;
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
                MainScheduler.Appointment.
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

            LoadingForm.SetProgress("Program Start...");

            if (settings.MemoFormShowOnStartUp) OpenMemoForm();
            if (settings.GanttFormShowOnStartUp) OpenGanttForm();

            this.ResumeLayout(false);

            LoadingForm.CloseDialog();

            this.Resize += MainFrame_Resized;
        }

        private void MainFrame_Resized(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) IsMinimized = true;
            else if (this.IsMinimized)
            {
                this.IsMinimized = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form != null && form.WindowState == FormWindowState.Minimized) GUI.GUI.RestoreWindow(form);
                    form.BringToFront();
                }
                this.Focus();
            }
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            WaitForm.OpenDialog("Closing...", "Saving datas...");
            try
            {
                SkinData.SaveAllSkinData();
                var settings = Properties.Settings.Default;
                MemoData.SaveData();
                CalendarData.WriteCalendar(settings.CalendarFilePath, MainSchedulerDataStorage);
                GanttData.SaveData();
                SaveUILayout();
            }
            finally
            {
                WaitForm.CloseDialog();
            }
        }

        private void MainRibbonControl_MouseWheel(object sender, MouseEventArgs e) => DXMouseEventArgs.GetMouseArgs(e).Handled = true;

        private void OpenMemo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenMemoForm();

        private void OpenGantt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenGanttForm();

        private void OpenLabelEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenLabelEditForm();

        private void LabelEditForm_FormClosing(object sender, FormClosingEventArgs e) => UpdateAppointmentLabelList();

        private void OpenStatusEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenStatusEditForm();

        private void StatusEditForm_FormClosing(object sender, FormClosingEventArgs e) => UpdateAppointmentStatusList();

        private void OpenResourceEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenResourceEditForm();

        private void ResourceEditForm_FormClosing(object sender, FormClosingEventArgs e) => UpdateAppointmentResourceList();

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
            SetWorkTime();
        }

        private void WorkTimeEnd_EditValueChanged(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            settings.OfficeEnd = (TimeSpan)WorkTimeEnd.EditValue;
            SetWorkTime();
        }

        private async void ScheduleImportButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await CalendarData.ReadCalendarAsync(fileDialog.FileName, MainSchedulerDataStorage);
                    MainSchedulerDataStorage.RefreshData(true);
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

        private void MemoFormShow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var settings = Properties.Settings.Default;
            settings.MemoFormShowOnStartUp = MemoFormShow.Checked;
        }

        private void GanttFormShow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var settings = Properties.Settings.Default;
            settings.GanttFormShowOnStartUp = GanttFormShow.Checked;
        }

        private void skinRibbonGalleryBarItem1_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Properties.Settings.Default.SkinName = e.Item.Caption;
            try
            {
                UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.SkinName, Properties.Settings.Default.Palette);
            }
            catch
            {
                UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.SkinName);
            }
        }

        private void skinPaletteRibbonGalleryBarItem1_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Properties.Settings.Default.Palette = e.Item.Caption;
            try
            {
                UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.SkinName, Properties.Settings.Default.Palette);
            }
            catch
            {
                UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.SkinName);
            }
        }

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        private void OpenMemoForm()
        {
            if (MemoForm != null) { MemoData.SaveData(); MemoForm.Close(); }
            MemoForm = new MemoForm();
            MemoForm.SetMemos();
            MemoForm.Show();
        }

        private void OpenGanttForm()
        {
            if (GanttForm != null) { GanttData.SaveData(); GanttForm.Close(); }
            GanttForm = new GanttForm();
            GanttForm.Show();
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

            if (settings.MainFrameLocation == new Point(0, 0)) this.StartPosition = FormStartPosition.CenterScreen;
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = settings.MainFrameLocation;
            }
            if (settings.MainFrameSize != new Size(0, 0)) this.Size = settings.MainFrameSize;

            MemoFormShow.Checked = settings.MemoFormShowOnStartUp;
            GanttFormShow.Checked = settings.GanttFormShowOnStartUp;

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

            settings.MainFrameLocation = this.Location;
            settings.MainFrameSize = this.Size;
            if (MemoForm != null && MemoForm.Visible && MemoForm.WindowState != FormWindowState.Minimized) { settings.MemoFormLocation = MemoForm.Location; settings.MemoFormSize = MemoForm.Size; }
            if (GanttForm != null && GanttForm.Visible && GanttForm.WindowState != FormWindowState.Minimized) { settings.GanttFormLocation = GanttForm.Location; settings.GanttFormSize = GanttForm.Size; }

            settings.SchedulerViewType = (int)MainScheduler.ActiveViewType;
            settings.DayViewWorktimeShow = MainScheduler.DayView.ShowWorkTimeOnly;
            settings.WorkweekViewWorktimeShow = MainScheduler.WorkWeekView.ShowWorkTimeOnly;
            settings.FullweekViewWorktimeShow = MainScheduler.FullWeekView.ShowWorkTimeOnly;
        }
    }
}