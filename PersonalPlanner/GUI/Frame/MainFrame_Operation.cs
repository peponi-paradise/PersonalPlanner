using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using PersonalPlanner.Data;
using PersonalPlanner.Define;
using PersonalPlanner.GUI.Forms;
using PersonalPlanner.Utility.GUI;
using PersonalPlanner.Utility.Windows;
using System;
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
            UserLookAndFeel.Default.StyleChanged += SkinChanged;
            foreach (var item in SkinGalleryEdit.Properties.Gallery.GetAllItems())
            {
                if (item.Caption.Contains("Compact")) item.Visible = false;
            }

            InitNotification();
        }

        private void SkinChanged(object sender, System.EventArgs e) => SetOverFlowButton();

        private void SetOverFlowButton()
        {
            bool isDarkMode = DevExpress.Utils.Frames.FrameHelper.IsDarkSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);

            string html = File.ReadAllText($@"{Application.StartupPath}\Assets\MainFrameOverFlowButton.html");
            string css = "";
            if (isDarkMode) css = File.ReadAllText($@"{Application.StartupPath}\Assets\MainFrameOverFlowButtonDarkMode.css");
            else css = File.ReadAllText($@"{Application.StartupPath}\Assets\MainFrameOverFlowButtonLightMode.css");

            Navigation.HtmlTemplates.FooterOverflowButton.Template = html;
            Navigation.HtmlTemplates.FooterOverflowButton.Styles = css;
            Navigation.Update();
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

        private void SetDocumentBorderColor(Document doc, System.Drawing.Color color)
        {
            doc.AppearanceCaption.BackColor = color;
            doc.AppearanceCaption.BorderColor = color;
        }

        /*-------------------------------------------
         *
         *      Notification
         *
         -------------------------------------------*/

        private void InitNotification()
        {
            NotificationData = new NotificationData()
            {
                Title = "Personal Planner",
                TitleImageSource = ImageCollection["ShortDate"],
                TitlePinImageSource = ImageCollection["UnpinButton"],
                TitleCloseImageSource = ImageCollection["Delete"],
                Caption = "Caption",
                DescriptionImageSource = ImageCollection["ShortDate"],
                Description1 = "Description1",
                Description2 = "Description2",
                FooterUrl1 = "https://github.com/peponi-paradise/",
                FooterUrl2 = "https://peponi-paradise.tistory.com/",
                Copyright = $"©ClockStrikes, {DateTime.Now.Year}",
            };
            NotificationWindow.BeforeFormShow += NotificationWindow_BeforeFormShow;
            NotificationWindow.HtmlElementMouseClick += NotificationWindow_HtmlElementMouseClick;
            NotificationWindow.FormClosing += NotificationWindow_FormClosing;
            NotificationWindow.HtmlTemplate.Template += File.ReadAllText($@"{Application.StartupPath}\Assets\Notification.html");
            NotificationWindow.HtmlTemplate.Styles += File.ReadAllText($@"{Application.StartupPath}\Assets\Notification.css");
        }

        private void NotificationWindow_FormClosing(object sender, DevExpress.XtraBars.Alerter.AlertFormClosingEventArgs e)
        {
            NotificationData.TitlePinImageSource = ImageCollection["UnpinButton"];
        }

        private void NotificationWindow_HtmlElementMouseClick(object sender, DevExpress.XtraBars.Alerter.AlertHtmlElementMouseEventArgs e)
        {
            if (e.ElementId == "pinButton")
            {
                e.HtmlPopup.Pinned = !e.HtmlPopup.Pinned;
                if (e.HtmlPopup.Pinned) NotificationData.TitlePinImageSource = ImageCollection["PinButton"];
                else NotificationData.TitlePinImageSource = ImageCollection["UnpinButton"];
            }
            else if (e.ElementId == "closeButton") e.HtmlPopup.Close();
        }

        private void NotificationWindow_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            e.HtmlPopup.DataContext = NotificationData;
        }
    }
}