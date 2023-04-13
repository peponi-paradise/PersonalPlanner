using System.Drawing.Drawing2D;

namespace PersonalPlanner.Define
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
        public System.Drawing.Color ForeColor = System.Drawing.Color.White;
        public System.Drawing.Color BackColor = System.Drawing.Color.White;
    }

    public class AppointmentLabelDefine
    {
        public string DisplayName = "";
        public System.Drawing.Color Color = System.Drawing.Color.White;
    }

    public class AppointmentResourceDefine
    {
        public string Caption = "";
        public System.Drawing.Color Color = System.Drawing.Color.White;
    }
}