using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using PersonalPlanner.Data;
using PersonalPlanner.Define;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalPlanner.GUI
{
    public partial class MemoForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        public MemoForm()
        {
            InitializeComponent();

            InitialDraw();

            this.FormClosing += MemoForm_FormClosing;
            this.Move += MemoForm_Move;
            this.Resize += MemoForm_Resize;
            MainControl.SelectedPageChanged += MainControl_SelectedPageChanged;
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

        private void MainControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (MainControl.SelectedTabPage != null) TabColor.EditValue = (MainControl.SelectedTabPage as MemoUI).MemoData.BackColor.ToDrawingColor();
        }

        private void MemoUI_MemoUpdated(Define.MemoDefine memoData) => MemoData.SaveDataAsync();

        private void NewMemo_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rtnName = XtraInputBox.Show("Please Input Name", "New Memo", "Name");
            if (rtnName != null)
            {
                var checkItem = MemoData.Memos.Find(item => item.Name.Equals(rtnName));
                if (checkItem == default)
                {
                    var memo = new MemoDefine() { Name = rtnName };
                    MemoData.Memos.Add(memo);
                    MemoUI memoUI = new MemoUI(memo);
                    memoUI.MemoUpdated += MemoUI_MemoUpdated;
                    MainControl.TabPages.Add(memoUI);
                    SaveAndUpdate();
                }
                else
                {
                    XtraMessageBox.Show($"Could not make duplicated name of memo : {rtnName}");
                }
            }
        }

        private void RemoveMemo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MainControl.SelectedTabPage != null)
            {
                if (XtraMessageBox.Show($"Do you want to remove memo? : {MainControl.SelectedTabPage.Text}", "Remove memo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var removeItem = (MainControl.SelectedTabPage as MemoUI).MemoData;
                    MemoData.Memos.Remove(removeItem);
                    MainControl.TabPages.Remove(MainControl.SelectedTabPage);
                    SaveAndUpdate();
                }
            }
        }

        private void TabColor_EditValueChanged(object sender, EventArgs e)
        {
            if (MainControl.SelectedTabPage != null)
            {
                var memoPage = MainControl.SelectedTabPage as MemoUI;
                memoPage.ChangeTabPageColor((System.Drawing.Color)TabColor.EditValue);
                SaveAndUpdate();
            }
        }

        private void MemoFont_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MainControl.SelectedTabPage != null)
            {
                FontDialog dialog = new FontDialog();
                dialog.FontMustExist = true;
                dialog.ShowColor = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var memoPage = MainControl.SelectedTabPage as MemoUI;
                    memoPage.ChangeFont(dialog.Font, dialog.Color);
                    SaveAndUpdate();
                }
            }
        }

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        private void InitialDraw()
        {
            if (GlobalData.Parameters.MemoFormLocation == new Point(0, 0)) this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = GlobalData.Parameters.MemoFormLocation;
            }
            if (GlobalData.Parameters.MemoFormSize != new Size(0, 0)) this.Size = GlobalData.Parameters.MemoFormSize;

            bool isFirstPage = true;
            foreach (var memoData in MemoData.Memos)
            {
                MemoUI memoUI = new MemoUI(memoData);
                MainControl.TabPages.Add(memoUI);
                memoUI.MemoUpdated += MemoUI_MemoUpdated;
                if (isFirstPage) { TabColor.EditValue = memoUI.MemoData.BackColor.ToDrawingColor(); isFirstPage = false; }
                MainControl.LayoutChanged();
            }
        }

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/

        private void SaveAndUpdate()
        {
            MemoData.SaveData();
            if (MainControl.TabPages != null) MainControl.LayoutChanged();
        }
    }
}