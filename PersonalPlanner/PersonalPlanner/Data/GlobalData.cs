using PersonalPlanner.Parser.YAML;
using System;
using System.Drawing;
using System.Threading.Tasks;

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

        public static string DefaultFIlePath = $@"{Environment.CurrentDirectory}\Data\";

        /*-------------------------------------------
         *
         *      Private members
         *
         -------------------------------------------*/

        private static string GlobalDataPath = DefaultFIlePath + $@"{nameof(GlobalData)}.yaml";

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

            private bool _DayViewWorktimeShow = false;

            public bool DayViewWorktimeShow
            {
                get => _DayViewWorktimeShow;
                set
                {
                    _DayViewWorktimeShow = value;
                    SaveData();
                }
            }

            private bool _WorkweekViewWorktimeShow = false;

            public bool WorkweekViewWorktimeShow
            {
                get => _WorkweekViewWorktimeShow;
                set
                {
                    _WorkweekViewWorktimeShow = value;
                    SaveData();
                }
            }

            private bool _FullweekViewWorktimeShow = false;

            public bool FullweekViewWorktimeShow
            {
                get => _FullweekViewWorktimeShow;
                set
                {
                    _FullweekViewWorktimeShow = value;
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

            private Point _MemoFormLocation = new Point(0, 0);

            public Point MemoFormLocation
            {
                get => _MemoFormLocation;
                set
                {
                    _MemoFormLocation = value;
                    SaveData();
                }
            }

            private Point _GanttFormLocation = new Point(0, 0);

            public Point GanttFormLocation
            {
                get => _GanttFormLocation;
                set
                {
                    _GanttFormLocation = value;
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

            private Size _MemoFormSize = new Size(480, 640);

            public Size MemoFormSize
            {
                get => _MemoFormSize;
                set
                {
                    _MemoFormSize = value;
                    SaveData();
                }
            }

            private Size _GanttFormSize = new Size(800, 600);

            public Size GanttFormSize
            {
                get => _GanttFormSize;
                set
                {
                    _GanttFormSize = value;
                    SaveData();
                }
            }

            private bool _MemoFormShowOnStartUp = false;

            public bool MemoFormShowOnStartUp
            {
                get => _MemoFormShowOnStartUp;
                set
                {
                    _MemoFormShowOnStartUp = value;
                    SaveData();
                }
            }

            private bool _GanttFormShowOnStartUp = false;

            public bool GanttFormShowOnStartUp
            {
                get => _GanttFormShowOnStartUp;
                set
                {
                    _GanttFormShowOnStartUp = value;
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