using System.Diagnostics;

namespace WatchDog
{
    public class WatchDog
    {
        private static void Main(string[] args)
        {
            RestartApp(int.Parse(args[0]), args[1]);
        }

        private static void RestartApp(int pid, string applicationName)
        {
            // Wait for the process to terminate
            Console.WriteLine("Personal Planner WatchDog");
            Process process = null;
            bool success = true;
            try
            {
                process = Process.GetProcessById(pid);
                process.WaitForExit(10000);
            }
            catch (ArgumentException ex)
            {
                success = false;
            }
            if (success)
            {
                Process.Start(applicationName, "");
            }
            else
            {
                Console.WriteLine("Restart Failed");
                Console.ReadLine();
            }
        }
    }
}