﻿using DevExpress.Data;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using PersonalPlanner.Data;
using PersonalPlanner.GUI.Forms;
using PersonalPlanner.Utility.GUI;
using PersonalPlanner.Utility.Windows;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
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
            this.Text = $"Personal Planner by ClockStrikes. Ver: {Assembly.GetExecutingAssembly().GetName().Version}";
            SetOverFlowButton();
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(SkinGalleryEdit);
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinPaletteGallery(SkinPaletteGalleryEdit);
            foreach (var item in SkinGalleryEdit.Properties.Gallery.GetAllItems())
            {
                if (item.Caption.Contains("Compact")) item.Visible = false;
            }

            NotificationsManager = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            NotificationsManager.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.False;
            NotificationsManager.ApplicationId = "bc39c8f2-c49c-4eee-9f2c-9326fa2ab3bc";
            NotificationsManager.Notifications.Add(new DevExpress.XtraBars.ToastNotifications.ToastNotification("ee091f24-ae4c-4f95-8ad1-73e17f8f4076", null, null, null, null, null, null, "", "", "", null, DevExpress.XtraBars.ToastNotifications.ToastNotificationSound.Default, DevExpress.XtraBars.ToastNotifications.ToastNotificationDuration.Long, null, DevExpress.XtraBars.ToastNotifications.AppLogoCrop.Default, DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.Generic));
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

        private void CheckSkinPaletteColor()
        {
            if (string.IsNullOrEmpty(GlobalData.Parameters.SkinPaletteName))
            {
                if (WindowThemeColor.IsDarkTheme()) GlobalData.Parameters.SkinPaletteName = "Darkness";
                else GlobalData.Parameters.SkinPaletteName = "Freshness";
            }
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

            UserLookAndFeel.Default.SetSkinStyle(GlobalData.Parameters.SkinName, GlobalData.Parameters.SkinPaletteName);

            SkinGalleryEdit.SelectedText = GlobalData.Parameters.SkinName;
            SkinPaletteGalleryEdit.SelectedText = GlobalData.Parameters.SkinPaletteName;

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
            if (View.Documents.Contains(doc))
            {
                WidgetFlickeringEffect.Flickering(doc);
                View.Controller.Activate(doc);
                return true;
            }
            else return false;
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
            if (!ShellHelper.IsApplicationShortcutExist(Application.ProductName))
            {
                AddShortcut();
                ShortcutAdded = true;
            }
        }

        private void AddShortcut()
        {
            ShellHelper.TryCreateShortcut(
                            applicationId: NotificationsManager.ApplicationId,
                            name: Application.ProductName);
        }

        private void RestartSW()
        {
            XtraMessageBox.Show("Initial settings done.\r\nClick OK to continue...", "Restart SW");
            Process.Start(Application.StartupPath + "WatchDog.exe", new string[] { Process.GetCurrentProcess().Id.ToString(), Application.ExecutablePath });
            Application.Exit();
        }
    }
}