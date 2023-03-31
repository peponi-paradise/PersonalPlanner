using System.IO;
using System.Threading.Tasks;

namespace WorkCalendar.Data
{
    public static class MemoData
    {
        public static string ReadMemo(string filePath) => File.ReadAllText(filePath);

        public static async Task<string> ReadMemoAsync(string filePath) => await File.ReadAllTextAsync(filePath).ConfigureAwait(false);

        public static void WriteMemo(string filePath, string text) => File.WriteAllText(filePath, text);

        public static async Task WriteMemoAsync(string filePath, string text) => await File.WriteAllTextAsync(filePath, text).ConfigureAwait(false);

        private static void ChangeMemoDataPath(string filePath)
        {
            var settings = Properties.Settings.Default;
            settings.MemoFilePath = filePath;
            settings.Save();
        }
    }
}