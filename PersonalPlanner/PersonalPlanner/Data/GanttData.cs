using PersonalPlanner.Define;
using PersonalPlanner.Parser.YAML;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalPlanner.Data
{
    public static class GanttData
    {
        /*-------------------------------------------
         *
         *      Events
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Public members
         *
         -------------------------------------------*/

        public static List<GanttDefine> GanttDatas = new List<GanttDefine>();

        /*-------------------------------------------
         *
         *      Private members
         *
         -------------------------------------------*/

        private static string FilePath = $@"{Environment.CurrentDirectory}\Data\{nameof(GanttData)}.yaml";

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public static bool LoadData()
        {
            try
            {
                if (YAMLParser.LoadData(FilePath, out List<GanttDefine> ganttDatas, null, true))
                {
                    if (ganttDatas != null)
                    {
                        GanttDatas.Clear();
                        GanttDatas.AddRange(ganttDatas);
                    }
                }
                return true;
            }
            catch { return false; }
        }

        public static async Task<bool> LoadDataAsync() => await System.Threading.Tasks.Task.Run(() => LoadData());

        public static void SaveData() => YAMLParser.SaveData(FilePath, GanttDatas);

        public static async System.Threading.Tasks.Task SaveDataAsync() => await System.Threading.Tasks.Task.Run(() => SaveData());

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/
    }
}