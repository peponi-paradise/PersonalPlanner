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

namespace WorkCalendar.GUI
{
    public partial class MemoForm : DevExpress.XtraEditors.XtraForm
    {
        public MemoForm()
        {
            InitializeComponent();
            MdiManager.PageRemoved += MdiManager_PageRemoved;
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
            var memo = MemoData.Memos.Find(memo => memo.Name == e.Page.Text);
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

        public void SetMemos()
        {
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