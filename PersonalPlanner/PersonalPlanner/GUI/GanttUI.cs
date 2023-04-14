using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGantt;
using DevExpress.XtraGantt.Options;
using DevExpress.XtraGantt.Scrolling;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using PersonalPlanner.Define;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PersonalPlanner.GUI
{
    public partial class GanttUI : XtraTabPage
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

        public delegate void GanttDataSaveEventHandler();

        public event GanttDataSaveEventHandler GanttDataSave;

        /*-------------------------------------------
         *
         *      Public members
         *
         -------------------------------------------*/

        public GanttDefine GanttData;

        /*-------------------------------------------
         *
         *      Private members
         *
         -------------------------------------------*/

        private readonly SynchronizationContext SyncContext;
        private bool mouseIsDown = false;
        private int _prevX;
        private int EditingNodeID;

        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        public GanttUI()
        {
            InitializeComponent();
            // Do not use this
        }

        public GanttUI(GanttDefine ganttData)
        {
            InitializeComponent();
            SyncContext = SynchronizationContext.Current;
            MainGanttControl.Dock = DockStyle.Fill;
            this.Controls.Add(MainGanttControl);
            GanttData = ganttData;

            this.Text = ganttData.Name;
            SetTabPageColor();

            SetGanttControlSettings();
            BindData();

            MainGanttControl.EditFormPrepared += MainGanttControl_EditFormPrepared;
            MainGanttControl.EditFormHidden += MainGanttControl_EditFormHidden;
            this.VisibleChanged += GanttUI_VisibleChanged;
            MainGanttControl.MouseDown += MainGanttControl_MouseDown;
            MainGanttControl.MouseMove += MainGanttControl_MouseMove;
            MainGanttControl.MouseUp += MainGanttControl_MouseUp;
        }

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        private void GanttControl_Load(object sender, EventArgs e) => MainGanttControl.ScrollChartToDate(DateTime.Today);

        private void DrawTodayLine(CustomDrawTimescaleColumnEventArgs e)
        {
            e.DrawBackground();
            float x = (float)e.GetPosition(DateTime.Now);
            float width = 4;

            RectangleF rectangle = new RectangleF(x, e.Column.Bounds.Y, width, e.Column.Bounds.Height);

            e.Cache.FillRectangle(System.Drawing.Color.Red, rectangle);
            e.DrawHeader();
        }

        private void MainGanttControl_EditFormPrepared(object sender, DevExpress.XtraTreeList.EditFormPreparedEventArgs e) => EditingNodeID = (int)e.Node.GetValue(nameof(Task.ID));

        private void MainGanttControl_EditFormHidden(object sender, DevExpress.XtraTreeList.EditFormHiddenEventArgs e)
        {
            if (e.Result == DevExpress.XtraTreeList.EditFormResult.Update)
            {
                var currentNode = e.Node as GanttControlNode;

                // Check Duplicated ID
                foreach (TreeListNode node in currentNode.GanttControl.NodesIterator.All)
                {
                    if (node.Id != currentNode.Id)
                    {
                        if ((int)node.GetValue(nameof(Task.ID)) == (int)currentNode.GetValue(nameof(Task.ID)))
                        {
                            currentNode.SetValue(nameof(Task.ID), EditingNodeID);
                            XtraMessageBox.Show("Duplicated ID Detected. Cancel update.");
                            return;
                        }
                    }
                }

                if (currentNode.ParentNode != null) CheckChildDuration(currentNode, currentNode.ParentNode);
                SaveData();
            }
        }

        private void MainGanttControl_TaskProgressModified(object sender, TaskProgressModifiedEventArgs e) => SaveData();

        private void MainGanttControl_TaskFinishDateModified(object sender, TaskFinishModifiedEventArgs e)
        {
            if (e.ProcessedNode.ParentNode != null) CheckChildDuration(e.ProcessedNode, e.ProcessedNode.ParentNode);
            if (e.ProcessedNode.HasChildren) foreach (GanttControlNode node in e.ProcessedNode.Nodes) CheckChildDuration(node, e.ProcessedNode);
            SaveData();
        }

        private void MainGanttControl_TaskDependencyModified(object sender, TaskDependencyModificationEventArgs e) => SaveData();

        private void MainGanttControl_TaskMoved(object sender, TaskMovedEventArgs e)
        {
            if (e.ProcessedNode.ParentNode != null)
            {
                var currentNode = e.ProcessedNode;
                var parentNode = e.ProcessedNode.ParentNode;
                do
                {
                    CheckParentDuration(currentNode, parentNode);
                    currentNode = parentNode;
                    parentNode = currentNode.ParentNode;
                } while (parentNode != null);
            }
            if (e.ProcessedNode.HasChildren)
            {
                var timeGap = e.ProcessedNode.GetStartDate() - e.OriginalTaskStart;
                MoveAllChild(e.ProcessedNode, timeGap);
            }
            SaveData();
        }

        private void GanttUI_VisibleChanged(object sender, EventArgs e)
        {
            if (this.PageVisible) MainGanttControl.ExpandAll();
        }

        private void MainGanttControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                GanttControl gantt = sender as GanttControl;
                var delta = (e.X - _prevX);
                _prevX = e.X;
                var scrollBar = gantt.Controls.OfType<GanttChartHScrollBar>().FirstOrDefault();
                if (scrollBar != null && scrollBar.Visible)
                {
                    var position = scrollBar.Value - delta;
                    if (position > scrollBar.Maximum - scrollBar.LargeChange + 1) position = scrollBar.Maximum - scrollBar.LargeChange;
                    else if (position < scrollBar.Minimum) position = scrollBar.Minimum;
                    scrollBar.Value = position;
                }
                (e as DXMouseEventArgs).Handled = true;
            }
        }

        private void MainGanttControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            GanttControl gantt = sender as GanttControl;
            GanttControlHitInfo hitInfo = gantt.CalcHitInfo(e.Location);
            if (hitInfo != null && hitInfo.InChart)
            {
                GanttChartHitTest hitTest = hitInfo.ChartHitTest;
                if (hitTest != null)
                {
                    if (!hitTest.InsideDependency && !hitTest.InsideDependencyArrow && !hitTest.InsideLeftPoint && !hitTest.InsideRightPoint && !hitTest.InsideTaskShape && !hitTest.InsideTimescaleHeader && hitTest.ItemInfo == null)
                    {
                        mouseIsDown = true;
                        _prevX = e.X;
                    }
                }
            }
        }

        private void MainGanttControl_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public void ChangeTabPageColor(System.Drawing.Color color)
        {
            GanttData.Color.ToInternalColor(color);
            SetTabPageColor();
        }

        public void ZoomIn() => MainGanttControl.ZoomIn();

        public void ZoomOut() => MainGanttControl.ZoomOut();

        public void ZoomReset() => MainGanttControl.ResetZoom();

        public void SetViewStartDate(DateTime dateTime)
        {
            MainGanttControl.ChartStartDate = dateTime;
            ZoomReset();
        }

        public void SetViewFinishDate(DateTime dateTime)
        {
            MainGanttControl.ChartFinishDate = dateTime;
            ZoomReset();
        }

        public bool AddTask(Task task)
        {
            var taskData = GanttData.Task.Find(item => item.ID.Equals(task.ID));
            if (taskData == default)
            {
                GanttData.Task.Add(task);
                MainGanttControl.RefreshDataSource();
                MainGanttControl.ExpandAll();
                return true;
            }
            else
            {
                XtraMessageBox.Show("Duplicated ID. Retry again", "Could not add new task");
            }
            return false;
        }

        public bool RemoveTask()
        {
            var currentTask = MainGanttControl.GetFocusedRow() as Task;
            if (currentTask != null)
            {
                GanttData.Task.Remove(currentTask);
                GanttData.Dependency.RemoveAll(item => item.SuccessorID.Equals(currentTask.ID) || item.PredecessorID.Equals(currentTask.ID));
                MainGanttControl.RefreshDataSource();
                MainGanttControl.ExpandAll();
                return true;
            }
            else
            {
                XtraMessageBox.Show("Could not find task.\nPlease select one");
            }
            return false;
        }

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        private void SetTabPageColor()
        {
            this.BackColor = GanttData.Color.ToDrawingColor();
            this.Appearance.Header.BackColor = GanttData.Color.ToDrawingColor();
            this.Appearance.HeaderActive.BackColor = GanttData.Color.ToDrawingColor();
        }

        private void SetGanttControlSettings()
        {
            MainGanttControl.OptionsCustomization.AllowModifyTasks = DefaultBoolean.True;
            MainGanttControl.OptionsCustomization.AllowModifyProgress = DefaultBoolean.True;
            MainGanttControl.OptionsCustomization.AllowModifyDependencies = DefaultBoolean.True;
            MainGanttControl.TaskDependencyModified += MainGanttControl_TaskDependencyModified;
            MainGanttControl.TaskFinishDateModified += MainGanttControl_TaskFinishDateModified;
            MainGanttControl.TaskProgressModified += MainGanttControl_TaskProgressModified;
            MainGanttControl.TaskMoved += MainGanttControl_TaskMoved;
            MainGanttControl.OptionsBehavior.ScheduleMode = ScheduleMode.Manual;
            MainGanttControl.OptionsSplitter.SplitterThickness = 3;
            MainGanttControl.OptionsSplitter.OverlayResizeZoneThickness = 5;

            MainGanttControl.OptionsBehavior.EditingMode = DevExpress.XtraTreeList.TreeListEditingMode.EditForm;
            MainGanttControl.OptionsEditForm.CustomEditFormLayout = new GanttEditLayout();
            MainGanttControl.OptionsBehavior.TaskDateChangeMode = TaskDateChangeMode.UpdateDuration;

            MainGanttControl.Load += GanttControl_Load;
        }

        private void BindData()
        {
            AddGanttColumn(nameof(Task.ID));
            AddGanttColumn(nameof(Task.ParentID));
            AddGanttColumn(nameof(Task.Name));
            AddGanttColumn(nameof(Task.StartDate));
            AddGanttColumn(nameof(Task.FinishDate));
            AddGanttColumn(nameof(Task.Progress));
            AddGanttColumn(nameof(Task.Responsibility));

            MainGanttControl.TreeListMappings.KeyFieldName = nameof(Task.ID);
            MainGanttControl.TreeListMappings.ParentFieldName = nameof(Task.ParentID);

            MainGanttControl.ChartMappings.TextFieldName = nameof(Task.Name);
            MainGanttControl.ChartMappings.StartDateFieldName = nameof(Task.StartDate);
            MainGanttControl.ChartMappings.FinishDateFieldName = nameof(Task.FinishDate);
            MainGanttControl.ChartMappings.ProgressFieldName = nameof(Task.Progress);

            MainGanttControl.DependencyMappings.PredecessorFieldName = nameof(Dependency.PredecessorID);
            MainGanttControl.DependencyMappings.SuccessorFieldName = nameof(Dependency.SuccessorID);

            MainGanttControl.DataSource = GanttData.Task;
            MainGanttControl.DependencySource = GanttData.Dependency;

            MainGanttControl.ExpandAll();
        }

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/

        private void AddGanttColumn(string name)
        {
            TreeListColumn column = new TreeListColumn();

            column.Name = name;
            column.FieldName = name;
            column.Caption = name;
            column.Width = 100;
            column.Visible = true;

            MainGanttControl.Columns.Add(column);
        }

        private void SaveData()
        {
            GanttDataSave?.Invoke();
            MainGanttControl.RefreshDataSource();
            MainGanttControl.ExpandAll();
        }

        private void CheckChildDuration(GanttControlNode child, GanttControlNode parent)
        {
            if (child.GetStartDate() < parent.GetStartDate()) child.SetValue(nameof(Task.StartDate), parent.GetStartDate());
            else if (child.GetStartDate() > parent.GetFinishDate()) child.SetValue(nameof(Task.StartDate), parent.GetFinishDate());
            if (child.GetFinishDate() > parent.GetFinishDate()) child.SetValue(nameof(Task.FinishDate), parent.GetFinishDate());
            else if (child.GetFinishDate() < parent.GetStartDate()) child.SetValue(nameof(Task.FinishDate), parent.GetStartDate());
        }

        private void CheckParentDuration(GanttControlNode child, GanttControlNode parent)
        {
            if (child.GetStartDate() < parent.GetStartDate()) parent.SetValue(nameof(Task.StartDate), child.GetStartDate());
            if (child.GetFinishDate() > parent.GetFinishDate()) parent.SetValue(nameof(Task.FinishDate), child.GetFinishDate());
        }

        private void MoveAllChild(GanttControlNode currentNode, TimeSpan? span)
        {
            foreach (GanttControlNode node in currentNode.Nodes)
            {
                node.SetValue(nameof(Task.StartDate), node.GetStartDate() + span);
                node.SetValue(nameof(Task.FinishDate), node.GetFinishDate() + span);
                if (node.HasChildren) MoveAllChild(node, span);
            }
        }
    }
}