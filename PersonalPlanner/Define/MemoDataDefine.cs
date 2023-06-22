namespace PersonalPlanner.Define
{
    public class MemoDefine
    {
        public string Name = "";
        public string Memo = "";

        public Font Font = new Font();
        public Color FontColor = new();

        public Color BackColor = new() { R = 255, G = 255, B = 255, A = 0 };

        public bool IsOpened = false;
    }
}