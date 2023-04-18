using PersonalPlanner.Define;
using PersonalPlanner.Parser.YAML;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalPlanner.Data
{
    public static class MemoData
    {
        /*-------------------------------------------
         *
         *      Public members
         *
         -------------------------------------------*/
        public static List<MemoDefine> Memos = new();

        /*-------------------------------------------
         *
         *      Private members
         *
         -------------------------------------------*/

        private static string MemoDataPath = GlobalData.DefaultFIlePath + $@"Memo.yaml";

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public static bool LoadData()
        {
            ;
            if (YAMLParser.LoadData(MemoDataPath, out List<MemoDefine> memos))
            {
                if (memos != null)
                {
                    Memos.Clear();
                    foreach (var memo in memos)
                    {
                        memo.Memo = memo.Memo.Replace("\n", Environment.NewLine);
                        Memos.Add(memo);
                    }
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> LoadDataAsync() => await System.Threading.Tasks.Task.Run(() => LoadData());

        public static bool LoadData(string filePath)
        {
            if (YAMLParser.LoadData(filePath, out List<MemoDefine> memos))
            {
                Memos.Clear();
                foreach (var memo in memos)
                {
                    memo.Memo = memo.Memo.Replace("\n", Environment.NewLine);
                    Memos.Add(memo);
                }
                return true;
            }
            return false;
        }

        public static async Task<bool> LoadDataAsync(string filePath) => await System.Threading.Tasks.Task.Run(() => LoadData(filePath));

        public static void SaveData() => YAMLParser.SaveData(MemoDataPath, Memos);

        public static async System.Threading.Tasks.Task SaveDataAsync() => await System.Threading.Tasks.Task.Run(() => SaveData());

        public static void SaveData(string filePath) => YAMLParser.SaveData(filePath, Memos);

        public static async System.Threading.Tasks.Task SaveDataAsync(string filePath) => await System.Threading.Tasks.Task.Run(() => SaveData(filePath));

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/
    }
}