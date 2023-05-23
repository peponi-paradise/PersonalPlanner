using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using PersonalPlanner.Data;
using PersonalPlanner.Define;
using PersonalPlanner.GUI.Components;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PersonalPlanner.GUI.Frame
{
    public partial class MainFrame
    {
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

        private List<Document> GanttDocs = new List<Document>();
        private List<GanttUI> GanttUIs = new List<GanttUI>();

        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        private void NewGantt_Click(object sender, System.EventArgs e)
        {
            var rtnName = XtraInputBox.Show("Please Input Name", "New Gantt", "Name");
            if (rtnName != null)
            {
                var checkItem = GanttData.GanttDatas.Find(item => item.Name.Equals(rtnName));
                if (checkItem == default)
                {
                    var gantt = new GanttDefine() { Name = rtnName };
                    GanttData.GanttDatas.Add(gantt);
                    AddGanttElement(gantt);
                    AddGanttWidget(gantt);
                    GanttData.SaveData();
                }
                else
                {
                    XtraMessageBox.Show($"Could not make duplicated name of gantt : {rtnName}");
                }
            }
        }

        private void GanttFlyout_ShowClicked(AccordionControlElement element)
        {
            Navigation.ClosePopupForm();
            AddOrActivateGantt(element);
        }

        private void GanttDoc_CustomButtonClick(object sender, ButtonEventArgs e)
        {
            var doc = sender as Document;
            var ui = GanttUIs.Find(gantt => gantt.Name == doc.Control.Name);
            if (e.Button == doc.CustomHeaderButtons[0])
            {
                var input = XtraInputBox.Show("Input new task's name", "New Task", "Task Name");
                if (input != null)
                {
                    int maxIndex = 0;
                    foreach (var item in ui.GanttData.Task) maxIndex = item.ID > maxIndex ? item.ID : maxIndex;
                    var ID = maxIndex + 1;
                    Task task = new Task() { ID = ID, Name = input };
                    if (ui.AddTask(task)) GanttData.SaveData();
                }
            }
            else if (e.Button == doc.CustomHeaderButtons[1])
            {
                if (ui.RemoveTask()) GanttData.SaveData();
            }
            else if (e.Button == doc.CustomHeaderButtons[2]) ui.ZoomIn();
            else if (e.Button == doc.CustomHeaderButtons[3]) ui.ZoomOut();
            else if (e.Button == doc.CustomHeaderButtons[4]) ui.ZoomReset();
            else if (e.Button == doc.CustomHeaderButtons[5])
            {
                // change backcolor
                var colorEdit = new ColorPickEdit();
                if (XtraDialog.Show(colorEdit, "Choose Color", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    doc.AppearanceCaption.BackColor = colorEdit.Color;
                    doc.AppearanceCaption.BorderColor = colorEdit.Color;
                    ui.ChangeBackgroundColor(colorEdit.Color);
                    GanttData.SaveData();
                }
            }
        }

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        private void InitGantts()
        {
            foreach (var gantt in GanttData.GanttDatas)
            {
                if (gantt.IsOpened)
                {
                    AddGanttElement(gantt);
                    AddGanttWidget(gantt);
                }
                else AddGanttElement(gantt);
            }
        }

        private void ShowGanttContextMenu(AccordionControlElement element, Point point)
        {
            if (point == default) return;
            var document = GanttDocs.Find(doc => doc.Control.Name == $@"{nameof(GanttUI)}{element.Name}");
            if (ActivateWidget(document))
            {
                Navigation.ClosePopupForm();
                return;
            }

            var gantt = GanttData.GanttDatas.Find(item => item.Name == element.Name);
            var flyout = new GanttFlyout(gantt);
            flyout.ShowClicked += () => GanttFlyout_ShowClicked(element);
            if (Navigation.IsPopupFormShown) flyout.Show(Navigation.PopupForm, Navigation.PopupForm, point);
            else flyout.Show(this, point);
        }

        private void AddGanttElement(GanttDefine ganttData)
        {
            AccordionControlElement element = new AccordionControlElement();
            element.Name = ganttData.Name;
            element.Text = ganttData.Name;
            element.Style = ElementStyle.Item;
            GroupGanttLists.Elements.Add(element);
            Navigation.RegisterElementClick(element);
        }

        private void RemoveGanttElement(GanttDefine ganttData) => GroupGanttLists.Elements.Remove(GroupGanttLists.Elements.Single(elem => elem.Name == ganttData.Name));

        private void AddOrActivateGantt(AccordionControlElement element)
        {
            // Add or activate widget
            var document = GanttDocs.Find(doc => doc.Control.Name == $@"{nameof(GanttUI)}{element.Name}");
            if (ActivateWidget(document)) return;
            else AddGanttWidget(GanttData.GanttDatas.Find(item => item.Name.Equals(element.Name)));
        }

        private void AddGanttWidget(GanttDefine ganttData)
        {
            GanttUI ganttUI = new GanttUI(ganttData);
            ganttUI.Name = $@"{nameof(GanttUI)}{ganttData.Name}";
            var doc = View.AddDocument(ganttUI, ganttData.Name) as Document;
            doc.ImageOptions.ImageUri = "charttype_gantt;Size16x16";
            SetDocumentBorderColor(doc, ganttData.Color.ToDrawingColor());
            GanttDocs.Add(doc);
            GanttUIs.Add(ganttUI);
            doc.CustomHeaderButtons.Add(new CustomHeaderButton("New Task", "actions_add;Size16x16", HorizontalImageLocation.Default, ButtonStyle.PushButton, "New Task", false, 0, 0));
            doc.CustomHeaderButtons.Add(new CustomHeaderButton("Remove Task", "actions_remove;Size16x16", HorizontalImageLocation.Default, ButtonStyle.PushButton, "Remove Task", false, 1, 0));
            doc.CustomHeaderButtons.Add(new CustomHeaderButton("Zoom In", "zoomin;Size16x16", HorizontalImageLocation.Default, ButtonStyle.PushButton, "Zoom In", false, 2, 1));
            doc.CustomHeaderButtons.Add(new CustomHeaderButton("Zoom Out", "zoomout;Size16x16", HorizontalImageLocation.Default, ButtonStyle.PushButton, "Zoom Out", false, 3, 1));
            doc.CustomHeaderButtons.Add(new CustomHeaderButton("Zoom Reset", "zoom;Size16x16", HorizontalImageLocation.Default, ButtonStyle.PushButton, "Zoom Reset", false, 4, 1));
            doc.CustomHeaderButtons.Add(new CustomHeaderButton("BackgroundColor", "pagecolor;Size16x16", HorizontalImageLocation.Default, ButtonStyle.PushButton, "Change Widget Color", false, 5, 2));
            doc.CustomButtonClick += GanttDoc_CustomButtonClick;
        }

        private void RemoveGanttDoc(Document doc)
        {
            GanttDocs.Remove(doc);
            var ui = GanttUIs.Find(item => item.GanttData.Name == doc.Control.Name);
            GanttUIs.Remove(ui);
        }

        private void RemoveGanttData(Document doc)
        {
            var gantt = GanttData.GanttDatas.Find(item => item.Name == doc.Control.Name);
            RemoveGanttElement(gantt);
            GanttData.GanttDatas.Remove(gantt);
            GanttData.SaveData();
        }

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/

        private void ResetGanttWidgets()
        {
            foreach (var ui in GanttUIs) ui.ResetEditor();
        }

        private void SaveGanttWidgetStatus()
        {
            foreach (var item in GanttData.GanttDatas)
            {
                if (GanttUIs.Find(ui => ui.GanttData == item) != null) item.IsOpened = true;
                else item.IsOpened = false;
            }
            GanttData.SaveData();
        }
    }
}