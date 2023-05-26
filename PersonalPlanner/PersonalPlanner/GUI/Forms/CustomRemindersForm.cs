using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Forms;
using System;

namespace PersonalPlanner.GUI.Forms
{
    public class CustomRemindersForm : RemindersForm
    {
        /*-------------------------------------------
         *
         *      Events
         *
         -------------------------------------------*/

        public delegate void DismissOccurredEventHandler(ReminderCollection reminders);

        public event DismissOccurredEventHandler DismissOccurred;

        public delegate void SnoozeOccurredEventHandler(ReminderCollection reminders, TimeSpan span);

        public event SnoozeOccurredEventHandler SnoozeOccurred;

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

        public CustomRemindersForm(SchedulerControl schedulerControl) : base(schedulerControl)
        {
        }

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        protected override void btnSnooze_Click(object sender, EventArgs e)
        {
            var items = GetSelectedReminders();
            TimeSpan span = (TimeSpan)cbSnooze.EditValue;
            SnoozeOccurred?.Invoke(items, span);
            base.btnSnooze_Click(sender, e);
        }

        protected override void btnDismissAll_Click(object sender, EventArgs e)
        {
            var items = GetReminders();
            DismissOccurred?.Invoke(items);
            base.btnDismissAll_Click(sender, e);
        }

        protected override void btnDismiss_Click(object sender, EventArgs e)
        {
            var items = GetSelectedReminders();
            DismissOccurred?.Invoke(items);
            base.btnDismiss_Click(sender, e);
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

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/
    }
}