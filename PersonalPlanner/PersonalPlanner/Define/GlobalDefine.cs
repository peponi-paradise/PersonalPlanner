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
        { A = color.A; R = color.R; G = color.G; B = color.B; }

        public System.Drawing.Color ToDrawingColor() => System.Drawing.Color.FromArgb(A, R, G, B);
    }
}