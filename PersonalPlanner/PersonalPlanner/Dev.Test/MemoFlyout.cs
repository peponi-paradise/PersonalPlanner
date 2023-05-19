using DevExpress.XtraEditors;
using PersonalPlanner.Define;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalPlanner.Dev.Test
{
    public partial class MemoFlyout : XtraUserControl
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

        public MemoFlyout()
        {
            InitializeComponent();
        }

        public MemoFlyout(MemoDefine memoData)
        {
            InitializeComponent();

            MemoUI uI = new MemoUI(memoData);
            uI.Dock = DockStyle.Fill;
            FlyoutControl.Controls.Add(uI);
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