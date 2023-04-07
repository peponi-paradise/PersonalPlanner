using DevExpress.LookAndFeel;
using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using WorkCalendar.Data;
using WorkCalendar.GUI;
using WorkCalendar.Parser.YAML;

namespace WorkCalendar
{
    public partial class MainFrame : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainFrame()
        {
            InitializeComponent();
            MainScheduler.Start = DateTime.Now;
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
            //if (fileDialog.ShowDialog() == DialogResult.OK) memoEdit.Text = await MemoData.ReadMemoAsync(fileDialog.FileName);
        }

        private async void MemoSaveButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            //if (saveFileDialog.ShowDialog() == DialogResult.OK) await MemoData.WriteMemoAsync(saveFileDialog.FileName, memoEdit.Text);
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            SkinData.SaveAllSkinData();
            var settings = Properties.Settings.Default;
            //MemoData.WriteMemo(settings.MemoFilePath, memoEdit.Text);
            CalendarData.WriteCalendar(settings.CalendarFilePath, MainSchedulerDataStorage);
        }

        private void OpenLabelEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenLabelEditForm();

        private void OpenStatusEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenStatusEditForm();

        private void OpenResourceEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenResourceEditForm();

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.SuspendLayout();
            var settings = Properties.Settings.Default;

            // Set Skin
            if (!string.IsNullOrEmpty(settings.SkinName))
            {
                if (!string.IsNullOrEmpty(settings.Palette)) UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, settings.Palette);
                else UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, "DefaultSkinPalette");
            }

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

            // Import Memo
            try
            {
                // First execute check
                if (string.IsNullOrEmpty(settings.MemoFilePath)) settings.MemoFilePath = $@"{Environment.CurrentDirectory}\Data\Memo.yaml";
                else await MemoData.LoadDataAsync();
                MemoForm memoForm = new MemoForm();
                memoForm.Dock = DockStyle.Fill;
                MainTabControl.TabPages[1].Controls.Add(memoForm);
                memoForm.SetMemos();
                memoForm.Show();
            }
            catch
            {
                MessageBox.Show("Could not import memo file");
            }

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

            this.ResumeLayout(false);
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
        }
    }
}