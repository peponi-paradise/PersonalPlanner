using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkCalendar.Parser.YAML;

namespace WorkCalendar.Data
{
    public static class MemoData
    {
        public static List<MemoDefine> Memos = new();

        private static void ChangeMemoDataPath(string filePath)
        {
            var settings = Properties.Settings.Default;
            settings.MemoFilePath = filePath;
            settings.Save();
        }

        public static bool LoadData()
        {
            var settings = Properties.Settings.Default;
            if (YAMLParser.LoadData(settings.MemoFilePath, out List<MemoDefine> memos))
            {
                Memos.Clear();
                foreach (var memo in memos)
                {
                    Memos.Add(memo);
                }
                return true;
            }
            return false;
        }

        public static async Task<bool> LoadDataAsync() => await Task.Run(() => LoadData());

        public static void SaveData()
        {
            var settings = Properties.Settings.Default;
            YAMLParser.SaveData(settings.MemoFilePath, Memos);
        }

        public static async Task SaveDataAsync() => await Task.Run(() => SaveData());
    }
}