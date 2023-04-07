using System.Drawing;

namespace WorkCalendar.Data
{
    public class MemoDefine
    {
        public string Name = "";
        public string Memo = "";
        public Font Font { get; set; } = new Font("Consolas", 9);
        public Color FontColor { get; set; } = Color.Black;
        public Color BackColor { get; set; } = Color.White;
    }
}