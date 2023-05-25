using DevExpress.CodeParser;
using DevExpress.Utils;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Forms;
using System;

namespace DXApplication1
{
    public class CustomReminderForm : RemindersForm
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

        public delegate void DismissOccurredEventHandler(ReminderCollection reminders);

        public event DismissOccurredEventHandler DismissOccurred;

        public delegate void SnoozeOccurredEventHandler(ReminderCollection reminders, TimeSpan span);

        public event SnoozeOccurredEventHandler SnoozeOccurred;

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

        public CustomReminderForm(SchedulerControl schedulerControl) : base(schedulerControl)
        {
            //btnDismiss.Click += BtnDismiss_Click;
            btnDismissAll.Click += BtnDismissAll_Click;
            btnSnooze.Click += BtnSnooze_Click;
        }

        private void BtnSnooze_Click(object sender, System.EventArgs e)
        {
            var items = GetSelectedReminders();
            TimeSpan span = (TimeSpan)cbSnooze.EditValue;
            SnoozeOccurred?.Invoke(items, span);
        }

        private void BtnDismissAll_Click(object sender, System.EventArgs e)
        {
            var items = base.GetReminders();
            DismissOccurred?.Invoke(items);
        }

        private void BtnDismiss_Click(object sender, System.EventArgs e)
        {
            var items = base.GetSelectedReminders();
            DismissOccurred?.Invoke(items);
        }

        protected override void btnDismiss_Click(object sender, EventArgs e)
        {
            var items = GetSelectedReminders();
            DismissOccurred?.Invoke(items);
            base.btnDismiss_Click(sender, e);
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