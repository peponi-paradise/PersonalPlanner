namespace PersonalPlanner.GUI
{
    partial class MemoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoForm));
            MainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            NewMemo = new DevExpress.XtraBars.BarButtonItem();
            RemoveMemo = new DevExpress.XtraBars.BarButtonItem();
            TabColor = new DevExpress.XtraBars.BarEditItem();
            repositoryItemColorPickEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            MemoFont = new DevExpress.XtraBars.BarButtonItem();
            OptionsRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            RibbonPageGroupMemo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            RibbonPageGroupMemoItems = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            repositoryItemFontEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
            MainControl = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)MainRibbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemColorPickEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemFontEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainControl).BeginInit();
            SuspendLayout();
            // 
            // MainRibbonControl
            // 
            MainRibbonControl.AllowMdiChildButtons = false;
            MainRibbonControl.ExpandCollapseItem.Id = 0;
            MainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { MainRibbonControl.ExpandCollapseItem, MainRibbonControl.SearchEditItem, NewMemo, RemoveMemo, TabColor, MemoFont });
            MainRibbonControl.Location = new System.Drawing.Point(0, 0);
            MainRibbonControl.MaxItemId = 6;
            MainRibbonControl.Name = "MainRibbonControl";
            MainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { OptionsRibbonPage });
            MainRibbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemColorPickEdit1, repositoryItemFontEdit1 });
            MainRibbonControl.ShowQatLocationSelector = false;
            MainRibbonControl.ShowToolbarCustomizeItem = false;
            MainRibbonControl.Size = new System.Drawing.Size(478, 160);
            MainRibbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // NewMemo
            // 
            NewMemo.Caption = "New Memo";
            NewMemo.Id = 1;
            NewMemo.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("NewMemo.ImageOptions.SvgImage");
            NewMemo.Name = "NewMemo";
            NewMemo.ItemClick += NewMemo_ItemClick;
            // 
            // RemoveMemo
            // 
            RemoveMemo.Caption = "Remove Memo";
            RemoveMemo.Id = 2;
            RemoveMemo.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("RemoveMemo.ImageOptions.SvgImage");
            RemoveMemo.Name = "RemoveMemo";
            RemoveMemo.ItemClick += RemoveMemo_ItemClick;
            // 
            // TabColor
            // 
            TabColor.Caption = "Memo Color";
            TabColor.Edit = repositoryItemColorPickEdit1;
            TabColor.Id = 3;
            TabColor.Name = "TabColor";
            TabColor.EditValueChanged += TabColor_EditValueChanged;
            // 
            // repositoryItemColorPickEdit1
            // 
            repositoryItemColorPickEdit1.AutoHeight = false;
            repositoryItemColorPickEdit1.AutomaticColor = System.Drawing.Color.Black;
            repositoryItemColorPickEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemColorPickEdit1.Name = "repositoryItemColorPickEdit1";
            // 
            // MemoFont
            // 
            MemoFont.Caption = "Font";
            MemoFont.Id = 5;
            MemoFont.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("MemoFont.ImageOptions.SvgImage");
            MemoFont.Name = "MemoFont";
            MemoFont.ItemClick += MemoFont_ItemClick;
            // 
            // OptionsRibbonPage
            // 
            OptionsRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { RibbonPageGroupMemo, RibbonPageGroupMemoItems });
            OptionsRibbonPage.Name = "OptionsRibbonPage";
            OptionsRibbonPage.Text = "Options";
            // 
            // RibbonPageGroupMemo
            // 
            RibbonPageGroupMemo.ItemLinks.Add(NewMemo);
            RibbonPageGroupMemo.ItemLinks.Add(RemoveMemo);
            RibbonPageGroupMemo.Name = "RibbonPageGroupMemo";
            RibbonPageGroupMemo.Text = "Memo Options";
            // 
            // RibbonPageGroupMemoItems
            // 
            RibbonPageGroupMemoItems.ItemLinks.Add(TabColor);
            RibbonPageGroupMemoItems.ItemLinks.Add(MemoFont);
            RibbonPageGroupMemoItems.Name = "RibbonPageGroupMemoItems";
            RibbonPageGroupMemoItems.Text = "Memo Item Options";
            // 
            // repositoryItemFontEdit1
            // 
            repositoryItemFontEdit1.AutoHeight = false;
            repositoryItemFontEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // MainControl
            // 
            MainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            MainControl.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.True;
            MainControl.HeaderButtons = DevExpress.XtraTab.TabButtons.None;
            MainControl.Location = new System.Drawing.Point(0, 160);
            MainControl.MultiLine = DevExpress.Utils.DefaultBoolean.True;
            MainControl.Name = "MainControl";
            MainControl.Size = new System.Drawing.Size(478, 479);
            MainControl.TabIndex = 2;
            // 
            // MemoForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(478, 639);
            Controls.Add(MainControl);
            Controls.Add(MainRibbonControl);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("MemoForm.IconOptions.SvgImage");
            Name = "MemoForm";
            Ribbon = MainRibbonControl;
            Text = "Memo Window";
            ((System.ComponentModel.ISupportInitialize)MainRibbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemColorPickEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemFontEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainControl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl MainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage OptionsRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RibbonPageGroupMemo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RibbonPageGroupMemoItems;
        private DevExpress.XtraTab.XtraTabControl MainControl;
        private DevExpress.XtraBars.BarButtonItem NewMemo;
        private DevExpress.XtraBars.BarButtonItem RemoveMemo;
        private DevExpress.XtraBars.BarEditItem TabColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
        private DevExpress.XtraBars.BarButtonItem MemoFont;
    }
}