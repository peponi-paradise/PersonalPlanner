using DevExpress.XtraEditors;
using PersonalPlanner.Data;
using PersonalPlanner.Define;
using System;
using System.Windows.Forms;

namespace PersonalPlanner.GUI
{
    public partial class GanttForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public GanttForm()
        {
            InitializeComponent();
            InitialDraw();
        }

        private void InitialDraw()
        {
            foreach (var ganttData in GanttData.GanttDatas)
            {
                GanttUI ganttUI = new GanttUI(ganttData);
                ganttUI.GanttDataSave += GanttUI_GanttDataSave;
                MainControl.TabPages.Add(ganttUI);
                MainControl.LayoutChanged();
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
                var input = XtraInputBox.Show("Input new Item's ID", "New Item", "0");
                if (input != null)
                {
                    if (int.TryParse(input, out var ID))
                    {
                        Task task = new Task() { ID = ID };
                        if ((MainControl.SelectedTabPage as GanttUI).AddTask(task)) SaveAndUpdate();
                    }
                    else
                    {
                        XtraMessageBox.Show("Could not parse ID.\nPlease input as `Integer`");
                    }
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

        private void SaveAndUpdate()
        {
            GanttData.SaveData();
            MainControl.LayoutChanged();
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
    }
}