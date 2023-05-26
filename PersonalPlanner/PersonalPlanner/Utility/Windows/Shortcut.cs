using System;
using System.IO;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace PersonalPlanner.Utility.Windows
{
    public static class Shortcut
    {
        public static bool ShortcutExist()
        {
            string commonStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
            string appStartMenuPath = Path.Combine(commonStartMenuPath, "PersonalPlanner");

            if (Directory.Exists(appStartMenuPath)) return true;
            else return false;
        }

        public static void AddShortcut()
        {
            string commonStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
            string appStartMenuPath = Path.Combine(commonStartMenuPath, "PersonalPlanner");

            if (!Directory.Exists(appStartMenuPath))
                Directory.CreateDirectory(appStartMenuPath);

            string exeLocation = Path.Combine(appStartMenuPath, "PersonalPlanner.exe" + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(exeLocation);

            shortcut.Description = @$"Personal Planner by ClockStrikes";
            shortcut.IconLocation = Application.StartupPath + "ShortDate.ico";
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.Save();

            string dllLocation = Path.Combine(appStartMenuPath, "PersonalPlanner" + ".lnk");

            IWshShortcut dllShortcut = (IWshShortcut)shell.CreateShortcut(dllLocation);

            dllShortcut.Description = @$"Personal Planner by ClockStrikes";
            dllShortcut.TargetPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            dllShortcut.WorkingDirectory = Application.StartupPath;
            dllShortcut.Save();
        }
    }
}