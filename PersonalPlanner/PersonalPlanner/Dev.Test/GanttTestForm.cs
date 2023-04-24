using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGantt;
using DevExpress.XtraGantt.Options;
using DevExpress.XtraTreeList.Columns;
using PersonalPlanner.Define;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PersonalPlanner.Dev.Test
{
    public partial class GanttTestForm : Form
    {
        private DataSet DependencyDataSet = new DataSet(nameof(DependencyDataSet));

        private DateEdit StartDateEdit;
        private DateEdit FinishDateEdit;

        public GanttTestForm()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            MainGanttControl.OptionsCustomization.AllowModifyTasks = DefaultBoolean.True;
            MainGanttControl.OptionsCustomization.AllowModifyProgress = DefaultBoolean.True;
            MainGanttControl.OptionsCustomization.AllowModifyDependencies = DefaultBoolean.True;
            MainGanttControl.OptionsBehavior.ScheduleMode = ScheduleMode.Manual;
            MainGanttControl.OptionsSplitter.SplitterThickness = 3;
            MainGanttControl.OptionsSplitter.OverlayResizeZoneThickness = 5;

            MainGanttControl.OptionsBehavior.EditingMode = DevExpress.XtraTreeList.TreeListEditingMode.EditForm;
            MainGanttControl.EditFormPrepared += MainGanttControl_EditFormPrepared;
            MainGanttControl.EditFormHidden += MainGanttControl_EditFormHidden;
            MainGanttControl.OptionsBehavior.TaskDateChangeMode = TaskDateChangeMode.UpdateDuration;
            MainGanttControl.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            MainGanttControl.OptionsDragAndDrop.DropNodesMode = DevExpress.XtraTreeList.DropNodesMode.Advanced;
            MainGanttControl.OptionsDragAndDrop.CanCloneNodesOnDrop = true;

            SetGanttColumn();
            SetDependencyDatas();
            MainGanttControl.DependencySource = DependencyDataSet.Tables[nameof(Dependency)];

            MainGanttControl.TreeListMappings.KeyFieldName = nameof(Task.ID);
            MainGanttControl.TreeListMappings.ParentFieldName = nameof(Task.ParentID);

            MainGanttControl.ChartMappings.TextFieldName = nameof(Task.Name);
            MainGanttControl.ChartMappings.StartDateFieldName = nameof(Task.StartDate);
            MainGanttControl.ChartMappings.FinishDateFieldName = nameof(Task.FinishDate);
            MainGanttControl.ChartMappings.ProgressFieldName = nameof(Task.Progress);
            // MainGanttControl.ChartMappings.PredecessorsFieldName = nameof(Task.PredecessorID);

            MainGanttControl.DependencyMappings.PredecessorFieldName = nameof(Dependency.PredecessorID);
            MainGanttControl.DependencyMappings.SuccessorFieldName = nameof(Dependency.SuccessorID);
            MainGanttControl.DependencyMappings.TypeFieldName = nameof(Dependency.DependencyType);
            MainGanttControl.DependencyMappings.LagFieldName = nameof(Dependency.TimeLag);

            MainGanttControl.InitNewRow += MainGanttControl_InitNewRow;
            MainGanttControl.BeforeDropNode += MainGanttControl_BeforeDropNode;
            MainGanttControl.AfterDragNode += MainGanttControl_AfterDragNode;
        }

        private void MainGanttControl_AfterDragNode(object sender, DevExpress.XtraTreeList.AfterDragNodeEventArgs e)
        {
            MainGanttControl.ExpandAll();
        }

        private void MainGanttControl_EditFormPrepared(object sender, DevExpress.XtraTreeList.EditFormPreparedEventArgs e)
        {
            StartDateEdit = e.BindableControls[nameof(Task.StartDate)] as DateEdit;
            FinishDateEdit = e.BindableControls[nameof(Task.FinishDate)] as DateEdit;
            StartDateEdit.EditValueChanging += StartDateEdit_EditValueChanging;
            FinishDateEdit.EditValueChanging += FinishDateEdit_EditValueChanging;
        }

        private void MainGanttControl_EditFormHidden(object sender, DevExpress.XtraTreeList.EditFormHiddenEventArgs e)
        {
            StartDateEdit.EditValueChanging -= StartDateEdit_EditValueChanging;
            FinishDateEdit.EditValueChanging -= FinishDateEdit_EditValueChanging;
        }

        private void StartDateEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((DateTime)e.NewValue > FinishDateEdit.DateTime) e.Cancel = true;
        }

        private void FinishDateEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((DateTime)e.NewValue < StartDateEdit.DateTime) e.Cancel = true;
        }

        private void MainGanttControl_BeforeDropNode(object sender, DevExpress.XtraTreeList.BeforeDropNodeEventArgs e)
        {
            if (MainGanttControl.IsNewItemRow(e.DestinationNode)) e.Cancel = true;
        }

        private void MainGanttControl_InitNewRow(object sender, DevExpress.XtraTreeList.TreeListInitNewRowEventArgs e)
        {
            e.SetValue(nameof(Task.ID), MainGanttControl.AllNodesCount);
            e.SetValue(nameof(Task.ParentID), -1);
            e.SetValue(nameof(Task.Name), "New item");
            e.SetValue(nameof(Task.StartDate), DateTime.Now);
            e.SetValue(nameof(Task.FinishDate), DateTime.Now.AddDays(2));
            e.SetValue(nameof(Task.Progress), 0);
            e.SetValue(nameof(Task.Responsibility), "");
            e.SetValue(nameof(Task.PredecessorID), "");
        }

        private void SetGanttColumn()
        {
            var column = MainGanttControl.Columns.AddField(nameof(Task.ID));
            column.UnboundDataType = typeof(int);
            column = MainGanttControl.Columns.AddField(nameof(Task.ParentID));
            column.UnboundDataType = typeof(int);
            column = MainGanttControl.Columns.AddVisible(nameof(Task.Name));
            column.UnboundDataType = typeof(string);
            column = MainGanttControl.Columns.AddVisible(nameof(Task.StartDate));
            column.UnboundDataType = typeof(DateTime);
            column = MainGanttControl.Columns.AddVisible(nameof(Task.FinishDate));
            column.UnboundDataType = typeof(DateTime);
            column = MainGanttControl.Columns.AddVisible(nameof(Task.Progress));
            column.UnboundDataType = typeof(int);
            column = MainGanttControl.Columns.AddVisible(nameof(Task.Responsibility));
            column.UnboundDataType = typeof(string);
            //column = MainGanttControl.Columns.AddField(nameof(Task.PredecessorID));
            //column.UnboundDataType = typeof(string);
        }

        private void SetDependencyDatas()
        {
            DataTable depenTable = new DataTable(nameof(Dependency));

            depenTable.Columns.Add(new DataColumn(nameof(Dependency.PredecessorID), typeof(int)));
            depenTable.Columns.Add(new DataColumn(nameof(Dependency.SuccessorID), typeof(int)));
            depenTable.Columns.Add(new DataColumn(nameof(Dependency.DependencyType), typeof(DevExpress.XtraGantt.DependencyType)));
            depenTable.Columns.Add(new DataColumn(nameof(Dependency.TimeLag), typeof(TimeSpan)));

            DependencyDataSet.Tables.Add(depenTable);
        }

        private void Export()
        {
            MainGanttControl.ExportToXml($@"C:\temp\ganttData.xml");
            DependencyDataSet.WriteXml($@"C:\temp\DepenData.xml");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void Import()
        {
            DependencyDataSet.Clear();
            MainGanttControl.RefreshDataSource();
            MainGanttControl.ImportFromXml($@"C:\temp\ganttData.xml");
            DependencyDataSet.ReadXml($@"C:\temp\DepenData.xml");
            MainGanttControl.DependencySource = DependencyDataSet.Tables[nameof(Dependency)];
            MainGanttControl.ExpandAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Import();
        }
    }
}