using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using PersonalPlanner.Data;
using PersonalPlanner.Define;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalPlanner.GUI
{
    public partial class MemoForm : DevExpress.XtraEditors.XtraForm
    {
        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        public MemoForm()
        {
            InitializeComponent();

            if (GlobalData.Parameters.MemoFormLocation == new Point(0, 0)) this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = GlobalData.Parameters.MemoFormLocation;
            }
            if (GlobalData.Parameters.MemoFormSize != new Size(0, 0)) this.Size = GlobalData.Parameters.MemoFormSize;

            MdiManager.PageRemoved += MdiManager_PageRemoved;
            this.FormClosing += MemoForm_FormClosing;
            this.Move += MemoForm_Move;
            this.Resize += MemoForm_Resize;
        }

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        private void MemoForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized) GlobalData.Parameters.MemoFormSize = this.Size;
        }

        private void MemoForm_Move(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized) GlobalData.Parameters.MemoFormLocation = this.Location;
        }

        private void MemoForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            MemoData.SaveData();
            GlobalData.Parameters.MemoFormLocation = this.Location;
            GlobalData.Parameters.MemoFormSize = this.Size;
        }

        private void NewMemo_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rtn = XtraInputBox.Show("Enter a memo name", "New Memo", "Memo");
            if (rtn != null && CheckDuplicated(rtn) == false)
            {
                MemoDefine memo = new MemoDefine();
                memo.Name = rtn;
                MemoData.Memos.Add(memo);
                MemoUI memoUI = new MemoUI(memo);
                memoUI.PropertyChanged += Memo_PropertyChanged;
                memoUI.MemoUpdated += MemoUI_MemoUpdated;
                memoUI.MdiParent = this;
                memoUI.Show();
                SetTabSetting(memo);
                MemoData.SaveData();
            }
        }

        private void MdiManager_PageRemoved(object sender, MdiTabPageEventArgs e)
        {
            var memo = MemoData.Memos.Find(memo => memo.Name == e.Page.MdiChild.Name);
            if (memo != null)
            {
                MemoData.Memos.Remove(memo);
                MemoData.SaveData();
            }
        }

        private void MemoUI_MemoUpdated(MemoDefine memoData)
        {
            foreach (var memo in MemoData.Memos)
            {
                if (memo.Name == memoData.Name)
                {
                    memo.Memo = memoData.Memo;
                    MemoData.SaveData();
                    break;
                }
            }
        }

        private void Memo_PropertyChanged(MemoDefine memoData)
        {
            foreach (var memo in MemoData.Memos)
            {
                if (memo.Name == memoData.Name)
                {
                    memo.Font = memoData.Font;
                    memo.FontColor = memoData.FontColor;
                    memo.BackColor = memoData.BackColor;
                    SetTabSetting(memoData);
                    MemoData.SaveData();
                    break;
                }
            }
        }

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public void SetMemos()
        {
            MdiManager.Pages.Clear();
            foreach (var memo in MemoData.Memos)
            {
                MemoUI memoUI = new MemoUI(memo);
                memoUI.PropertyChanged += Memo_PropertyChanged;
                memoUI.MemoUpdated += MemoUI_MemoUpdated;
                memoUI.MdiParent = this;
                memoUI.Show();
                SetTabSetting(memo);
            }
        }

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        private void SetTabSetting(MemoDefine memoDefine)
        {
            foreach (XtraMdiTabPage page in MdiManager.Pages)
            {
                if (page.Text == memoDefine.Name)
                {
                    page.Appearance.Header.BackColor = memoDefine.BackColor.ToDrawingColor();
                    page.Appearance.HeaderActive.BackColor = memoDefine.BackColor.ToDrawingColor();
                    break;
                }
            }
        }

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/

        private bool CheckDuplicated(string name)
        {
            foreach (var memo in MemoData.Memos)
            {
                if (memo.Name == name)
                {
                    XtraMessageBox.Show("Duplicated name of Memo has been detected\nTry other name");
                    return true;
                }
            }
            return false;
        }
    }
}