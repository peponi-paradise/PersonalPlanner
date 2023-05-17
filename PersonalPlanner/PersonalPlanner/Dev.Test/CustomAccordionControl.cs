using DevExpress.XtraBars.Navigation;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalPlanner.Dev.Test
{
    public class CustomAccordionControl : AccordionControl
    {
        /*-------------------------------------------
         *
         *      Events
         *
         -------------------------------------------*/

        public delegate void ElementClickEventHandler(AccordionControlElement element, Point point);

        public event ElementClickEventHandler ElementClicked;

        /*-------------------------------------------
         *
         *      Public members
         *
         -------------------------------------------*/

        public AccordionControlForm PopupForm;

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

        public CustomAccordionControl()
        {
        }

        ~CustomAccordionControl()
        {
            this.Dispose();
        }

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        private void Element_Click(object sender, System.EventArgs e)
        {
            if (this.IsPopupFormShown)
            {
                var item = PopupForm.AccordionControl.CalcHitInfo(PopupForm.AccordionControl.PointToClient(Cursor.Position)).ItemInfo;
                if (item != null)
                {
                    var bounds = item.HeaderBounds;
                    var point = PopupForm.AccordionControl.PointToScreen(new Point(bounds.Right, (bounds.Top + bounds.Bottom) / 2));
                    ElementClicked?.Invoke((AccordionControlElement)sender, point);
                }
            }
            else
            {
                var item = this.CalcHitInfo(this.PointToClient(Cursor.Position)).ItemInfo;
                if (item != null)
                {
                    var bounds = item.HeaderBounds;
                    var point = this.PointToScreen(new Point(bounds.Right, (bounds.Top + bounds.Bottom) / 2));
                    ElementClicked?.Invoke((AccordionControlElement)sender, point);
                }
            }
        }

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public void RegisterElementClick(AccordionControlElement elem)
        {
            foreach (var element in elem.Elements) element.Click += Element_Click;
        }

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        protected override AccordionControlForm CreatePopupForm(AccordionControlElement elem)
        {
            var form = base.CreatePopupForm(elem);
            PopupForm = form;
            return form;
        }

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/
    }
}