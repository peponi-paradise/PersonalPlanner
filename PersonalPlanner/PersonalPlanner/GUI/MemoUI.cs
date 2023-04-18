using DevExpress.XtraTab;
using PersonalPlanner.Define;
using System;

namespace PersonalPlanner.GUI
{
    public partial class MemoUI : XtraTabPage
    {
        /*-------------------------------------------
         *
         *      Events
         *
         -------------------------------------------*/

        public delegate void MemoUpdateEventHandler(MemoDefine memoData);

        public event MemoUpdateEventHandler MemoUpdated;

        /*-------------------------------------------
         *
         *      Public members
         *
         -------------------------------------------*/

        public MemoDefine MemoData;

        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        public MemoUI(MemoDefine memoData)
        {
            InitializeComponent();
            MemoData = memoData;
            this.Controls.Add(MainMemo);
            this.Text = MemoData.Name;
            SetTabPageColor();
            SetFont();
            MainMemo.Text = MemoData.Memo;
            MainMemo.TextChanged += MainMemo_TextChanged;
        }

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        private void MainMemo_TextChanged(object sender, EventArgs e)
        {
            MemoData.Memo = MainMemo.Text;
            MemoUpdated?.Invoke(MemoData);
        }

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public void ChangeTabPageColor(System.Drawing.Color color)
        {
            MemoData.BackColor.ToInternalColor(color);
            SetTabPageColor();
        }

        public void ChangeFont(System.Drawing.Font font, System.Drawing.Color color)
        {
            MemoData.Font.ToInternalFont(font);
            MemoData.FontColor.ToInternalColor(color);
            SetFont();
        }

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        private void SetTabPageColor()
        {
            this.BackColor = MemoData.BackColor.ToDrawingColor();
            this.Appearance.Header.BackColor = MemoData.BackColor.ToDrawingColor();
            this.Appearance.HeaderActive.BackColor = MemoData.BackColor.ToDrawingColor();
            MainMemo.BackColor = MemoData.BackColor.ToDrawingColor();
        }

        private void SetFont()
        {
            MainMemo.Font = MemoData.Font.ToDrawingFont();
            MainMemo.ForeColor = MemoData.FontColor.ToDrawingColor();
        }
    }
}