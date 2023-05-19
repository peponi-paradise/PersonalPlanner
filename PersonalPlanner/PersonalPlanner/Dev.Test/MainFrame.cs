using DevExpress.DocumentView.Controls;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using PersonalPlanner.Data;
using PersonalPlanner.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace PersonalPlanner.Dev.Test
{
    public partial class MainFrame : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public MainFrame()
        {
            InitializeComponent();

            LoadingForm.OpenDialog();
            LoadingForm.SetVersion(Assembly.GetExecutingAssembly().GetName().Version.ToString());

            SetSkin();
            LoadDatas();

            InitScheduler();
            InitMemos();
            InitGantts();

            CheckShortcut();
            SetUILayout();
            ConnectingUserEvents();

            LoadingForm.SetProgress("Program Start...");

            LoadingForm.CloseDialog();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Resize += MainFrame_Resized;
            this.Move += MainFrame_Move;
            this.FormClosing += MainFrame_FormClosing;

            NotificationsManager.UpdateToastContent += NotificationsManager_UpdateToastContent;
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
                SaveMemoWidgetStatus();
                SaveGanttWidgetStatus();
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

        private void View_DocumentClosing(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentCancelEventArgs e)
        {
            if (MemoDocs.Contains((Document)e.Document))
            {
                var widgetClose = new WidgetClose();
                if (XtraDialog.Show(widgetClose, "Close Memo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    switch (widgetClose.WidgetCloseMode)
                    {
                        case WidgetCloseMode.WidgetOnly:
                            RemoveMemoDoc((Document)e.Document);
                            break;

                        case WidgetCloseMode.WidgetAndData:
                            RemoveMemoDoc((Document)e.Document);
                            RemoveMemoData((Document)e.Document);
                            break;
                    }
                    MemoData.SaveData();
                }
                else e.Cancel = true;
            }
            if (GanttDocs.Contains((Document)e.Document))
            {
                var widgetClose = new WidgetClose();
                if (XtraDialog.Show(widgetClose, "Close Gantt", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    switch (widgetClose.WidgetCloseMode)
                    {
                        case WidgetCloseMode.WidgetOnly:
                            RemoveGanttDoc((Document)e.Document);
                            break;

                        case WidgetCloseMode.WidgetAndData:
                            RemoveGanttDoc((Document)e.Document);
                            RemoveGanttData((Document)e.Document);
                            break;
                    }
                    GanttData.SaveData();
                }
                else e.Cancel = true;
            }
        }

        private void View_DocumentClosed(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            if (e.Document == SchedulerDoc)
            {
                SchedulerDoc = null;
                InitSchedulerOnly();
            }
            else if (e.Document == CalendarDoc) CalendarDoc = null;
        }

        private void Navigation_ElementClicked(AccordionControlElement element, Point point)
        {
            if (GroupMemoLists.Elements.Contains(element)) ShowMemoContextMenu(element, point);
            else if (GroupGanttLists.Elements.Contains(element)) ShowGanttContextMenu(element, point);
        }

        private void SkinPaletteGallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            GlobalData.Parameters.SkinPaletteName = e.Item.Caption;
            SetOverFlowButton();
            ResetGanttWidgets();
        }

        private void SkinGallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            SkinGalleryEdit.EditValue = GlobalData.Parameters.SkinName = e.Item.Caption;
            SetOverFlowButton();
            ResetGanttWidgets();
        }

        private void WorkingTimeStart_EditValueChanged(object sender, System.EventArgs e)
        {
            GlobalData.Parameters.OfficeStart = (TimeSpan)WorkingTimeStart.EditValue;
            SetWorkingTime();
        }

        private void WorkingTimeEnd_EditValueChanged(object sender, System.EventArgs e)
        {
            GlobalData.Parameters.OfficeEnd = (TimeSpan)WorkingTimeEnd.EditValue;
            SetWorkingTime();
        }

        private void GroupSettingsHelpButton_Click(object sender, DevExpress.Utils.ContextItemClickEventArgs e)
        {
            List<GuideInformation> information = new List<GuideInformation>();
            var itemLocation = (Navigation.GetViewInfo() as AccordionControlViewInfo).GetElementInfo(GroupSettings).HeaderBounds.Location;
            information.Add(new GuideInformation() { Description = "Use this section for changing SW settings", TargetLocation = itemLocation });
            AdornerGuide guide = new AdornerGuide(information, this);
            guide.StartGuide();
        }

        private void ConnectingUserEvents()
        {
            Navigation.ElementClicked += Navigation_ElementClicked;
            View.DocumentClosing += View_DocumentClosing;
            View.DocumentClosed += View_DocumentClosed;

            Calendar.Click += CalendarLabel_Click;
            Calendar.ContextButtons[0].Click += CalendarShowButton_Click;
            Scheduler.Click += Scheduler_Click;
            Scheduler.ContextButtons[0].Click += SchedulerShowButton_Click;

            NewMemo.Click += NewMemo_Click;
            NewGantt.Click += NewGantt_Click;

            SkinGalleryEdit.Properties.Gallery.ItemClick += SkinGallery_ItemClick;
            SkinPaletteGalleryEdit.Properties.Gallery.ItemClick += SkinPaletteGallery_ItemClick;

            WorkingTimeStart.EditValueChanged += WorkingTimeStart_EditValueChanged;
            WorkingTimeEnd.EditValueChanged += WorkingTimeEnd_EditValueChanged;

            AppointmentLabel.ContextButtons[0].Click += AppointmentLabelButton_Click;
            AppointmentStatus.ContextButtons[0].Click += AppointmentStatusButton_Click;
            AppointmentResource.ContextButtons[0].Click += AppointmentResourceButton_Click;

            GroupSettings.ContextButtons[0].Click += GroupSettingsHelpButton_Click;
        }
    }
}