using DevExpress.Data;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using PersonalPlanner.Data;
using PersonalPlanner.GUI.Forms;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PersonalPlanner.GUI.Frame
{
    public partial class MainFrame
    {
        /*-------------------------------------------
         *
         *      GUI
         *
         -------------------------------------------*/

        private void SetUIElements()
        {
            SetOverFlowButton();
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(SkinGalleryEdit);
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinPaletteGallery(SkinPaletteGalleryEdit);
            foreach (var item in SkinGalleryEdit.Properties.Gallery.GetAllItems())
            {
                if (item.Caption.Contains("Compact")) item.Visible = false;
            }

            NotificationsManager.ApplicationId = "f5722466-cb24-4a51-bea0-4ff54ccb3589";
            NotificationsManager.Notifications.AddRange(new DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties[] { new DevExpress.XtraBars.ToastNotifications.ToastNotification("e19225bd-06fe-4d2b-8598-76a2fac944b4", null, null, null, null, null, null, "", "", "", null, DevExpress.XtraBars.ToastNotifications.ToastNotificationSound.Default, DevExpress.XtraBars.ToastNotifications.ToastNotificationDuration.Long, null, DevExpress.XtraBars.ToastNotifications.AppLogoCrop.Default, DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.Generic) });
        }

        private void SetOverFlowButton()
        {
            bool isDarkMode = DevExpress.Utils.Frames.FrameHelper.IsDarkSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);

            string html = File.ReadAllText($@"{Application.StartupPath}\Assets\MainFrameOverFlowButton.html");
            string css = "";
            if (isDarkMode) css = File.ReadAllText($@"{Application.StartupPath}\Assets\MainFrameOverFlowButtonDarkMode.css");
            else css = File.ReadAllText($@"{Application.StartupPath}\Assets\MainFrameOverFlowButtonLightMode.css");

            Navigation.HtmlTemplates.FooterOverflowButton.Template = html;
            Navigation.HtmlTemplates.FooterOverflowButton.Styles = css;
        }

        private void LoadDatas()
        {
            MainScheduler = new SchedulerControl();
            MainSchedulerDataStorage = new SchedulerDataStorage(components);
            MainScheduler.DataStorage = MainSchedulerDataStorage;

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
            else this.Size = new Size(1280, 960);
            this.WindowState = GlobalData.Parameters.MainFrameWindowState;

            SkinGalleryEdit.EditValue = GlobalData.Parameters.SkinName;
            SkinPaletteGalleryEdit.EditValue = GlobalData.Parameters.SkinPaletteName;

            WorkingTimeStart.EditValue = GlobalData.Parameters.OfficeStart;
            WorkingTimeEnd.EditValue = GlobalData.Parameters.OfficeEnd;

            try
            {
                View.RestoreLayoutFromXml($@"{Application.StartupPath}\Data\Layout.xml");
            }
            catch
            { }
        }

        private void SaveUILayout()
        {
            if (this.WindowState != FormWindowState.Minimized) GlobalData.Parameters.MainFrameWindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                GlobalData.Parameters.MainFrameLocation = this.Location;
                GlobalData.Parameters.MainFrameSize = this.Size;
            }

            GlobalData.Parameters.IsCalendarShow = CalendarDoc != null ? true : false;
            GlobalData.Parameters.IsSchedulerShow = SchedulerDoc != null ? true : false;
            GlobalData.Parameters.SchedulerViewType = (int)MainScheduler.ActiveViewType;
            GlobalData.Parameters.WorktimeShow = MainScheduler.DayView.ShowWorkTimeOnly;

            View.SaveLayoutToXml($@"{Application.StartupPath}\Data\Layout.xml");
        }

        private void SetWorkingTime()
        {
            MainScheduler.DayView.WorkTime.Start = GlobalData.Parameters.OfficeStart;
            MainScheduler.WorkWeekView.WorkTime.Start = GlobalData.Parameters.OfficeStart;
            MainScheduler.FullWeekView.WorkTime.Start = GlobalData.Parameters.OfficeStart;
            MainScheduler.TimelineView.WorkTime.Start = GlobalData.Parameters.OfficeStart;

            MainScheduler.DayView.WorkTime.End = GlobalData.Parameters.OfficeEnd;
            MainScheduler.WorkWeekView.WorkTime.End = GlobalData.Parameters.OfficeEnd;
            MainScheduler.FullWeekView.WorkTime.End = GlobalData.Parameters.OfficeEnd;
            MainScheduler.TimelineView.WorkTime.End = GlobalData.Parameters.OfficeEnd;

            foreach (var ui in GanttUIs) ui.SetWorkTime();
        }

        /*-------------------------------------------
         *
         *      Widget
         *
         -------------------------------------------*/

        private bool ActivateWidget(Document doc)
        {
            // Activate widget
            if (View.Documents.Contains(doc)) View.Controller.Activate(doc);
            else return false;
            return true;
        }

        private void SetDocumentBorderColor(Document doc, Color color)
        {
            doc.AppearanceCaption.BackColor = color;
            doc.AppearanceCaption.BorderColor = color;
        }

        /*-------------------------------------------
         *
         *      Shortcut
         *
         -------------------------------------------*/

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