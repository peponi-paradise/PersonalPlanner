using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using PersonalPlanner.Data;
using PersonalPlanner.Define;
using PersonalPlanner.GUI.Components;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PersonalPlanner.GUI.Frame
{
    public partial class MainFrame
    {
        /*-------------------------------------------
         *
         *      Events
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Public members
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Private members
         *
         -------------------------------------------*/

        private List<Document> MemoDocs = new List<Document>();
        private List<MemoUI> MemoUIs = new List<MemoUI>();

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        private void NewMemo_Click(object sender, System.EventArgs e)
        {
            var rtnName = XtraInputBox.Show("Please Input Name", "New Memo", "Name");
            if (rtnName != null)
            {
                var checkItem = MemoData.Memos.Find(item => item.Name.Equals(rtnName));
                if (checkItem == default)
                {
                    var memo = new MemoDefine() { Name = rtnName };
                    MemoData.Memos.Add(memo);
                    AddMemoElement(memo);
                    AddMemoWidget(memo);
                    MemoData.SaveData();
                }
                else
                {
                    XtraMessageBox.Show($"Could not make duplicated name of memo : {rtnName}");
                }
            }
        }

        private void MemoFlyout_ShowClicked(AccordionControlElement element)
        {
            Navigation.ClosePopupForm();
            AddOrActivateMemo(element);
        }

        private void MemoDoc_CustomButtonClick(object sender, ButtonEventArgs e)
        {
            var doc = sender as Document;
            if (e.Button == doc.CustomHeaderButtons[0])
            {
                // change font
                FontDialog dialog = new FontDialog();
                dialog.FontMustExist = true;
                dialog.ShowColor = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var memoPage = MemoUIs.Find(ui => ui.MemoData.Name == doc.Caption);
                    memoPage.ChangeFont(dialog.Font, dialog.Color);
                    MemoData.SaveData();
                }
            }
            else if (e.Button == doc.CustomHeaderButtons[1])
            {
                // change backcolor
                var colorEdit = new ColorPickEdit();
                if (XtraDialog.Show(colorEdit, "Choose Color", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    doc.AppearanceCaption.BackColor = colorEdit.Color;
                    doc.AppearanceCaption.BorderColor = colorEdit.Color;
                    var memoPage = MemoUIs.Find(ui => ui.MemoData.Name == doc.Caption);
                    memoPage.ChangeBackgroundColor(colorEdit.Color);
                    MemoData.SaveData();
                }
            }
        }

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        private void InitMemos()
        {
            foreach (var memo in MemoData.Memos)
            {
                if (memo.IsOpened)
                {
                    AddMemoElement(memo);
                    AddMemoWidget(memo);
                }
                else AddMemoElement(memo);
            }
        }

        private void ShowMemoContextMenu(AccordionControlElement element, Point point)
        {
            if (point == default) return;
            var document = MemoDocs.Find(doc => doc.Caption == element.Name);
            if (ActivateWidget(document))
            {
                Navigation.ClosePopupForm();
                ActivateWidget(document);
                return;
            }

            var memo = MemoData.Memos.Find(item => item.Name == element.Name);
            var flyout = new MemoFlyout(memo);
            flyout.ShowClicked += () => MemoFlyout_ShowClicked(element);
            if (Navigation.IsPopupFormShown) flyout.Show(Navigation.PopupForm, Navigation.PopupForm, point);
            else flyout.Show(this, point);
        }

        private void AddMemoElement(MemoDefine memoData)
        {
            AccordionControlElement element = new AccordionControlElement();
            element.Name = memoData.Name;
            element.Text = memoData.Name;
            element.Style = ElementStyle.Item;
            GroupMemoLists.Elements.Add(element);
            Navigation.RegisterElementClick(element);
        }

        private void RemoveMemoElement(MemoDefine memoData) => GroupMemoLists.Elements.Remove(GroupMemoLists.Elements.Single(elem => elem.Name == memoData.Name));

        private void AddOrActivateMemo(AccordionControlElement element)
        {
            // Add or activate widget
            var document = MemoDocs.Find(doc => doc.Caption == element.Name);
            if (ActivateWidget(document)) return;
            else AddMemoWidget(MemoData.Memos.Find(item => item.Name.Equals(element.Name)));
        }

        private void AddMemoWidget(MemoDefine memoData)
        {
            MemoUI memoUI = new MemoUI(memoData);
            memoUI.Name = memoData.Name;
            var doc = View.AddDocument(memoUI, memoData.Name) as Document;
            doc.ImageOptions.ImageUri = "bo_note;Size16x16";
            SetDocumentBorderColor(doc, memoData.BackColor.ToDrawingColor());
            MemoDocs.Add(doc);
            MemoUIs.Add(memoUI);
            doc.CustomHeaderButtons.Add(new CustomHeaderButton("Font", "changefontstyle;Size16x16", HorizontalImageLocation.Default, ButtonStyle.PushButton, "Change Font Setting", false, 0, -1));
            doc.CustomHeaderButtons.Add(new CustomHeaderButton("BackgroundColor", "pagecolor;Size16x16", HorizontalImageLocation.Default, ButtonStyle.PushButton, "Change Widget Color", false, 1, -1));
            doc.CustomButtonClick += MemoDoc_CustomButtonClick;
        }

        private void RemoveMemoDoc(Document doc)
        {
            MemoDocs.Remove(doc);
            var ui = MemoUIs.Find(item => item.MemoData.Name == doc.Caption);
            MemoUIs.Remove(ui);
        }

        private void RemoveMemoData(Document doc)
        {
            var memo = MemoData.Memos.Find(item => item.Name == doc.Caption);
            RemoveMemoElement(memo);
            MemoData.Memos.Remove(memo);
            MemoData.SaveData();
        }

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/

        private void SaveMemoWidgetStatus()
        {
            foreach (var item in MemoData.Memos)
            {
                if (MemoUIs.Find(ui => ui.MemoData == item) != null) item.IsOpened = true;
                else item.IsOpened = false;
            }
            MemoData.SaveData();
        }
    }
}