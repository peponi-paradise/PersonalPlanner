using DevExpress.XtraScheduler;
using PersonalPlanner.Define;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace PersonalPlanner.Data
{
    public static class AppointmentSettingData
    {
        /*-------------------------------------------
         *
         *      Private members
         *
         -------------------------------------------*/

        private static string LabelFilePath = GlobalData.DefaultFilePath + $"{nameof(LabelDataSet)}.xml";
        private static string StatusFilePath = GlobalData.DefaultFilePath + $"{nameof(StatusDataSet)}.xml";
        private static string ResourceFilePath = GlobalData.DefaultFilePath + $"{nameof(ResourceDataSet)}.xml";

        private static DataSet LabelDataSet;
        private static DataSet StatusDataSet;
        private static DataSet ResourceDataSet;

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public static DataTable GetLabelDataSet() => LabelDataSet.Tables[0];

        public static DataTable GetStatusDataSet() => StatusDataSet.Tables[0];

        public static DataTable GetResourceDataSet() => ResourceDataSet.Tables[0];

        public static void LoadLabelData(IAppointmentLabelStorage appointmentLabels)
        {
            LabelDataSet = new DataSet();
            LabelDataSet.ReadXml(LabelFilePath);

            UpdateLabelData(appointmentLabels);
        }

        public static void UpdateLabelData(IAppointmentLabelStorage appointmentLabels)
        {
            List<AppointmentLabelDefine> labels = (from DataRow row in GetLabelDataSet().Rows
                                                   select new AppointmentLabelDefine()
                                                   {
                                                       DisplayName = row[nameof(AppointmentLabelDefine.DisplayName)].ToString(),
                                                       Color = int.TryParse(row[nameof(AppointmentLabelDefine.Color)].ToString(), out var colorInt) ? System.Drawing.Color.FromArgb(colorInt) : System.Drawing.Color.FromName(row[nameof(AppointmentLabelDefine.Color)].ToString())
                                                   }).ToList();

            appointmentLabels.Clear();
            foreach (var label in labels)
            {
                var addData = appointmentLabels.CreateNewLabel(label.DisplayName);
                addData.MenuCaption = label.DisplayName;
                addData.SetColor(label.Color);
                appointmentLabels.Add(addData);
            }
        }

        public static void SaveLabelData() => LabelDataSet.WriteXml(LabelFilePath);

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
                                                          ForeColor = int.TryParse(row[nameof(AppointmentStatusDefine.ForeColor)].ToString(), out var colorInt) ? System.Drawing.Color.FromArgb(colorInt) : System.Drawing.Color.FromName(row[nameof(AppointmentStatusDefine.ForeColor)].ToString()),
                                                          BackColor = int.TryParse(row[nameof(AppointmentStatusDefine.BackColor)].ToString(), out colorInt) ? System.Drawing.Color.FromArgb(colorInt) : System.Drawing.Color.FromName(row[nameof(AppointmentStatusDefine.BackColor)].ToString())
                                                      }).ToList();

            appointmentStatuses.Clear();
            foreach (var status in statuses)
            {
                AppointmentStatus addData = (AppointmentStatus)appointmentStatuses.CreateNewStatus(status.DisplayName, status.DisplayName, status.DisplayName);
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

        public static void SaveStatusData() => StatusDataSet.WriteXml(StatusFilePath);

        public static void LoadResourceData(ResourceDataStorage dataStorage)
        {
            ResourceDataSet = new DataSet();
            ResourceDataSet.ReadXml(ResourceFilePath);

            UpdateResourceData(dataStorage);
        }

        public static void UpdateResourceData(ResourceDataStorage dataStorage)
        {
            List<AppointmentResourceDefine> resources = (from DataRow row in GetResourceDataSet().Rows
                                                         select new AppointmentResourceDefine()
                                                         {
                                                             Caption = row[nameof(AppointmentResourceDefine.Caption)].ToString(),
                                                             Color = int.TryParse(row[nameof(AppointmentResourceDefine.Color)].ToString(), out var colorInt) ? System.Drawing.Color.FromArgb(colorInt) : System.Drawing.Color.FromName(row[nameof(AppointmentResourceDefine.Color)].ToString())
                                                         }).ToList();

            dataStorage.Clear();
            foreach (var resource in resources)
            {
                var addData = dataStorage.CreateResource(resource.Caption, resource.Caption);
                addData.SetColor(resource.Color);
                dataStorage.Add(addData);
            }
        }

        public static void SaveResourceData() => ResourceDataSet.WriteXml(ResourceFilePath);
    }
}