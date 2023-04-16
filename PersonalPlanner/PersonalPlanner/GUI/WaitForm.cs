using DevExpress.XtraSplashScreen;
using System;

namespace PersonalPlanner.GUI
{
    internal partial class WaitDialog : DevExpress.XtraWaitForm.WaitForm
    {
        public enum WaitFormCommand
        {
        }

        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        public WaitDialog()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }
    }

    public static class WaitForm
    {
        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public static void OpenDialog() => SplashScreenManager.ShowForm(typeof(WaitDialog), true, true);

        public static void OpenDialog(string caption, string description)
        {
            SplashScreenManager.ShowForm(typeof(WaitDialog), true, true);
            SplashScreenManager.Default.SetWaitFormCaption(caption);
            SplashScreenManager.Default.SetWaitFormDescription(description);
        }

        public static void SetCaption(string caption) => SplashScreenManager.Default.SetWaitFormCaption(caption);

        public static void SetDescription(string description) => SplashScreenManager.Default.SetWaitFormDescription(description);

        public static void CloseDialog() => SplashScreenManager.CloseForm();
    }
}