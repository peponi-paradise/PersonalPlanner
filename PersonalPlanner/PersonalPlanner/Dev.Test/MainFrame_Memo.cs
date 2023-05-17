using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using PersonalPlanner.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalPlanner.Dev.Test
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

        private void MemoFlyout_ShowClicked(AccordionControlElement element)
        {
            Navigation.ClosePopupForm();
            AddOrActivateMemo(element);
        }

        private void Doc_CustomButtonClick(object sender, ButtonEventArgs e)
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
                    //SaveAndUpdate();
                }
            }
            else if (e.Button == doc.CustomHeaderButtons[1])
            {
                // change backcolor
                var colorEdit = new ColorPickEdit();
                if (XtraDialog.Show(colorEdit, "Choose Color", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //doc.AppearanceCaption.BackColor = colorEdit.Color;
                    //doc.AppearanceCaption.BorderColor = colorEdit.Color;
                    var memoPage = MemoUIs.Find(ui => ui.MemoData.Name == doc.Caption);
                    memoPage.ChangeBackgroundColor(colorEdit.Color);
                    //SaveAndUpdate();
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

            var flyout = new MemoFlyout();
            flyout.ShowClicked += () => MemoFlyout_ShowClicked(element);
            if (Navigation.IsPopupFormShown) flyout.Show(Navigation.PopupForm, Navigation.PopupForm, point);
            else flyout.Show(this, point);
        }

        private void AddOrActivateMemo(AccordionControlElement element)
        {
            // Add or activate widget
            var document = MemoDocs.Find(doc => doc.Caption == element.Name);
            if (ActivateWidget(document)) return;
            else AddMemoWidget(element.Name);
        }

        private void AddMemoWidget(string name)
        {
            //MemoUI memoUI = new MemoUI(MemoData);
            MemoUI memoUI = new MemoUI(new Define.MemoDefine() { Name = name });
            memoUI.Name = name;
            var doc = View.AddDocument(memoUI, name) as Document;
            MemoDocs.Add(doc);
            MemoUIs.Add(memoUI);
            doc.CustomHeaderButtons.Add(new CustomHeaderButton("Font", "changefontstyle;Size16x16", HorizontalImageLocation.Default, ButtonStyle.PushButton, "Change Font Setting", false, 0, -1));
            doc.CustomHeaderButtons.Add(new CustomHeaderButton("BackgroundColor", "pagecolor;Size16x16", HorizontalImageLocation.Default, ButtonStyle.PushButton, "Change Background Color", false, 1, -1));
            doc.CustomButtonClick += Doc_CustomButtonClick;
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
            MemoData.Memos.Remove(memo);
        }

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/
    }
}