using PersonalPlanner.Parser.YAML;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalPlanner.Data
{
    public static class GlobalData
    {
        /*-------------------------------------------
         *
         *      Public members
         *
         -------------------------------------------*/
        public static Parameter Parameters { get; set; }

        public static string DefaultFilePath = $@"{Application.StartupPath}\Data\";

        /*-------------------------------------------
         *
         *      Private members
         *
         -------------------------------------------*/

        private static string GlobalDataPath = DefaultFilePath + $@"{nameof(GlobalData)}.yaml";

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public static bool LoadData()
        {
            if (YAMLParser.LoadData(GlobalDataPath, out Parameter parameter, null, true))
            {
                Parameters = parameter;
                return true;
            }
            return false;
        }

        public static async Task<bool> LoadDataAsync() => await System.Threading.Tasks.Task.Run(() => LoadData());

        public static void SaveData() => YAMLParser.SaveData(GlobalDataPath, Parameters);

        public static async System.Threading.Tasks.Task SaveDataAsync() => await System.Threading.Tasks.Task.Run(() => SaveData());

        /*-------------------------------------------
         *
         *      Parameter class
         *
         -------------------------------------------*/

        public class Parameter
        {
            private string _SkinName;

            public string SkinName
            {
                get => _SkinName;
                set
                {
                    _SkinName = value;
                    SaveData();
                }
            }

            private string _SkinPaletteName;

            public string SkinPaletteName
            {
                get => _SkinPaletteName;
                set
                {
                    _SkinPaletteName = value;
                    SaveData();
                }
            }

            private TimeSpan _OfficeStart = TimeSpan.FromHours(8);

            public TimeSpan OfficeStart
            {
                get => _OfficeStart;
                set
                {
                    _OfficeStart = value;
                    SaveData();
                }
            }

            private TimeSpan _OfficeEnd = TimeSpan.FromHours(17);

            public TimeSpan OfficeEnd
            {
                get => _OfficeEnd;
                set
                {
                    _OfficeEnd = value;
                    SaveData();
                }
            }

            private int _SchedulerViewType = 0;

            public int SchedulerViewType
            {
                get => _SchedulerViewType;
                set
                {
                    _SchedulerViewType = value;
                    SaveData();
                }
            }

            private bool _WorktimeShow = false;

            public bool WorktimeShow
            {
                get => _WorktimeShow;
                set
                {
                    _WorktimeShow = value;
                    SaveData();
                }
            }

            private Point _MainFrameLocation = new Point(0, 0);

            public Point MainFrameLocation
            {
                get => _MainFrameLocation;
                set
                {
                    _MainFrameLocation = value;
                    SaveData();
                }
            }

            private Size _MainFrameSize = new Size(1280, 960);

            public Size MainFrameSize
            {
                get => _MainFrameSize;
                set
                {
                    _MainFrameSize = value;
                    SaveData();
                }
            }

            private FormWindowState _MainFrameWindowState = FormWindowState.Normal;

            public FormWindowState MainFrameWindowState
            {
                get => _MainFrameWindowState;
                set
                {
                    _MainFrameWindowState = value;
                    SaveData();
                }
            }

            private bool _IsCalendarShow = false;

            public bool IsCalendarShow
            {
                get => _IsCalendarShow;
                set
                {
                    _IsCalendarShow = value;
                    SaveData();
                }
            }

            private bool _IsSchedulerShow = false;

            public bool IsSchedulerShow
            {
                get => _IsSchedulerShow;
                set
                {
                    _IsSchedulerShow = value;
                    SaveData();
                }
            }

            private bool _CheckApplicationShortcut = false;

            public bool CheckApplicationShortcut
            {
                get => _CheckApplicationShortcut;
                set
                {
                    _CheckApplicationShortcut = value;
                    SaveData();
                }
            }
        }
    }
}