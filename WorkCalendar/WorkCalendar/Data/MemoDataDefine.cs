using System.Drawing;

namespace WorkCalendar.Data
{
    public class Font
    {
        public float Size = 9;
        public FontStyle Style = FontStyle.Regular;
        public string Name = "맑은 고딕";
        public GraphicsUnit Unit = GraphicsUnit.Point;
    }

    public class Color
    {
        public int R = 0, G = 0, B = 0, A = 0;
    }

    public class MemoDefine
    {
        public string Name = "";
        public string Memo = "";

        public Font Font = new Font();
        public Color FontColor = new();

        public Color BackColor = new();

        public void ToInternalFont(System.Drawing.Font f)
        {
            Font.Size = f.Size;
            Font.Style = f.Style;
            Font.Name = f.Name;
            Font.Unit = f.Unit;
        }

        public System.Drawing.Font ToDrawingFont()
        {
            return new System.Drawing.Font(Font.Name, Font.Size, Font.Style, Font.Unit);
        }

        public Color ToInternalColor(System.Drawing.Color color)
        {
            return new Color() { A = color.A, R = color.R, G = color.G, B = color.B };
        }

        public System.Drawing.Color ToDrawingColor(Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}