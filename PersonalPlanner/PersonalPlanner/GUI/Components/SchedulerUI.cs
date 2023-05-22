using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;

namespace PersonalPlanner.GUI.Components
{
    public partial class SchedulerUI : XtraUserControl
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

        public SchedulerUI()
        {
            InitializeComponent();
        }

        public SchedulerUI(SchedulerControl schedulerControl)
        {
            InitializeComponent();
            schedulerControl.UseDirectXPaint = DevExpress.Utils.DefaultBoolean.True;
            Panel.Controls.Add(schedulerControl);
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