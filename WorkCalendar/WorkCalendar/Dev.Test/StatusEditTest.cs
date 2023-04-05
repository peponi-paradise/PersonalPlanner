using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkCalendar.Dev.Test
{
    public partial class StatusEditTest : EditFormUserControl
    {
        public enum PaintStyle
        {
            Solid = 0,
            Hatch = 1,
        }

        public class nested
        {
            public PaintStyle PaintStyle;
            public HatchStyle HatchStyle;
            public object Id = 0;
            public string DisplayName = "";
            public Color color = Color.White;
        }

        public StatusEditTest()
        {
            InitializeComponent();
            HatchStyleList.Items.AddRange(Enum.GetNames(typeof(HatchStyle)));
        }

        public StatusEditTest(object item)
        {
            InitializeComponent();
            HatchStyleList.Items.AddRange(Enum.GetNames(typeof(HatchStyle)));

            IAppointmentStatus a = (IAppointmentStatus)item;
            IDEdit.Text = a.Id.ToString();
            DisplayNameEdit.Text = a.DisplayName;
            switch (a.GetBrush())
            {
                case SolidBrush solid:
                    HatchStyleList.SelectedIndex = 0;
                    PaintStyleList.SelectedItem = "Solid";
                    ColorPick.Color = solid.Color;
                    break;

                case HatchBrush hatch:
                    HatchStyleList.SelectedItem = hatch.HatchStyle.ToString();
                    PaintStyleList.SelectedItem = "Hatch";
                    ColorPick.Color = hatch.ForegroundColor;
                    break;
            }
        }

        private void PaintStyleList_SelectedIndexChanged(object sender, EventArgs e) => DrawPreview();

        private void HatchStyleList_SelectedIndexChanged(object sender, EventArgs e) => DrawPreview();

        private void ColorPick_EditValueChanged(object sender, EventArgs e) => DrawPreview();

        private void DrawPreview()
        {
            var bitmap = new Bitmap(Preview.Width, Preview.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                switch (PaintStyleList.GetItemValue(PaintStyleList.SelectedIndex))
                {
                    case "Solid":
                        SolidBrush solid = new SolidBrush(ColorPick.Color);
                        g.FillRectangle(solid, new Rectangle(new Point(0, 0), new Size(Preview.Width, Preview.Height)));
                        break;

                    case "Hatch":
                        HatchBrush hatch = new HatchBrush((HatchStyle)Enum.Parse(typeof(HatchStyle), HatchStyleList.SelectedItem.ToString()), ColorPick.Color);
                        g.FillRectangle(hatch, new Rectangle(new Point(0, 0), new Size(Preview.Width, Preview.Height)));
                        break;
                }
                Preview.Image = bitmap;
            }
        }
    }
}