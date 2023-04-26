using DevExpress.XtraEditors;
using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace PersonalPlanner
{
    internal static class Program
    {
        public static Mutex Mutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // 중복 실행 방지
            var guid = Assembly.GetExecutingAssembly().GetType().GUID;
            Mutex = new Mutex(true, guid.ToString(), out var newApp);
            if (!newApp)
            {
                XtraMessageBox.Show("Could not start application", "Application is running");
                return;
            }

            WindowsFormsSettings.ForceDirectXPaint();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrame());
        }
    }
}