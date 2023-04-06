using DevExpress.LookAndFeel;
using DevExpress.XtraScheduler;
using System.Collections.Generic;
using System;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using WorkCalendar.Define;
using WorkCalendar.GUI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WorkCalendar.Data
{
    public static class AppointmentSettingData
    {
        private static string DefaultFilePath = $@"{Environment.CurrentDirectory}\Data\";
        private static string StatusFilePath = DefaultFilePath + $"{nameof(StatusDataSet)}.xml";
        private static DataSet StatusDataSet;

        public static DataTable GetStatusDataSet() => StatusDataSet.Tables[0];

        public static void LoadStatusData(IAppointmentStatusStorage appointmentStatuses)
        {
            StatusDataSet = new DataSet();
            StatusDataSet.ReadXml(StatusFilePath);

            UpdateStatusData(appointmentStatuses);
        }

        public static void UpdateStatusData(IAppointmentStatusStorage appointmentStatuses)
        {
            List<AppointmentStatusDefine> statuses = (from DataRow row in GetStatusDataSet().Rows
                                                      select new AppointmentStatusDefine()
                                                      {
                                                          DisplayName = row[nameof(AppointmentStatusDefine.DisplayName)].ToString(),
                                                          PaintStyle = (StatusPaintStyle)Enum.Parse(typeof(StatusPaintStyle), row[nameof(AppointmentStatusDefine.PaintStyle)].ToString()),
                                                          HatchStyle = string.IsNullOrEmpty(row[nameof(AppointmentStatusDefine.HatchStyle)].ToString()) ? HatchStyle.Horizontal : (HatchStyle)Enum.Parse(typeof(HatchStyle), row[nameof(AppointmentStatusDefine.HatchStyle)].ToString()),
                                                          ForeColor = int.TryParse(row[nameof(AppointmentStatusDefine.ForeColor)].ToString(), out var colorInt) ? Color.FromArgb(colorInt) : Color.FromName(row[nameof(AppointmentStatusDefine.ForeColor)].ToString()),
                                                          BackColor = int.TryParse(row[nameof(AppointmentStatusDefine.BackColor)].ToString(), out colorInt) ? Color.FromArgb(colorInt) : Color.FromName(row[nameof(AppointmentStatusDefine.BackColor)].ToString())
                                                      }).ToList();

            appointmentStatuses.Clear();
            foreach (var status in statuses)
            {
                var addData = appointmentStatuses.CreateNewStatus(status.DisplayName);
                addData.MenuCaption = status.DisplayName;
                addData.Type = AppointmentStatusType.Custom;
                switch (status.PaintStyle)
                {
                    case StatusPaintStyle.Solid:
                        SolidBrush solid = new SolidBrush(status.ForeColor);
                        addData.SetBrush(solid);
                        break;

                    case StatusPaintStyle.Hatch:
                        HatchBrush hatch = new HatchBrush(status.HatchStyle, status.ForeColor, status.BackColor);
                        addData.SetBrush(hatch);
                        break;
                }
                appointmentStatuses.Add(addData);
            }
        }

        public static void SaveStatusData()
        {
            StatusDataSet.WriteXml(StatusFilePath);
        }
    }
}