using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkCalendar.Data;

namespace WorkCalendar.Dev.Test
{
    public partial class MemoForm : DevExpress.XtraEditors.XtraForm
    {
        public delegate void MemoUpdateEventHandler(List<MemoDefine> memoData);

        public event MemoUpdateEventHandler MemoUpdated;

        private List<MemoDefine> MemoList = new List<MemoDefine>();

        public MemoForm()
        {
            InitializeComponent();
            MdiManager.PageRemoved += MdiManager_PageRemoved;
        }

        public MemoForm(List<MemoDefine> MemoList)
        {
            InitializeComponent();
            this.MemoList = MemoList;
            MdiManager.PageRemoved += MdiManager_PageRemoved;
            SetMemos();
        }

        private void MdiManager_PageRemoved(object sender, MdiTabPageEventArgs e)
        {
            var memo = MemoList.Find(memo => memo.Name == e.Page.Text);
            if (memo != null) MemoList.Remove(memo);
        }

        private void NewMemo_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rtn = XtraInputBox.Show("Enter a memo name", "New Memo", "Memo");
            if (rtn != null && CheckDuplicated(rtn) == false)
            {
                MemoDefine memo = new MemoDefine();
                memo.Name = rtn;
                MemoList.Add(memo);
                MemoUI memoUI = new MemoUI(memo);
                memoUI.PropertyChanged += Memo_PropertyChanged;
                memoUI.MemoUpdated += MemoUI_MemoUpdated;
                memoUI.MdiParent = this;
                memoUI.Show();
                SetTabSetting(memo);
            }
        }

        private void MemoUI_MemoUpdated(MemoDefine memoData)
        {
            foreach (var memo in MemoList)
            {
                if (memo.Name == memoData.Name)
                {
                    memo.Memo = memoData.Memo;
                    break;
                }
            }
        }

        private void Memo_PropertyChanged(MemoDefine memoData)
        {
            foreach (var memo in MemoList)
            {
                if (memo.Name == memoData.Name)
                {
                    memo.Font = memoData.Font;
                    memo.FontColor = memoData.FontColor;
                    memo.BackColor = memoData.BackColor;
                    SetTabSetting(memoData);
                    break;
                }
            }
        }

        private bool CheckDuplicated(string name)
        {
            foreach (var memo in MemoList)
            {
                if (memo.Name == name)
                {
                    XtraMessageBox.Show("Duplicated name of Memo has been detected\nTry other name");
                    return true;
                }
            }
            return false;
        }

        private void SetMemos()
        {
            foreach (var memo in MemoList)
            {
                MemoUI memoUI = new MemoUI(memo);
                memoUI.PropertyChanged += Memo_PropertyChanged;
                memoUI.MemoUpdated += MemoUI_MemoUpdated;
                memoUI.MdiParent = this;
                memoUI.Show();
                SetTabSetting(memo);
            }
        }

        private void SetTabSetting(MemoDefine memoDefine)
        {
            foreach (XtraMdiTabPage page in MdiManager.Pages)
            {
                if (page.Text == memoDefine.Name)
                {
                    page.Appearance.Header.BackColor = memoDefine.BackColor;
                    page.Appearance.HeaderActive.BackColor = memoDefine.BackColor;
                    break;
                }
            }
        }
    }
}