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
            if (fileDialog.ShowDialog() == DialogResult.OK) memoEdit.Text = await MemoData.ReadMemoAsync(fileDialog.FileName);
        }

        private async void MemoSaveButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) await MemoData.WriteMemoAsync(saveFileDialog.FileName, memoEdit.Text);
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            SkinData.SaveAllSkinData();
            var settings = Properties.Settings.Default;
            MemoData.WriteMemo(settings.MemoFilePath, memoEdit.Text);
            CalendarData.WriteCalendar(settings.CalendarFilePath, MainSchedulerDataStorage);
        }

        private void OpenStatusEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => OpenStatusEditForm();

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
                AppointmentSettingData.LoadStatusData(MainScheduler.DataStorage.Appointments.Statuses);
            }
            catch
            {
                MessageBox.Show("Could not import Statuses file");
            }

            // Import Memo
            try
            {
                // First execute check
                if (string.IsNullOrEmpty(settings.MemoFilePath)) settings.MemoFilePath = $@"{Environment.CurrentDirectory}\Data\Memo.txt";
                else memoEdit.Text = await MemoData.ReadMemoAsync(settings.MemoFilePath);
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

        private void test()
        {
            //schedulerDataStorage1.Resources.LoadFromXml($@"{Environment.CurrentDirectory}\testresources.xml");
            //DataSet dataSet = new DataSet();
            //dataSet.ReadXml($@"{Environment.CurrentDirectory}\testresources.xml");
            //ResourcesTest resourcesTest = new ResourcesTest();
            //resourcesTest.SetDataSources(dataSet.Tables[0]);
            //resourcesTest.Show();

            //string[] IssueList = { "Consultation", "Treatment", "X-Ray" };
            //Color[] IssueColorList = { Color.Ivory, Color.Pink, Color.Plum };
            //string[] PaymentStatuses = { "Paid", "Unpaid" };
            //Color[] PaymentColorStatuses = { Color.Green, Color.Red };

            //IAppointmentLabelStorage labelStorage = schedulerControl1.DataStorage.Appointments.Labels;
            //var a = labelStorage.ToList();
            //var b = labelStorage.CreateNewLabel(1, "b", "b");
            //b.SetColor(Color.FromArgb(1, 2, 3, 4));
            //var c = b.GetColor();
            //labelStorage.Clear();
            //labeltest t = new labeltest();
            //t.LoadData(schedulerControl1.DataStorage.Appointments.Labels);

            //LabelTest labelTest = new LabelTest();
            //labelTest.SetDataSources(schedulerControl1.DataStorage.Appointments.Labels);
            //labelTest.ShowDialog();
        }
    }
}