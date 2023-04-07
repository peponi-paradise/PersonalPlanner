using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WorkCalendar.Parser.YAML;

namespace WorkCalendar.Dev.Test
{
    public class MemoDataTest : IYAML
    {
        public List<MemoDefine> Memos = new();

        private static void ChangeMemoDataPath(string filePath)
        {
            var settings = Properties.Settings.Default;
            settings.MemoFilePath = filePath;
            settings.Save();
        }

        public bool LoadData()
        {
            var settings = Properties.Settings.Default;
            if (YAMLParser.LoadData(settings.MemoFilePath, out List<MemoDefine> Memos)) { this.Memos = Memos; return true; }
            return false;
        }

        public async Task<bool> LoadDataAsync() => await Task.Run(() => LoadData());

        public void SaveData()
        {
            var settings = Properties.Settings.Default;
            YAMLParser.SaveData(settings.MemoFilePath, Memos);
        }

        public async Task SaveDataAsync() => await Task.Run(() => SaveData());
    }
}