using DevExpress.XtraEditors;
using PersonalPlanner.Data;
using PersonalPlanner.Define;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalPlanner.GUI
{
    public partial class GanttForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        public GanttForm()
        {
            InitializeComponent();
            InitialDraw();
            MainControl.SelectedPageChanged += MainControl_SelectedPageChanged;
            this.FormClosing += GanttForm_FormClosing;
            this.Move += GanttForm_Move;
            this.Resize += GanttForm_Resize;
        }

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        private void GanttForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized) GlobalData.Parameters.GanttFormSize = this.Size;
        }

        private void GanttForm_Move(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized) GlobalData.Parameters.GanttFormLocation = this.Location;
        }

        private void GanttForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalData.Parameters.GanttFormLocation = this.Location;
            GlobalData.Parameters.GanttFormSize = this.Size;
        }

        private void MainControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (MainControl.SelectedTabPage != null)
            {
                TabColor.EditValue = (MainControl.SelectedTabPage as GanttUI).GanttData.Color.ToDrawingColor();
                (MainControl.SelectedTabPage as GanttUI).ExpandAllNodes();
            }
        }

        private void GanttUI_GanttDataSave() => GanttData.SaveDataAsync();

        private void NewGantt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var rtnName = XtraInputBox.Show("Please Input Name", "New Chart", "Name");
            if (rtnName != null)
            {
                var checkItem = GanttData.GanttDatas.Find(item => item.Name.Equals(rtnName));
                if (checkItem == default)
                {
                    var chart = new GanttDefine() { Name = rtnName };
                    GanttData.GanttDatas.Add(chart);
                    GanttUI ganttUI = new GanttUI(chart);
                    ganttUI.GanttDataSave += GanttUI_GanttDataSave;
                    MainControl.TabPages.Add(ganttUI);
                    MainControl.SelectedTabPage = ganttUI;
                    SaveAndUpdate();
                }
                else
                {
                    XtraMessageBox.Show($"Could not make duplicated name of chart : {rtnName}");
                }
            }
        }

        private void RemoveGantt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainControl.SelectedTabPage != null)
            {
                if (XtraMessageBox.Show($"Do you want to remove chart? : {MainControl.SelectedTabPage.Text}", "Remove chart", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var removeItem = (MainControl.SelectedTabPage as GanttUI).GanttData;
                    GanttData.GanttDatas.Remove(removeItem);
                    MainControl.TabPages.Remove(MainControl.SelectedTabPage);
                    SaveAndUpdate();
                }
            }
        }

        private void TabColor_EditValueChanged(object sender, EventArgs e)
        {
            if (MainControl.SelectedTabPage != null)
            {
                var ganttPage = MainControl.SelectedTabPage as GanttUI;
                ganttPage.ChangeTabPageColor((System.Drawing.Color)TabColor.EditValue);
                SaveAndUpdate();
            }
        }

        private void NewTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainControl.SelectedTabPage != null)
            {
                var input = XtraInputBox.Show("Input new Item's Name", "New Item", "New Name");
                if (input != null)
                {
                    var ID = (MainControl.SelectedTabPage as GanttUI).GanttData.Task.Count + 1;
                    Task task = new Task() { ID = ID, Name = input };
                    if ((MainControl.SelectedTabPage as GanttUI).AddTask(task)) SaveAndUpdate();
                }
            }
        }

        private void RemoveTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainControl.SelectedTabPage != null)
            {
                if ((MainControl.SelectedTabPage as GanttUI).RemoveTask()) SaveAndUpdate();
            }
        }

        private void ZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainControl.SelectedTabPage != null) (MainControl.SelectedTabPage as GanttUI).ZoomIn();
        }

        private void ZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainControl.SelectedTabPage != null) (MainControl.SelectedTabPage as GanttUI).ZoomOut();
        }

        private void ZoomReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MainControl.SelectedTabPage != null) (MainControl.SelectedTabPage as GanttUI).ZoomReset();
        }

        private void ChartViewStart_EditValueChanged(object sender, EventArgs e)
        {
            if (MainControl.SelectedTabPage != null && ChartViewStart.EditValue != null) (MainControl.SelectedTabPage as GanttUI).SetViewStartDate((DateTime)ChartViewStart.EditValue);
        }

        private void ChartViewFinish_EditValueChanged(object sender, EventArgs e)
        {
            if (MainControl.SelectedTabPage != null && ChartViewFinish.EditValue != null) (MainControl.SelectedTabPage as GanttUI).SetViewFinishDate((DateTime)ChartViewFinish.EditValue);
        }

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public void SetWorkTime()
        {
            foreach (GanttUI ganttUI in MainControl.TabPages) ganttUI.SetWorkTime();
        }

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        private void InitialDraw()
        {
            if (GlobalData.Parameters.GanttFormLocation == new Point(0, 0)) this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = GlobalData.Parameters.GanttFormLocation;
            }
            if (GlobalData.Parameters.GanttFormSize != new Size(0, 0)) this.Size = GlobalData.Parameters.GanttFormSize;

            bool isFirstPage = true;
            foreach (var ganttData in GanttData.GanttDatas)
            {
                GanttUI ganttUI = new GanttUI(ganttData);
                ganttUI.GanttDataSave += GanttUI_GanttDataSave;
                MainControl.TabPages.Add(ganttUI);
                if (isFirstPage) { TabColor.EditValue = ganttUI.GanttData.Color.ToDrawingColor(); isFirstPage = false; }
                MainControl.LayoutChanged();
            }
        }

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/

        private void SaveAndUpdate()
        {
            GanttData.SaveData();
            if (MainControl.TabPages != null) MainControl.LayoutChanged();
        }
    }
}