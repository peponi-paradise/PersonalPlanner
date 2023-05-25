using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            schedulerControl1.RemindersFormShowing += SchedulerControl1_RemindersFormShowing;
        }

        private void SchedulerControl1_RemindersFormShowing(object sender, DevExpress.XtraScheduler.RemindersFormEventArgs e)
        {
            CustomReminderForm form = new CustomReminderForm(schedulerControl1);
            var args = new ReminderEventArgs(e.AlertNotifications);
            form.SnoozeOccurred += Form_SnoozeOccurred;
            form.DismissOccurred += Form_DismissOccurred;
            form.OnReminderAlert(args);
            if (form.WindowState == FormWindowState.Minimized)
                form.WindowState = FormWindowState.Normal;
            form.BringToFront();
            e.Handled = true;
        }

        private void Form_DismissOccurred(DevExpress.XtraScheduler.ReminderCollection reminders)
        {
            Trace.WriteLine($"{reminders[0].Subject}, {reminders[0].Id}");
        }

        private void Form_SnoozeOccurred(DevExpress.XtraScheduler.ReminderCollection reminders, TimeSpan span)
        {
            Console.WriteLine($"{reminders[0].Subject}, {span}");
        }
    }
}