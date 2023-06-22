using DevExpress.XtraScheduler.UI;

namespace PersonalPlanner.GUI.Forms
{
    partial class AppointmentEditForm
    {

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentEditForm));
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            bvPrint = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            appointmentBackstageControl = new DevExpress.XtraScheduler.Design.AppointmentBackstageControl();
            bvtPrint = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            bvbSave = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            bvbSaveAs = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            bvbClose = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            btnSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            btnDelete = new DevExpress.XtraBars.BarButtonItem();
            barLabel = new DevExpress.XtraBars.BarEditItem();
            riAppointmentLabel = new RepositoryItemAppointmentLabel();
            barStatus = new DevExpress.XtraBars.BarEditItem();
            riAppointmentStatus = new RepositoryItemAppointmentStatus();
            barReminder = new DevExpress.XtraBars.BarEditItem();
            riDuration = new RepositoryItemDuration();
            btnRecurrence = new DevExpress.XtraBars.BarButtonItem();
            btnSave = new DevExpress.XtraBars.BarButtonItem();
            btnNext = new DevExpress.XtraBars.BarButtonItem();
            btnPrevious = new DevExpress.XtraBars.BarButtonItem();
            btnTimeZones = new DevExpress.XtraBars.BarButtonItem();
            rpAppointment = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            rpgOptions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            riAppointmentResource = new RepositoryItemAppointmentResource();
            lblStartTime = new DevExpress.XtraEditors.LabelControl();
            edtStartDate = new DevExpress.XtraEditors.DateEdit();
            tbLocation = new DevExpress.XtraEditors.TextEdit();
            edtStartTime = new DevExpress.XtraEditors.TimeEdit();
            lblEndTime = new DevExpress.XtraEditors.LabelControl();
            edtEndDate = new DevExpress.XtraEditors.DateEdit();
            edtEndTime = new DevExpress.XtraEditors.TimeEdit();
            lblLocation = new DevExpress.XtraEditors.LabelControl();
            panel1 = new DevExpress.XtraEditors.PanelControl();
            edtResource = new AppointmentResourceEdit();
            edtResources = new AppointmentResourcesEdit();
            edtTimeZone = new TimeZoneEdit();
            lblResource = new DevExpress.XtraEditors.LabelControl();
            chkAllDay = new DevExpress.XtraEditors.CheckEdit();
            tbSubject = new DevExpress.XtraEditors.TextEdit();
            tbProgress = new DevExpress.XtraEditors.TrackBarControl();
            lblPercentCompleteValue = new DevExpress.XtraEditors.LabelControl();
            lblPercentComplete = new DevExpress.XtraEditors.LabelControl();
            lblSubject = new DevExpress.XtraEditors.LabelControl();
            panelMain = new System.Windows.Forms.Panel();
            tbDescription = new DevExpress.XtraEditors.MemoEdit();
            panelDescription = new System.Windows.Forms.Panel();
            tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)backstageViewControl1).BeginInit();
            backstageViewControl1.SuspendLayout();
            bvPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)riAppointmentLabel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)riAppointmentStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)riDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)riAppointmentResource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbLocation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtStartTime.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtEndTime.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panel1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)edtResource.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtResources.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtResources.ResourcesCheckedListBoxControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)edtTimeZone.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkAllDay.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbSubject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbProgress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbProgress.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablePanel2).BeginInit();
            tablePanel2.SuspendLayout();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.ApplicationButtonDropDownControl = backstageViewControl1;
            ribbonControl1.AutoSizeItems = true;
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 32, 35, 32);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, ribbonControl1.SearchEditItem, btnSaveAndClose, btnDelete, barLabel, barStatus, barReminder, btnRecurrence, btnSave, btnNext, btnPrevious, btnTimeZones });
            resources.ApplyResources(ribbonControl1, "ribbonControl1");
            ribbonControl1.MaxItemId = 2;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsMenuMinWidth = 385;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { rpAppointment });
            ribbonControl1.QuickToolbarItemLinks.Add(btnSave);
            ribbonControl1.QuickToolbarItemLinks.Add(btnPrevious);
            ribbonControl1.QuickToolbarItemLinks.Add(btnNext);
            ribbonControl1.QuickToolbarItemLinks.Add(btnDelete);
            ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { riAppointmentLabel, riAppointmentResource, riAppointmentStatus, riDuration });
            ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            ribbonControl1.ApplicationButtonClick += ribbonControl1_ApplicationButtonClick;
            // 
            // backstageViewControl1
            // 
            backstageViewControl1.Controls.Add(bvPrint);
            backstageViewControl1.Items.Add(bvtPrint);
            backstageViewControl1.Items.Add(bvbSave);
            backstageViewControl1.Items.Add(bvbSaveAs);
            backstageViewControl1.Items.Add(bvbClose);
            resources.ApplyResources(backstageViewControl1, "backstageViewControl1");
            backstageViewControl1.Name = "backstageViewControl1";
            backstageViewControl1.Office2013StyleOptions.HeaderBackColor = System.Drawing.SystemColors.Control;
            backstageViewControl1.OwnerControl = ribbonControl1;
            backstageViewControl1.SelectedTab = bvtPrint;
            backstageViewControl1.SelectedTabIndex = 0;
            backstageViewControl1.Style = DevExpress.XtraBars.Ribbon.BackstageViewStyle.Office2013;
            backstageViewControl1.VisibleInDesignTime = true;
            // 
            // bvPrint
            // 
            bvPrint.Controls.Add(appointmentBackstageControl);
            resources.ApplyResources(bvPrint, "bvPrint");
            bvPrint.Name = "bvPrint";
            // 
            // appointmentBackstageControl
            // 
            resources.ApplyResources(appointmentBackstageControl, "appointmentBackstageControl");
            appointmentBackstageControl.Name = "appointmentBackstageControl";
            appointmentBackstageControl.PrintClick += schedulerPrint_PrintClick;
            appointmentBackstageControl.PrintOptionsClick += schedulerPrint_PrintOptionsClick;
            // 
            // bvtPrint
            // 
            resources.ApplyResources(bvtPrint, "bvtPrint");
            bvtPrint.ContentControl = bvPrint;
            bvtPrint.Name = "bvtPrint";
            bvtPrint.Selected = true;
            // 
            // bvbSave
            // 
            resources.ApplyResources(bvbSave, "bvbSave");
            bvbSave.Name = "bvbSave";
            bvbSave.ItemClick += bvbSave_ItemClick;
            // 
            // bvbSaveAs
            // 
            resources.ApplyResources(bvbSaveAs, "bvbSaveAs");
            bvbSaveAs.Name = "bvbSaveAs";
            bvbSaveAs.ItemClick += bvbSaveAs_ItemClick;
            // 
            // bvbClose
            // 
            resources.ApplyResources(bvbClose, "bvbClose");
            bvbClose.Name = "bvbClose";
            bvbClose.ItemClick += bvbClose_ItemClick;
            // 
            // btnSaveAndClose
            // 
            resources.ApplyResources(btnSaveAndClose, "btnSaveAndClose");
            btnSaveAndClose.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            btnSaveAndClose.Id = 3;
            btnSaveAndClose.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnSaveAndClose.ImageOptions.Image");
            btnSaveAndClose.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnSaveAndClose.ImageOptions.LargeImage");
            btnSaveAndClose.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSaveAndClose.ImageOptions.SvgImage");
            btnSaveAndClose.Name = "btnSaveAndClose";
            btnSaveAndClose.ItemClick += btnSaveAndClose_ItemClick;
            // 
            // btnDelete
            // 
            resources.ApplyResources(btnDelete, "btnDelete");
            btnDelete.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            btnDelete.Id = 4;
            btnDelete.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnDelete.ImageOptions.Image");
            btnDelete.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnDelete.ImageOptions.LargeImage");
            btnDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnDelete.ImageOptions.SvgImage");
            btnDelete.Name = "btnDelete";
            btnDelete.ItemClick += barButtonDelete_ItemClick;
            // 
            // barLabel
            // 
            resources.ApplyResources(barLabel, "barLabel");
            barLabel.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            barLabel.Edit = riAppointmentLabel;
            barLabel.Id = 8;
            barLabel.Name = "barLabel";
            // 
            // riAppointmentLabel
            // 
            resources.ApplyResources(riAppointmentLabel, "riAppointmentLabel");
            riAppointmentLabel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("riAppointmentLabel.Buttons")) });
            riAppointmentLabel.Name = "riAppointmentLabel";
            // 
            // barStatus
            // 
            resources.ApplyResources(barStatus, "barStatus");
            barStatus.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            barStatus.Edit = riAppointmentStatus;
            barStatus.Id = 11;
            barStatus.Name = "barStatus";
            // 
            // riAppointmentStatus
            // 
            resources.ApplyResources(riAppointmentStatus, "riAppointmentStatus");
            riAppointmentStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("riAppointmentStatus.Buttons")) });
            riAppointmentStatus.Name = "riAppointmentStatus";
            // 
            // barReminder
            // 
            resources.ApplyResources(barReminder, "barReminder");
            barReminder.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            barReminder.Edit = riDuration;
            barReminder.Id = 12;
            barReminder.Name = "barReminder";
            // 
            // riDuration
            // 
            resources.ApplyResources(riDuration, "riDuration");
            riDuration.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("riDuration.Buttons")) });
            riDuration.DisabledStateText = null;
            riDuration.Name = "riDuration";
            riDuration.ShowEmptyItem = true;
            // 
            // btnRecurrence
            // 
            btnRecurrence.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(btnRecurrence, "btnRecurrence");
            btnRecurrence.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            btnRecurrence.Id = 17;
            btnRecurrence.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnRecurrence.ImageOptions.Image");
            btnRecurrence.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnRecurrence.ImageOptions.LargeImage");
            btnRecurrence.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnRecurrence.ImageOptions.SvgImage");
            btnRecurrence.Name = "btnRecurrence";
            btnRecurrence.ItemClick += barRecurrence_ItemClick;
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            btnSave.Id = 1;
            btnSave.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnSave.ImageOptions.Image");
            btnSave.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnSave.ImageOptions.SvgImage");
            btnSave.Name = "btnSave";
            btnSave.ItemClick += btnSave_ItemClick;
            // 
            // btnNext
            // 
            resources.ApplyResources(btnNext, "btnNext");
            btnNext.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            btnNext.Id = 3;
            btnNext.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnNext.ImageOptions.Image");
            btnNext.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnNext.ImageOptions.LargeImage");
            btnNext.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnNext.ImageOptions.SvgImage");
            btnNext.Name = "btnNext";
            btnNext.ItemClick += btnNext_ItemClick;
            // 
            // btnPrevious
            // 
            resources.ApplyResources(btnPrevious, "btnPrevious");
            btnPrevious.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            btnPrevious.Id = 4;
            btnPrevious.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnPrevious.ImageOptions.Image");
            btnPrevious.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnPrevious.ImageOptions.LargeImage");
            btnPrevious.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnPrevious.ImageOptions.SvgImage");
            btnPrevious.Name = "btnPrevious";
            btnPrevious.ItemClick += btnPrevious_ItemClick;
            // 
            // btnTimeZones
            // 
            btnTimeZones.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(btnTimeZones, "btnTimeZones");
            btnTimeZones.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            btnTimeZones.Id = 1;
            btnTimeZones.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnTimeZones.ImageOptions.Image");
            btnTimeZones.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("btnTimeZones.ImageOptions.LargeImage");
            btnTimeZones.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnTimeZones.ImageOptions.SvgImage");
            btnTimeZones.Name = "btnTimeZones";
            btnTimeZones.ItemClick += btnTimeZones_ItemClick;
            // 
            // rpAppointment
            // 
            rpAppointment.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rpgActions, rpgOptions });
            rpAppointment.Name = "rpAppointment";
            resources.ApplyResources(rpAppointment, "rpAppointment");
            // 
            // rpgActions
            // 
            rpgActions.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            rpgActions.ItemLinks.Add(btnSaveAndClose);
            rpgActions.ItemLinks.Add(btnDelete);
            rpgActions.Name = "rpgActions";
            resources.ApplyResources(rpgActions, "rpgActions");
            // 
            // rpgOptions
            // 
            rpgOptions.AllowTextClipping = false;
            rpgOptions.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            rpgOptions.ItemLinks.Add(barLabel);
            rpgOptions.ItemLinks.Add(barStatus);
            rpgOptions.ItemLinks.Add(barReminder);
            rpgOptions.ItemLinks.Add(btnRecurrence, "C");
            rpgOptions.ItemLinks.Add(btnTimeZones);
            rpgOptions.Name = "rpgOptions";
            resources.ApplyResources(rpgOptions, "rpgOptions");
            // 
            // riAppointmentResource
            // 
            resources.ApplyResources(riAppointmentResource, "riAppointmentResource");
            riAppointmentResource.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("riAppointmentResource.Buttons")) });
            riAppointmentResource.Name = "riAppointmentResource";
            // 
            // lblStartTime
            // 
            resources.ApplyResources(lblStartTime, "lblStartTime");
            tablePanel1.SetColumn(lblStartTime, 0);
            lblStartTime.Name = "lblStartTime";
            tablePanel1.SetRow(lblStartTime, 3);
            // 
            // edtStartDate
            // 
            tablePanel1.SetColumn(edtStartDate, 2);
            resources.ApplyResources(edtStartDate, "edtStartDate");
            edtStartDate.Name = "edtStartDate";
            edtStartDate.Properties.AccessibleName = resources.GetString("edtStartDate.Properties.AccessibleName");
            edtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtStartDate.Properties.Buttons")) });
            edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            edtStartDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            tablePanel1.SetRow(edtStartDate, 3);
            // 
            // tbLocation
            // 
            tablePanel1.SetColumn(tbLocation, 2);
            tablePanel1.SetColumnSpan(tbLocation, 2);
            resources.ApplyResources(tbLocation, "tbLocation");
            tbLocation.Name = "tbLocation";
            tbLocation.Properties.AccessibleName = resources.GetString("tbLocation.Properties.AccessibleName");
            tablePanel1.SetRow(tbLocation, 1);
            // 
            // edtStartTime
            // 
            tablePanel1.SetColumn(edtStartTime, 3);
            resources.ApplyResources(edtStartTime, "edtStartTime");
            edtStartTime.Name = "edtStartTime";
            edtStartTime.Properties.AccessibleName = resources.GetString("edtStartTime.Properties.AccessibleName");
            edtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            edtStartTime.Properties.Mask.EditMask = resources.GetString("edtStartTime.Properties.Mask.EditMask");
            edtStartTime.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            tablePanel1.SetRow(edtStartTime, 3);
            // 
            // lblEndTime
            // 
            resources.ApplyResources(lblEndTime, "lblEndTime");
            tablePanel1.SetColumn(lblEndTime, 0);
            lblEndTime.Name = "lblEndTime";
            tablePanel1.SetRow(lblEndTime, 4);
            // 
            // edtEndDate
            // 
            tablePanel1.SetColumn(edtEndDate, 2);
            resources.ApplyResources(edtEndDate, "edtEndDate");
            edtEndDate.Name = "edtEndDate";
            edtEndDate.Properties.AccessibleName = resources.GetString("edtEndDate.Properties.AccessibleName");
            edtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtEndDate.Properties.Buttons")) });
            edtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            edtEndDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            tablePanel1.SetRow(edtEndDate, 4);
            // 
            // edtEndTime
            // 
            tablePanel1.SetColumn(edtEndTime, 3);
            resources.ApplyResources(edtEndTime, "edtEndTime");
            edtEndTime.Name = "edtEndTime";
            edtEndTime.Properties.AccessibleName = resources.GetString("edtEndTime.Properties.AccessibleName");
            edtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            edtEndTime.Properties.Mask.EditMask = resources.GetString("edtEndTime.Properties.Mask.EditMask");
            edtEndTime.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            tablePanel1.SetRow(edtEndTime, 4);
            // 
            // lblLocation
            // 
            resources.ApplyResources(lblLocation, "lblLocation");
            tablePanel1.SetColumn(lblLocation, 0);
            lblLocation.Name = "lblLocation";
            tablePanel1.SetRow(lblLocation, 1);
            // 
            // panel1
            // 
            panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            tablePanel1.SetColumn(panel1, 6);
            panel1.Controls.Add(edtResource);
            panel1.Controls.Add(edtResources);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            tablePanel1.SetRow(panel1, 1);
            // 
            // edtResource
            // 
            resources.ApplyResources(edtResource, "edtResource");
            edtResource.Name = "edtResource";
            edtResource.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            edtResource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtResource.Properties.Buttons")) });
            // 
            // edtResources
            // 
            resources.ApplyResources(edtResources, "edtResources");
            edtResources.Name = "edtResources";
            edtResources.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtResources.Properties.Buttons")) });
            // 
            // 
            // 
            edtResources.ResourcesCheckedListBoxControl.Location = (System.Drawing.Point)resources.GetObject("edtResources.ResourcesCheckedListBoxControl.Location");
            edtResources.ResourcesCheckedListBoxControl.Name = "";
            edtResources.ResourcesCheckedListBoxControl.TabIndex = (int)resources.GetObject("edtResources.ResourcesCheckedListBoxControl.TabIndex");
            // 
            // edtTimeZone
            // 
            tablePanel1.SetColumn(edtTimeZone, 4);
            tablePanel1.SetColumnSpan(edtTimeZone, 3);
            resources.ApplyResources(edtTimeZone, "edtTimeZone");
            edtTimeZone.MenuManager = ribbonControl1;
            edtTimeZone.Name = "edtTimeZone";
            edtTimeZone.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton((DevExpress.XtraEditors.Controls.ButtonPredefines)resources.GetObject("edtTimeZone.Properties.Buttons")) });
            tablePanel1.SetRow(edtTimeZone, 4);
            // 
            // lblResource
            // 
            resources.ApplyResources(lblResource, "lblResource");
            tablePanel1.SetColumn(lblResource, 4);
            lblResource.Name = "lblResource";
            tablePanel1.SetRow(lblResource, 1);
            // 
            // chkAllDay
            // 
            tablePanel1.SetColumn(chkAllDay, 4);
            tablePanel1.SetColumnSpan(chkAllDay, 3);
            resources.ApplyResources(chkAllDay, "chkAllDay");
            chkAllDay.Name = "chkAllDay";
            chkAllDay.Properties.AccessibleName = resources.GetString("chkAllDay.Properties.AccessibleName");
            chkAllDay.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            chkAllDay.Properties.AutoWidth = true;
            chkAllDay.Properties.Caption = resources.GetString("chkAllDay.Properties.Caption");
            tablePanel1.SetRow(chkAllDay, 3);
            // 
            // tbSubject
            // 
            tablePanel1.SetColumn(tbSubject, 2);
            tablePanel1.SetColumnSpan(tbSubject, 6);
            resources.ApplyResources(tbSubject, "tbSubject");
            tbSubject.Name = "tbSubject";
            tbSubject.Properties.AccessibleName = resources.GetString("tbSubject.Properties.AccessibleName");
            tablePanel1.SetRow(tbSubject, 0);
            // 
            // tbProgress
            // 
            tablePanel2.SetColumn(tbProgress, 0);
            resources.ApplyResources(tbProgress, "tbProgress");
            tbProgress.Name = "tbProgress";
            tbProgress.Properties.AutoSize = false;
            tbProgress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            tbProgress.Properties.Maximum = 100;
            tbProgress.Properties.ShowValueToolTip = true;
            tbProgress.Properties.TickFrequency = 10;
            tablePanel2.SetRow(tbProgress, 0);
            // 
            // lblPercentCompleteValue
            // 
            resources.ApplyResources(lblPercentCompleteValue, "lblPercentCompleteValue");
            lblPercentCompleteValue.Appearance.BackColor = (System.Drawing.Color)resources.GetObject("lblPercentCompleteValue.Appearance.BackColor");
            lblPercentCompleteValue.Appearance.Options.UseBackColor = true;
            tablePanel2.SetColumn(lblPercentCompleteValue, 1);
            lblPercentCompleteValue.Name = "lblPercentCompleteValue";
            tablePanel2.SetRow(lblPercentCompleteValue, 0);
            // 
            // lblPercentComplete
            // 
            resources.ApplyResources(lblPercentComplete, "lblPercentComplete");
            lblPercentComplete.Appearance.BackColor = (System.Drawing.Color)resources.GetObject("lblPercentComplete.Appearance.BackColor");
            lblPercentComplete.Appearance.Options.UseBackColor = true;
            tablePanel1.SetColumn(lblPercentComplete, 0);
            lblPercentComplete.Name = "lblPercentComplete";
            tablePanel1.SetRow(lblPercentComplete, 6);
            // 
            // lblSubject
            // 
            resources.ApplyResources(lblSubject, "lblSubject");
            tablePanel1.SetColumn(lblSubject, 0);
            lblSubject.Name = "lblSubject";
            tablePanel1.SetRow(lblSubject, 0);
            // 
            // panelMain
            // 
            resources.ApplyResources(panelMain, "panelMain");
            panelMain.Name = "panelMain";
            // 
            // tbDescription
            // 
            tablePanel1.SetColumn(tbDescription, 0);
            tablePanel1.SetColumnSpan(tbDescription, 8);
            resources.ApplyResources(tbDescription, "tbDescription");
            tbDescription.Name = "tbDescription";
            tbDescription.Properties.AccessibleName = resources.GetString("tbDescription.Properties.AccessibleName");
            tbDescription.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            tablePanel1.SetRow(tbDescription, 7);
            // 
            // panelDescription
            // 
            resources.ApplyResources(panelDescription, "panelDescription");
            panelDescription.Name = "panelDescription";
            // 
            // tablePanel1
            // 
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F) });
            tablePanel1.Controls.Add(tablePanel2);
            tablePanel1.Controls.Add(tbDescription);
            tablePanel1.Controls.Add(panel1);
            tablePanel1.Controls.Add(edtTimeZone);
            tablePanel1.Controls.Add(lblPercentComplete);
            tablePanel1.Controls.Add(lblSubject);
            tablePanel1.Controls.Add(lblResource);
            tablePanel1.Controls.Add(lblEndTime);
            tablePanel1.Controls.Add(chkAllDay);
            tablePanel1.Controls.Add(edtEndDate);
            tablePanel1.Controls.Add(lblStartTime);
            tablePanel1.Controls.Add(edtEndTime);
            tablePanel1.Controls.Add(tbSubject);
            tablePanel1.Controls.Add(lblLocation);
            tablePanel1.Controls.Add(edtStartDate);
            tablePanel1.Controls.Add(tbLocation);
            tablePanel1.Controls.Add(edtStartTime);
            resources.ApplyResources(tablePanel1, "tablePanel1");
            tablePanel1.Name = "tablePanel1";
            tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 16F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F) });
            // 
            // tablePanel2
            // 
            resources.ApplyResources(tablePanel2, "tablePanel2");
            tablePanel1.SetColumn(tablePanel2, 2);
            tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 20F) });
            tablePanel1.SetColumnSpan(tablePanel2, 6);
            tablePanel2.Controls.Add(tbProgress);
            tablePanel2.Controls.Add(lblPercentCompleteValue);
            tablePanel2.Name = "tablePanel2";
            tablePanel1.SetRow(tablePanel2, 6);
            tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F) });
            // 
            // OutlookAppointmentForm
            // 
            AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(backstageViewControl1);
            Controls.Add(tablePanel1);
            Controls.Add(ribbonControl1);
            Name = "OutlookAppointmentForm";
            Ribbon = ribbonControl1;
            ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)backstageViewControl1).EndInit();
            backstageViewControl1.ResumeLayout(false);
            bvPrint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)riAppointmentLabel).EndInit();
            ((System.ComponentModel.ISupportInitialize)riAppointmentStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)riDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)riAppointmentResource).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtStartDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbLocation.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtStartTime.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtEndDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtEndTime.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panel1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)edtResource.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtResources.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtResources.ResourcesCheckedListBoxControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)edtTimeZone.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkAllDay.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbSubject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbProgress.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbProgress).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tablePanel2).EndInit();
            tablePanel2.ResumeLayout(false);
            tablePanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpAppointment;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgActions;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgOptions;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarEditItem barLabel;
        private RepositoryItemAppointmentLabel riAppointmentLabel;
        private RepositoryItemAppointmentResource riAppointmentResource;
        private DevExpress.XtraBars.BarEditItem barStatus;
        private RepositoryItemAppointmentStatus riAppointmentStatus;
        private DevExpress.XtraBars.BarEditItem barReminder;
        private RepositoryItemDuration riDuration;
        private DevExpress.XtraBars.BarButtonItem btnRecurrence;
        protected DevExpress.XtraEditors.LabelControl lblStartTime;
        protected DevExpress.XtraEditors.DateEdit edtStartDate;
        protected DevExpress.XtraEditors.TextEdit tbLocation;
        protected DevExpress.XtraEditors.TimeEdit edtStartTime;
        protected DevExpress.XtraEditors.LabelControl lblEndTime;
        protected DevExpress.XtraEditors.DateEdit edtEndDate;
        protected DevExpress.XtraEditors.TimeEdit edtEndTime;
        protected DevExpress.XtraEditors.LabelControl lblLocation;
        protected DevExpress.XtraEditors.PanelControl panel1;
        protected DevExpress.XtraEditors.LabelControl lblResource;
        protected AppointmentResourceEdit edtResource;
        protected AppointmentResourcesEdit edtResources;
        protected DevExpress.XtraEditors.CheckEdit chkAllDay;
        protected DevExpress.XtraEditors.TextEdit tbSubject;
        protected DevExpress.XtraEditors.TrackBarControl tbProgress;
        protected DevExpress.XtraEditors.LabelControl lblPercentCompleteValue;
        protected DevExpress.XtraEditors.LabelControl lblPercentComplete;
        protected DevExpress.XtraEditors.LabelControl lblSubject;
        private System.Windows.Forms.Panel panelMain;
        protected DevExpress.XtraEditors.MemoEdit tbDescription;
        private System.Windows.Forms.Panel panelDescription;

        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvbSave;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvbSaveAs;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvbClose;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnNext;
        private DevExpress.XtraBars.BarButtonItem btnPrevious;
        private DevExpress.XtraBars.BarButtonItem btnTimeZones;
        private TimeZoneEdit edtTimeZone;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl bvPrint;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvtPrint;
        private DevExpress.XtraScheduler.Design.AppointmentBackstageControl appointmentBackstageControl;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
    }
}