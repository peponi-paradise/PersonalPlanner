using DevExpress.XtraEditors;
using PersonalPlanner.Define;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalPlanner.GUI.Components
{
    public partial class GanttFlyout : XtraUserControl
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

        public delegate void ShowClickEventHandler();

        public event ShowClickEventHandler ShowClicked;

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

        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        public GanttFlyout()
        {
            InitializeComponent();
        }

        public GanttFlyout(GanttDefine ganttData)
        {
            InitializeComponent();

            GanttUI ui = new GanttUI(ganttData);
            ui.Dock = DockStyle.Fill;
            FlyoutControl.Controls.Add(ui);
        }

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public void Show(Form parentForm, Point point)
        {
            Flyout.ParentForm = parentForm;
            Flyout.OwnerControl = parentForm;
            Flyout.ShowBeakForm(point);
        }

        public void Show(Form parentForm, Control owner, Point point)
        {
            Flyout.ParentForm = parentForm;
            Flyout.OwnerControl = owner;
            Flyout.ShowBeakForm(point);
        }

        private void Flyout_ButtonClick(object sender, DevExpress.Utils.FlyoutPanelButtonClickEventArgs e)
        {
            ShowClicked?.Invoke();
            Flyout.HideBeakForm();
        }

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/
    }
}