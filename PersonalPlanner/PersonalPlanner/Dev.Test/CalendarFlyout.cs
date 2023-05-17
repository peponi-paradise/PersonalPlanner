using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalPlanner.Dev.Test
{
    public partial class CalendarFlyout : XtraUserControl
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

        public CalendarFlyout()
        {
            InitializeComponent();
        }

        public CalendarFlyout(SchedulerControl schedulerControl)
        {
            InitializeComponent();
            Calendar.SchedulerControl = schedulerControl;
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