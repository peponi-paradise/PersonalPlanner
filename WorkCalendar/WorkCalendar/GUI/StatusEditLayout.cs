using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using WorkCalendar.Define;

namespace WorkCalendar.GUI
{
    public partial class StatusEditLayout : EditFormUserControl
    {
        public StatusEditLayout()
        {
            InitializeComponent();

            PaintStyleList.Properties.Items.AddRange(Enum.GetNames(typeof(StatusPaintStyle)));
            PaintStyleList.SelectedIndex = 0;
            HatchStyleList.Properties.Items.AddRange(Enum.GetNames(typeof(HatchStyle)));
            HatchStyleList.SelectedIndex = 0;
            SetBoundFieldName(DisplayNameEdit, nameof(AppointmentStatusDefine.DisplayName));
            SetBoundFieldName(HatchStyleList, nameof(AppointmentStatusDefine.HatchStyle));
            SetBoundFieldName(PaintStyleList, nameof(AppointmentStatusDefine.PaintStyle));
            SetBoundFieldName(ForeColorPick, nameof(AppointmentStatusDefine.ForeColor));
            SetBoundFieldName(BackColorPick, nameof(AppointmentStatusDefine.BackColor));
        }

        private void PaintStyleList_SelectedIndexChanged(object sender, EventArgs e) => DrawPreview();

        private void HatchStyleList_SelectedIndexChanged(object sender, EventArgs e) => DrawPreview();

        private void ColorPick_EditValueChanged(object sender, EventArgs e) => DrawPreview();

        private void DrawPreview()
        {
            var bitmap = new Bitmap(Preview.Width, Preview.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                switch (PaintStyleList.SelectedItem)
                {
                    case "Solid":
                        SolidBrush solid = new SolidBrush(ForeColorPick.Color);
                        g.FillRectangle(solid, new Rectangle(new Point(0, 0), new Size(Preview.Width, Preview.Height)));
                        break;

                    case "Hatch":
                        if (HatchStyleList.SelectedItem == null || HatchStyleList.SelectedIndex == -1) return;
                        HatchBrush hatch = new HatchBrush((HatchStyle)Enum.Parse(typeof(HatchStyle), HatchStyleList.SelectedItem.ToString()), ForeColorPick.Color, BackColorPick.Color);
                        g.FillRectangle(hatch, new Rectangle(new Point(0, 0), new Size(Preview.Width, Preview.Height)));
                        break;
                }
                Preview.Image = bitmap;
            }
        }

        private void StatusEditTest_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                DrawPreview();
            }
        }
    }
}