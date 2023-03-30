using System.IO;
using System.Threading.Tasks;

namespace WorkCalendar.Data
{
    public static class MemoData
    {
        public static async Task<string> ReadMemo(string filePath) => await File.ReadAllTextAsync(filePath).ConfigureAwait(false);

        public static async Task WriteMemo(string filePath, string text) => await File.WriteAllTextAsync(filePath, text).ConfigureAwait(false);

        public static async Task SetMemoDataPath(string filePath) => await Task.Run(() => ChangeMemoDataPath(filePath)).ConfigureAwait(false);

        private static void ChangeMemoDataPath(string filePath)
        {
            var settings = Properties.Settings.Default;
            settings.MemoFilePath = filePath;
            settings.Save();
        }
    }
}