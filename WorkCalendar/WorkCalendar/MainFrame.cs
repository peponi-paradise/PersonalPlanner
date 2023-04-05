using DevExpress.LookAndFeel;
using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using WorkCalendar.Data;
using WorkCalendar.Dev.Test;
using WorkCalendar.GUI;
using WorkCalendar.Parser.YAML;

namespace WorkCalendar
{
    public partial class MainFrame : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainFrame()
        {
            InitializeComponent();
            schedulerControl1.Start = DateTime.Now;
        }

        private async void ScheduleImportButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await CalendarData.ReadCalendarAsync(fileDialog.FileName, schedulerDataStorage1);
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
                    await CalendarData.WriteCalendarAsync(saveFileDialog.FileName, schedulerDataStorage1);
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
            CalendarData.WriteCalendar(settings.CalendarFilePath, schedulerDataStorage1);
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.SuspendLayout();
            var settings = Properties.Settings.Default;
            if (!string.IsNullOrEmpty(settings.SkinName))
            {
                if (!string.IsNullOrEmpty(settings.Palette)) UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, settings.Palette);
                else UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, "DefaultSkinPalette");
            }

            // Import Memo
            try
            {
                // First execute check
                if (string.IsNullOrEmpty(settings.MemoFilePath)) settings.MemoFilePath = $@"{Environment.CurrentDirectory}\Memo.txt";
                else memoEdit.Text = await MemoData.ReadMemoAsync(settings.MemoFilePath);
            }
            catch
            {
                MessageBox.Show("Could not import memo file");
            }

            // Import Calendar
            try
            {
                if (string.IsNullOrEmpty(settings.CalendarFilePath)) settings.CalendarFilePath = $@"{Environment.CurrentDirectory}\Calendar.ics";
                //await CalendarData.ReadCalendarAsync(settings.CalendarFilePath, schedulerDataStorage1);
                CalendarData.ReadCalendar(settings.CalendarFilePath, schedulerDataStorage1);
            }
            catch
            {
                MessageBox.Show("Could not import calendar file");
            }
            this.ResumeLayout(false);

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

            var data = schedulerControl1.DataStorage.Appointments.Statuses;
            var a = data.CreateNewStatus(1, "a", "a");
            var brush = new HatchBrush(HatchStyle.Horizontal, Color.Red);
            a.SetBrush(brush);

            StatusTest statusTest = new();
            statusTest.SetDataSources(schedulerControl1.DataStorage.Appointments.Statuses);
            statusTest.ShowDialog();
        }
    }

    public class labeltest : IYAML
    {
        public class nested
        {
            public int A = 0, R = 0, G = 0, B = 0;
            public object Id = 0;
            public string DisplayName = "";
        }

        public List<nested> appointmentLabels;

        public bool LoadData()
        {
            YAMLParser.LoadData($@"{Environment.CurrentDirectory}\labeltest.yaml", out List<nested> appointmentLabels);
            this.appointmentLabels = appointmentLabels;
            return true;
        }

        public void LoadData(IAppointmentLabelStorage labelStorage)
        {
            YAMLParser.LoadData($@"{Environment.CurrentDirectory}\labeltest.yaml", out List<nested> appointmentLabels);
            this.appointmentLabels = appointmentLabels;
            labelStorage.Clear();
            foreach (var item in appointmentLabels)
            {
                var label = labelStorage.CreateNewLabel(item.Id, item.DisplayName, item.DisplayName);
                label.SetColor(Color.FromArgb(item.A, item.R, item.G, item.B));
                labelStorage.Add(label);
            }
        }

        public void SaveData()
        {
            YAMLParser.SaveData($@"{Environment.CurrentDirectory}\labeltest.yaml", appointmentLabels);
        }

        public void SaveData(IAppointmentLabelStorage labelStorage)
        {
            appointmentLabels.Clear();
            foreach (var item in labelStorage)
            {
                var data = new nested() { Id = item.Id, DisplayName = item.DisplayName, A = item.GetColor().A, R = item.GetColor().R, G = item.GetColor().G, B = item.GetColor().B };
                appointmentLabels.Add(data);
            }
            YAMLParser.SaveData($@"{Environment.CurrentDirectory}\labeltest.yaml", appointmentLabels);
        }
    }

    public class statustest : IYAML
    {
        public enum PaintStyle
        {
            Solid = 0,
            Hatch = 1,
        }

        public class nested
        {
            public int A = 0, R = 0, G = 0, B = 0;
            public PaintStyle PaintStyle;
            public HatchStyle HatchStyle;
            public object Id = 0;
            public string DisplayName = "";
        }

        public List<nested> Statuses;

        public bool LoadData()
        {
            YAMLParser.LoadData($@"{Environment.CurrentDirectory}\statustest.yaml", out List<nested> statuses);
            Statuses = statuses;
            return true;
        }

        public void SaveData()
        {
            YAMLParser.SaveData($@"{Environment.CurrentDirectory}\statustest.yaml", Statuses);
        }
    }
}