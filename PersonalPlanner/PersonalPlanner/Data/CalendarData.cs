using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.iCalendar;
using System.Threading.Tasks;

namespace PersonalPlanner.Data
{
    public static class CalendarData
    {
        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public static void ReadCalendar(string filePath, SchedulerDataStorage dataStorage)
        {
            dataStorage.Appointments.Clear();
            iCalendarImporter calendarImporter = new iCalendarImporter(dataStorage);
            calendarImporter.Import(filePath);
        }

        public static async Task ReadCalendarAsync(string filePath, SchedulerDataStorage dataStorage) => await Task.Run(() => { ReadCalendar(filePath, dataStorage); });

        public static void WriteCalendar(string filePath, SchedulerDataStorage dataStorage)
        {
            iCalendarExporter calendarExporter = new iCalendarExporter(dataStorage);
            calendarExporter.Export(filePath);
        }

        public static async Task WriteCalendarAsync(string filePath, SchedulerDataStorage dataStorage) => await Task.Run(() => { WriteCalendar(filePath, dataStorage); });

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        private static void ChangeCalendarDataPath(string filePath)
        {
            var settings = Properties.Settings.Default;
            settings.CalendarFilePath = filePath;
        }
    }
}