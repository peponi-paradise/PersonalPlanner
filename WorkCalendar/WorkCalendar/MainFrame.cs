using DevExpress.LookAndFeel;
using DevExpress.XtraScheduler.iCalendar;
using System;
using System.IO;
using System.Windows.Forms;

namespace WorkCalendar
{
    public partial class MainFrame : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        private void ScheduleImportButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    iCalendarImporter calendarImporter = new iCalendarImporter(schedulerDataStorage1);
                    calendarImporter.Import(fileDialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Could not import calendar file");
                    return;
                }
                var settings = Properties.Settings.Default;
                settings.CalendarFilePath = fileDialog.FileName;
                settings.Save();
            }
        }

        private void ScheduleSaveButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "iCalendar (*.ics)|*.ics";
            saveFileDialog.DefaultExt = "ics";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    iCalendarExporter calendarExporter = new iCalendarExporter(schedulerDataStorage1);
                    calendarExporter.Export(saveFileDialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Could not save calendar file");
                    return;
                }
                var settings = Properties.Settings.Default;
                settings.CalendarFilePath = saveFileDialog.FileName;
                settings.Save();
            }
        }

        private void MemoImportButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var text = File.ReadAllText(fileDialog.FileName);
                memoEdit.Text = text;
                var settings = Properties.Settings.Default;
                settings.MemoFilePath = fileDialog.FileName;
                settings.Save();
            }
        }

        private void MemoSaveButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, memoEdit.Text);
                var settings = Properties.Settings.Default;
                settings.MemoFilePath = saveFileDialog.FileName;
                settings.Save();
            }
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            var settings = Properties.Settings.Default;
            settings.SkinName = UserLookAndFeel.Default.SkinName;
            settings.Palette = UserLookAndFeel.Default.ActiveSvgPaletteName;
            settings.Save();
            if (!string.IsNullOrEmpty(settings.MemoFilePath)) File.WriteAllText(settings.MemoFilePath, memoEdit.Text);
            if (!string.IsNullOrEmpty(settings.CalendarFilePath))
            {
                iCalendarExporter calendarExporter = new iCalendarExporter(schedulerDataStorage1);
                calendarExporter.Export(settings.CalendarFilePath);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            var settings = Properties.Settings.Default;
            if (!string.IsNullOrEmpty(settings.SkinName))
            {
                if (!string.IsNullOrEmpty(settings.Palette))
                    UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, settings.Palette);
                else UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, "DefaultSkinPalette");
            }
            try
            {
                if (!string.IsNullOrEmpty(settings.MemoFilePath)) memoEdit.Text = File.ReadAllText(settings.MemoFilePath);
            }
            catch
            {
                MessageBox.Show("Could not import memo file");
            }
            try
            {
                if (!string.IsNullOrEmpty(settings.CalendarFilePath))
                {
                    iCalendarImporter calendarImporter = new iCalendarImporter(schedulerDataStorage1);
                    calendarImporter.Import(settings.CalendarFilePath);
                }
            }
            catch
            {
                MessageBox.Show("Could not import calendar file");
            }
        }
    }
}