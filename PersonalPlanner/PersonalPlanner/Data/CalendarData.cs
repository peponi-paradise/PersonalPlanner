using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.iCalendar;
using DevExpress.XtraScheduler.iCalendar.Components;
using System;
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
            calendarImporter.AppointmentImported += CalendarImporter_AppointmentImported;
            calendarImporter.Import(filePath);
        }

        private static void CalendarImporter_AppointmentImported(object sender, AppointmentImportedEventArgs e)
        {
            iCalendarAppointmentImportedEventArgs args = e as iCalendarAppointmentImportedEventArgs;

            if (args != null)
            {
                e.Appointment.StatusKey = ((CustomProperty)args.VEvent.CustomProperties["X-DEVEXPRESS-STATUS"]).Value;
            }
        }

        public static async Task ReadCalendarAsync(string filePath, SchedulerDataStorage dataStorage) => await Task.Run(() => { ReadCalendar(filePath, dataStorage); });

        public static void WriteCalendar(string filePath, SchedulerDataStorage dataStorage)
        {
            iCalendarExporter calendarExporter = new iCalendarExporter(dataStorage);
            calendarExporter.AppointmentExporting += CalendarExporter_AppointmentExporting;
            calendarExporter.Export(filePath);
        }

        private static void CalendarExporter_AppointmentExporting(object sender, AppointmentExportingEventArgs e)
        {
            iCalendarAppointmentExportingEventArgs args = e as iCalendarAppointmentExportingEventArgs;
            if (args != null)
            {
                ((CustomProperty)args.VEvent.CustomProperties["X-MICROSOFT-CDO-BUSYSTATUS"]).Value = e.Appointment.StatusKey.ToString();
                ((CustomProperty)args.VEvent.CustomProperties["X-DEVEXPRESS-STATUS"]).Value = e.Appointment.StatusKey.ToString();
            }
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