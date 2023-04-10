using DevExpress.XtraSplashScreen;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoScheduler.GUI
{
    internal partial class LoadingDialog : SplashScreen
    {
        public LoadingDialog()
        {
            InitializeComponent();
            this.labelCopyright.Text = $"© {DateTime.Now.Year}. \"ClockStrikes\" all rights reserved";
            VersionLabel.Parent = peImage;
            VersionLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            VersionLabel.BringToFront();
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            SplashScreenCommand command = (SplashScreenCommand)cmd;
            switch (command)
            {
                case SplashScreenCommand.Progress:
                    labelStatus.Text = (string)arg;
                    break;

                case SplashScreenCommand.Version:
                    VersionLabel.Text = (string)arg;
                    VersionLabel.Location = new Point(this.Width - VersionLabel.Width - 15, VersionLabel.Parent.Height - 25);
                    break;
            }
        }

        public enum SplashScreenCommand
        {
            Progress,
            Version,
        }
    }

    public static class LoadingForm
    {
        public static void OpenDialog() => SplashScreenManager.ShowForm(typeof(LoadingDialog), true, true);

        public static void SetVersion(string version) => SplashScreenManager.Default.SendCommand(LoadingDialog.SplashScreenCommand.Version, version);

        public static void SetProgress(string caption) => SplashScreenManager.Default.SendCommand(LoadingDialog.SplashScreenCommand.Progress, caption);

        public static void CloseDialog() => SplashScreenManager.CloseForm();
    }
}