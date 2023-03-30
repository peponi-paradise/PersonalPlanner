using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.iCalendar;
using System.Threading.Tasks;

namespace WorkCalendar.Data
{
    public static class CalendarData
    {
        public static async Task ReadCalendar(string filePath, SchedulerDataStorage dataStorage)
        {
            await Task.Run(() =>
            {
                iCalendarImporter calendarImporter = new iCalendarImporter(dataStorage);
                calendarImporter.Import(filePath);
            });
        }

        public static async Task WriteCalendar(string filePath, SchedulerDataStorage dataStorage)
        {
            await Task.Run(() =>
            {
                iCalendarExporter calendarExporter = new iCalendarExporter(dataStorage);
                calendarExporter.Export(filePath);
            });
        }

        public static async Task SetCalendarDataPath(string filePath) => await Task.Run(() => ChangeCalendarDataPath(filePath)).ConfigureAwait(false);

        private static void ChangeCalendarDataPath(string filePath)
        {
            var settings = Properties.Settings.Default;
            settings.CalendarFilePath = filePath;
            settings.Save();
        }
    }
}