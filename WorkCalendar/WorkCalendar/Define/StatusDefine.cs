using System.Drawing.Drawing2D;
using System.Drawing;

namespace WorkCalendar.Define
{
    public enum StatusPaintStyle
    {
        Solid = 0,
        Hatch = 1,
    }

    public class AppointmentStatusDefine
    {
        public StatusPaintStyle PaintStyle = StatusPaintStyle.Solid;
        public HatchStyle HatchStyle = HatchStyle.Horizontal;
        public string DisplayName = "";
        public Color ForeColor = Color.White;
        public Color BackColor = Color.White;
    }
}