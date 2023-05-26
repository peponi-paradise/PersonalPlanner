using DevExpress.Utils.Svg;
using System.Drawing;

namespace PersonalPlanner.Define
{
    public class Font
    {
        public float Size = 9;
        public FontStyle Style = FontStyle.Regular;
        public string Name = "맑은 고딕";
        public GraphicsUnit Unit = GraphicsUnit.Point;

        public void ToInternalFont(System.Drawing.Font f)
        {
            Size = f.Size;
            Style = f.Style;
            Name = f.Name;
            Unit = f.Unit;
        }

        public System.Drawing.Font ToDrawingFont() => new System.Drawing.Font(Name, Size, Style, Unit);
    }

    public class Color
    {
        public int R = 0, G = 0, B = 0, A = 0;

        public void ToInternalColor(System.Drawing.Color color)
        {
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public System.Drawing.Color ToDrawingColor() => System.Drawing.Color.FromArgb(A, R, G, B);
    }

    public record GuideInformation
    {
        public string Description;
        public object TargetControl;
        public Point TargetLocation;
    }

    public enum NotificationType
    {
        Schedule,
        Memo,
        Gantt,
    }

    public class NotificationData
    {
        public NotificationType NotificationType { get; set; } = NotificationType.Schedule;
        public string Title { get; set; } = "";
        public SvgImage TitleImageSource { get; set; }
        public SvgImage TitlePinImageSource { get; set; }
        public SvgImage TitleCloseImageSource { get; set; }
        public string Caption { get; set; } = "";
        public SvgImage DescriptionImageSource { get; set; }
        public string Description1 { get; set; } = "";
        public string Description2 { get; set; } = "";
        public string FooterUrl1 { get; set; } = "";
        public string FooterUrl2 { get; set; } = "";
        public string Copyright { get; set; } = "";
    }
}