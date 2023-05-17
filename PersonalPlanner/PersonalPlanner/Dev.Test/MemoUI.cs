using DevExpress.XtraEditors;
using PersonalPlanner.Define;
using System;

namespace PersonalPlanner.Dev.Test
{
    public partial class MemoUI : XtraUserControl
    {
        /*-------------------------------------------
         *
         *      Design time properties
         *
         -------------------------------------------*/

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
         *      Private members
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        public MemoUI() => InitializeComponent();

        public MemoUI(MemoDefine memoData)
        {
            InitializeComponent();
            MemoData = memoData;
            SetBackgroundColor();
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

        public void ChangeBackgroundColor(System.Drawing.Color color)
        {
            MemoData.BackColor.ToInternalColor(color);
            SetBackgroundColor();
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

        private void SetBackgroundColor() => MainMemo.BackColor = MemoData.BackColor.ToDrawingColor();

        private void SetFont()
        {
            MainMemo.Font = MemoData.Font.ToDrawingFont();
            MainMemo.ForeColor = MemoData.FontColor.ToDrawingColor();
        }

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/
    }
}