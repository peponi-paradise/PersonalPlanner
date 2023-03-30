using DevExpress.LookAndFeel;
using System;
using System.Windows.Forms;
using WorkCalendar.Data;

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
                    await CalendarData.ReadCalendar(fileDialog.FileName, schedulerDataStorage1);
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
                    await CalendarData.WriteCalendar(saveFileDialog.FileName, schedulerDataStorage1);
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
            if (fileDialog.ShowDialog() == DialogResult.OK) memoEdit.Text = await MemoData.ReadMemo(fileDialog.FileName);
        }

        private async void MemoSaveButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) await MemoData.WriteMemo(saveFileDialog.FileName, memoEdit.Text);
        }

        private async void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            await SkinData.SaveAllSkinData();
            var settings = Properties.Settings.Default;
            await MemoData.WriteMemo(settings.MemoFilePath, memoEdit.Text);
            await CalendarData.WriteCalendar(settings.CalendarFilePath, schedulerDataStorage1);
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
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
                else memoEdit.Text = await MemoData.ReadMemo(settings.MemoFilePath);
            }
            catch
            {
                MessageBox.Show("Could not import memo file");
            }

            // Import Calendar
            try
            {
                if (string.IsNullOrEmpty(settings.CalendarFilePath)) settings.CalendarFilePath = $@"{Environment.CurrentDirectory}\Calendar.ics";
                else await CalendarData.ReadCalendar(settings.CalendarFilePath, schedulerDataStorage1);
            }
            catch
            {
                MessageBox.Show("Could not import calendar file");
            }
        }
    }
}