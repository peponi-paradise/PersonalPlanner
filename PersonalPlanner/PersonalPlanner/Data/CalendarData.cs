using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.iCalendar;
using DevExpress.XtraScheduler.iCalendar.Components;
using System.Threading.Tasks;

namespace PersonalPlanner.Data
{
    public static class CalendarData
    {
        /*-------------------------------------------
         *
         *      Private members
         *
         -------------------------------------------*/

        private static string CalendarDataPath = GlobalData.DefaultFIlePath + $@"Calendar.ics";

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public static void ReadCalendar(SchedulerDataStorage dataStorage, string filePath = null)
        {
            dataStorage.Appointments.Clear();
            iCalendarImporter calendarImporter = new iCalendarImporter(dataStorage);
            calendarImporter.AppointmentImported += CalendarImporter_AppointmentImported;
            if (filePath == null) calendarImporter.Import(CalendarDataPath);
            else calendarImporter.Import(filePath);
        }

        private static void CalendarImporter_AppointmentImported(object sender, AppointmentImportedEventArgs e)
        {
            iCalendarAppointmentImportedEventArgs args = e as iCalendarAppointmentImportedEventArgs;

            if (args != null)
            {
                e.Appointment.StatusKey = ((CustomProperty)args.VEvent.CustomProperties["X-DEVEXPRESS-STATUS"]).Value;
            }
        }

        public static async Task ReadCalendarAsync(SchedulerDataStorage dataStorage, string filePath = null) => await Task.Run(() => { ReadCalendar(dataStorage, filePath); });

        public static void WriteCalendar(SchedulerDataStorage dataStorage, string filePath = null)
        {
            iCalendarExporter calendarExporter = new iCalendarExporter(dataStorage);
            calendarExporter.AppointmentExporting += CalendarExporter_AppointmentExporting;
            if (filePath == null) calendarExporter.Export(CalendarDataPath);
            else calendarExporter.Export(filePath);
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

        public static async Task WriteCalendarAsync(SchedulerDataStorage dataStorage, string filePath = null) => await Task.Run(() => { WriteCalendar(dataStorage, filePath); });

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/
    }
}