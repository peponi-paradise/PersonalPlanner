using DevExpress.Data;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using PersonalPlanner.Data;
using PersonalPlanner.GUI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

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

            LoadingForm.OpenDialog();
            LoadingForm.SetVersion(Assembly.GetExecutingAssembly().GetName().Version.ToString());

            LoadDatas();
            CheckShortcut();
            SetUILayout();

            LoadingForm.CloseDialog();
        }

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);

            foreach (GalleryItem item in skinRibbonGalleryBarItem1.Gallery.GetAllItems())
            {
                if (item.Caption.Contains("Compact")) item.Visible = false;
            }
            this.Resize += MainFrame_Resized;
            this.Move += MainFrame_Move;
            this.FormClosing += MainFrame_FormClosing;
            MainRibbonControl.MouseWheel += MainRibbonControl_MouseWheel;
            NotificationsManager.UpdateToastContent += NotificationsManager_UpdateToastContent;
            if (ShellHelper.IsApplicationShortcutExist(Application.ProductName)) ShortcutPageGroup.Visible = false;

            if (GlobalData.Parameters.MemoFormShowOnStartUp) OpenMemoForm();
            if (GlobalData.Parameters.GanttFormShowOnStartUp) OpenGanttForm();
        }

        private void NotificationsManager_UpdateToastContent(object sender, DevExpress.XtraBars.ToastNotifications.UpdateToastContentEventArgs e)
        {
            XmlDocument doc = e.ToastContent;
            XmlNode bindingNode = doc.GetElementsByTagName("binding").Item(0);
            if (bindingNode != null)
            {
                XmlElement group = doc.CreateElement("group");
                bindingNode.AppendChild(group);

                XmlElement subGroup = doc.CreateElement("subgroup");
                group.AppendChild(subGroup);

                XmlElement text = doc.CreateElement("text");
                subGroup.AppendChild(text);
                text.SetAttribute("hint-style", "base");
                text.InnerText = "https://github.com/peponi-paradise";

                text = doc.CreateElement("text");
                subGroup.AppendChild(text);
                text.SetAttribute("hint-style", "captionSubtle");
                text.InnerText = "https://peponi-paradise.tistory.com/";
            }
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
            if (this.WindowState != FormWindowState.Minimized) GlobalData.Parameters.MainFrameSize = this.Size;
        }

        private void MainFrame_Move(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized) GlobalData.Parameters.MainFrameLocation = this.Location;
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            WaitForm.OpenDialog("Closing...", "Saving datas...");
            try
            {
                GlobalData.SaveData();
                MemoData.SaveData();
                CalendarData.WriteCalendar(MainSchedulerDataStorage);
                GanttData.SaveData();
                SaveUILayout();
            }
            finally
            {
                WaitForm.CloseDialog();
            }
        }

        private void MainRibbonControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.X > splitContainerControlCalendar.Location.X && e.X < splitContainerControlCalendar.Location.X + splitContainerControlCalendar.Width &&
                e.Y > splitContainerControlCalendar.Location.Y && e.Y < splitContainerControlCalendar.Location.Y + splitContainerControlCalendar.Height)
            {
                return;
            }
            else
            {
                DXMouseEventArgs.GetMouseArgs(e).Handled = true;
            }
        }

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
            GlobalData.Parameters.OfficeStart = (TimeSpan)WorkTimeStart.EditValue;
            SetWorkTime();
        }

        private void WorkTimeEnd_EditValueChanged(object sender, EventArgs e)
        {
            GlobalData.Parameters.OfficeEnd = (TimeSpan)WorkTimeEnd.EditValue;
            SetWorkTime();
        }

        private async void ScheduleImportButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await CalendarData.ReadCalendarAsync(MainSchedulerDataStorage, fileDialog.FileName);
                    MainSchedulerDataStorage.RefreshData(true);
                }
                catch
                {
                    XtraMessageBox.Show("Could not import calendar file");
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
                    await CalendarData.WriteCalendarAsync(MainSchedulerDataStorage, saveFileDialog.FileName);
                }
                catch
                {
                    XtraMessageBox.Show("Could not save calendar file");
                    return;
                }
            }
        }

        // 당분간 제거. 메모 윈도우로 가자
        private async void MemoImportButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                await MemoData.LoadDataAsync(fileDialog.FileName);
                //if (MemoForm.Visible) MemoForm.SetMemos();
            }
        }

        // 당분간 제거. 메모 윈도우로 가자
        private async void MemoSaveButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "YAML file (*.yaml)|*.yaml";
            saveFileDialog.DefaultExt = "yaml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) await MemoData.SaveDataAsync(saveFileDialog.FileName);
        }

        private void MemoFormShow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => GlobalData.Parameters.MemoFormShowOnStartUp = MemoFormShow.Checked;

        private void GanttFormShow_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => GlobalData.Parameters.GanttFormShowOnStartUp = GanttFormShow.Checked;

        private void skinRibbonGalleryBarItem1_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            if (GanttForm != null && GanttForm.Visible)
            {
                XtraMessageBox.Show("Close Gantt window for changing skin");
                GanttForm.Close();
            }
            GlobalData.Parameters.SkinName = e.Item.Caption;
            GlobalData.Parameters.SkinPaletteName = "DefaultSkinPalette";
            UserLookAndFeel.Default.SetSkinStyle(GlobalData.Parameters.SkinName, "DefaultSkinPalette");
        }

        private void skinPaletteRibbonGalleryBarItem1_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            if (GanttForm != null && GanttForm.Visible)
            {
                XtraMessageBox.Show("Close Gantt window for changing skin");
                GanttForm.Close();
            }
            GlobalData.Parameters.SkinPaletteName = e.Item.Caption;
            UserLookAndFeel.Default.SetSkinStyle(GlobalData.Parameters.SkinName, GlobalData.Parameters.SkinPaletteName);
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

        private void AddShortcutButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var rtn = XtraMessageBox.Show("This work will create shortcut on start menu\nProceed?", "Add application shortcut", MessageBoxButtons.OKCancel);
            GlobalData.Parameters.CheckApplicationShortcut = true;
            if (rtn == DialogResult.OK) AddShortcut();
        }

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        private void LoadDatas()
        {
            LoadingForm.SetProgress("Loading Environments...");
            // Import Environments
            try
            {
                GlobalData.LoadData();
            }
            catch
            {
                XtraMessageBox.Show("Could not import Global setting");
            }
            try
            {
                AppointmentSettingData.LoadLabelData(MainScheduler.DataStorage.Appointments.Labels);
            }
            catch
            {
                XtraMessageBox.Show("Could not import Label file");
            }

            try
            {
                AppointmentSettingData.LoadStatusData(MainScheduler.DataStorage.Appointments.Statuses);
            }
            catch
            {
                XtraMessageBox.Show("Could not import Status file");
            }

            try
            {
                AppointmentSettingData.LoadResourceData(MainSchedulerDataStorage.Resources);
            }
            catch
            {
                XtraMessageBox.Show("Could not import Resource file");
            }
            LoadingForm.SetProgress("Loading Environments Done...");

            LoadingForm.SetProgress("Loading Memos...");
            // Import Memo
            try
            {
                MemoData.LoadData();
            }
            catch
            {
                XtraMessageBox.Show("Could not import memo file");
            }
            LoadingForm.SetProgress("Loading Memos Done...");

            LoadingForm.SetProgress("Loading Calendar...");
            // Import Calendar
            try
            {
                CalendarData.ReadCalendar(MainSchedulerDataStorage);
            }
            catch
            {
                XtraMessageBox.Show("Could not import calendar file");
            }
            MainSchedulerDataStorage.RefreshData(true);
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
            UserLookAndFeel.Default.SetSkinStyle(GlobalData.Parameters.SkinName, GlobalData.Parameters.SkinPaletteName);
            LoadingForm.SetProgress("Set Skin Done...");

            LoadingForm.SetProgress("Program Start...");
        }

        private void OpenMemoForm()
        {
            if (MemoForm != null) { MemoData.SaveData(); MemoForm.Close(); }
            MemoForm = new MemoForm();
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
            MainScheduler.DayView.WorkTime.Start = GlobalData.Parameters.OfficeStart;
            MainScheduler.WorkWeekView.WorkTime.Start = GlobalData.Parameters.OfficeStart;
            MainScheduler.FullWeekView.WorkTime.Start = GlobalData.Parameters.OfficeStart;
            MainScheduler.TimelineView.WorkTime.Start = GlobalData.Parameters.OfficeStart;

            MainScheduler.DayView.WorkTime.End = GlobalData.Parameters.OfficeEnd;
            MainScheduler.WorkWeekView.WorkTime.End = GlobalData.Parameters.OfficeEnd;
            MainScheduler.FullWeekView.WorkTime.End = GlobalData.Parameters.OfficeEnd;
            MainScheduler.TimelineView.WorkTime.End = GlobalData.Parameters.OfficeEnd;

            if (GanttForm != null && GanttForm.Visible) GanttForm.SetWorkTime();
        }

        private void SetUILayout()
        {
            if (GlobalData.Parameters.MainFrameLocation == new Point(0, 0)) this.StartPosition = FormStartPosition.CenterScreen;
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = GlobalData.Parameters.MainFrameLocation;
            }
            if (GlobalData.Parameters.MainFrameSize != new Size(0, 0)) this.Size = GlobalData.Parameters.MainFrameSize;

            MemoFormShow.Checked = GlobalData.Parameters.MemoFormShowOnStartUp;
            GanttFormShow.Checked = GlobalData.Parameters.GanttFormShowOnStartUp;

            MainScheduler.GoToToday();
            MainScheduler.DayView.ShowWorkTimeOnly = GlobalData.Parameters.DayViewWorktimeShow;
            MainScheduler.WorkWeekView.ShowWorkTimeOnly = GlobalData.Parameters.WorkweekViewWorktimeShow;
            MainScheduler.FullWeekView.ShowWorkTimeOnly = GlobalData.Parameters.FullweekViewWorktimeShow;
            MainScheduler.ActiveViewType = (DevExpress.XtraScheduler.SchedulerViewType)GlobalData.Parameters.SchedulerViewType;
            WorkTimeStart.EditValue = GlobalData.Parameters.OfficeStart;
            WorkTimeEnd.EditValue = GlobalData.Parameters.OfficeEnd;
            SetWorkTime();

            AppointmentGroupSelector.EditValue = 0;
            MainScheduler.OptionsView.ResourceCategories.ResourceDisplayStyle = DevExpress.XtraScheduler.ResourceDisplayStyle.Tabs;
            MainScheduler.OptionsView.ResourceCategories.ShowCloseButton = true;
            MainScheduler.RemindersFormShowing += MainScheduler_RemindersFormShowing;
        }

        private void SaveUILayout()
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                GlobalData.Parameters.MainFrameLocation = this.Location;
                GlobalData.Parameters.MainFrameSize = this.Size;
            }
            if (MemoForm != null && MemoForm.Visible && MemoForm.WindowState != FormWindowState.Minimized) { GlobalData.Parameters.MemoFormLocation = MemoForm.Location; GlobalData.Parameters.MemoFormSize = MemoForm.Size; }
            if (GanttForm != null && GanttForm.Visible && GanttForm.WindowState != FormWindowState.Minimized) { GlobalData.Parameters.GanttFormLocation = GanttForm.Location; GlobalData.Parameters.GanttFormSize = GanttForm.Size; }

            GlobalData.Parameters.SchedulerViewType = (int)MainScheduler.ActiveViewType;
            GlobalData.Parameters.DayViewWorktimeShow = MainScheduler.DayView.ShowWorkTimeOnly;
            GlobalData.Parameters.WorkweekViewWorktimeShow = MainScheduler.WorkWeekView.ShowWorkTimeOnly;
            GlobalData.Parameters.FullweekViewWorktimeShow = MainScheduler.FullWeekView.ShowWorkTimeOnly;
        }

        private void CheckShortcut()
        {
            if (!GlobalData.Parameters.CheckApplicationShortcut)
            {
                if (!ShellHelper.IsApplicationShortcutExist(Application.ProductName))
                {
                    var rtn = XtraMessageBox.Show("Need to create shortcut on start menu\nif you want to get windows notification.\nProceed?", "Add application shortcut", MessageBoxButtons.OKCancel);
                    GlobalData.Parameters.CheckApplicationShortcut = true;
                    if (rtn == DialogResult.OK) AddShortcut();
                    else
                    {
                        XtraMessageBox.Show("You can create shortcut manually or via application menu", "Add application shortcut");
                    }
                }
            }
        }

        private void AddShortcut()
        {
            ShellHelper.TryCreateShortcut(
                            applicationId: NotificationsManager.ApplicationId,
                            name: Application.ProductName);
            XtraMessageBox.Show("Application will restart automatically", "Work done");
            Program.Mutex.ReleaseMutex();
            Process.Start(Application.ExecutablePath);
            Process.GetCurrentProcess().Kill();
        }
    }
}