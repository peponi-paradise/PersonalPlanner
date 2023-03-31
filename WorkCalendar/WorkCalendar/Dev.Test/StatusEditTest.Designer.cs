namespace WorkCalendar.Dev.Test
{
    partial class StatusEditTest
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.Controls.ImageListBoxItemImageOptions imageListBoxItemImageOptions1 = new DevExpress.XtraEditors.Controls.ImageListBoxItemImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusEditTest));
            DevExpress.XtraEditors.Controls.ImageListBoxItemImageOptions imageListBoxItemImageOptions2 = new DevExpress.XtraEditors.Controls.ImageListBoxItemImageOptions();
            MainPanel = new System.Windows.Forms.TableLayoutPanel();
            IdLabel = new System.Windows.Forms.Label();
            IDEdit = new DevExpress.XtraEditors.TextEdit();
            DisplayNameLabel = new System.Windows.Forms.Label();
            DisplayNameEdit = new DevExpress.XtraEditors.TextEdit();
            PaintStyleLabel = new System.Windows.Forms.Label();
            PaintStyleList = new DevExpress.XtraEditors.ImageListBoxControl();
            HatchStyleLabel = new System.Windows.Forms.Label();
            listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            ColorPick = new DevExpress.XtraEditors.ColorPickEdit();
            ColorLabel = new System.Windows.Forms.Label();
            PreviewLabel = new System.Windows.Forms.Label();
            Preview = new System.Windows.Forms.PictureBox();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IDEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DisplayNameEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PaintStyleList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)listBoxControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ColorPick.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Preview).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            SetBoundPropertyName(MainPanel, "");
            MainPanel.ColumnCount = 3;
            MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            MainPanel.Controls.Add(PreviewLabel, 2, 0);
            MainPanel.Controls.Add(ColorLabel, 0, 4);
            MainPanel.Controls.Add(HatchStyleLabel, 0, 3);
            MainPanel.Controls.Add(PaintStyleLabel, 0, 2);
            MainPanel.Controls.Add(DisplayNameLabel, 0, 1);
            MainPanel.Controls.Add(DisplayNameEdit, 1, 1);
            MainPanel.Controls.Add(IdLabel, 0, 0);
            MainPanel.Controls.Add(IDEdit, 1, 0);
            MainPanel.Controls.Add(PaintStyleList, 1, 2);
            MainPanel.Controls.Add(listBoxControl1, 1, 3);
            MainPanel.Controls.Add(ColorPick, 1, 4);
            MainPanel.Controls.Add(Preview, 2, 1);
            MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            MainPanel.Location = new System.Drawing.Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.RowCount = 5;
            MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            MainPanel.Size = new System.Drawing.Size(400, 250);
            MainPanel.TabIndex = 0;
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            SetBoundPropertyName(IdLabel, "");
            IdLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            IdLabel.Location = new System.Drawing.Point(3, 0);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new System.Drawing.Size(74, 37);
            IdLabel.TabIndex = 0;
            IdLabel.Text = "ID";
            IdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDEdit
            // 
            SetBoundPropertyName(IDEdit, "");
            IDEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            IDEdit.Location = new System.Drawing.Point(83, 3);
            IDEdit.Name = "IDEdit";
            IDEdit.Size = new System.Drawing.Size(154, 20);
            IDEdit.TabIndex = 1;
            // 
            // DisplayNameLabel
            // 
            DisplayNameLabel.AutoSize = true;
            SetBoundPropertyName(DisplayNameLabel, "");
            DisplayNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            DisplayNameLabel.Location = new System.Drawing.Point(3, 37);
            DisplayNameLabel.Name = "DisplayNameLabel";
            DisplayNameLabel.Size = new System.Drawing.Size(74, 37);
            DisplayNameLabel.TabIndex = 2;
            DisplayNameLabel.Text = "Display Name";
            DisplayNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DisplayNameEdit
            // 
            SetBoundPropertyName(DisplayNameEdit, "");
            DisplayNameEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            DisplayNameEdit.Location = new System.Drawing.Point(83, 40);
            DisplayNameEdit.Name = "DisplayNameEdit";
            DisplayNameEdit.Size = new System.Drawing.Size(154, 20);
            DisplayNameEdit.TabIndex = 3;
            // 
            // PaintStyleLabel
            // 
            PaintStyleLabel.AutoSize = true;
            SetBoundPropertyName(PaintStyleLabel, "");
            PaintStyleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            PaintStyleLabel.Location = new System.Drawing.Point(3, 74);
            PaintStyleLabel.Name = "PaintStyleLabel";
            PaintStyleLabel.Size = new System.Drawing.Size(74, 75);
            PaintStyleLabel.TabIndex = 4;
            PaintStyleLabel.Text = "Paint Style";
            PaintStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PaintStyleList
            // 
            SetBoundPropertyName(PaintStyleList, "");
            PaintStyleList.Dock = System.Windows.Forms.DockStyle.Fill;
            imageListBoxItemImageOptions1.Image = (System.Drawing.Image)resources.GetObject("imageListBoxItemImageOptions1.Image");
            imageListBoxItemImageOptions2.Image = (System.Drawing.Image)resources.GetObject("imageListBoxItemImageOptions2.Image");
            PaintStyleList.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] { new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, "Solid", imageListBoxItemImageOptions1, null), new DevExpress.XtraEditors.Controls.ImageListBoxItem(null, "Hatch", imageListBoxItemImageOptions2, null) });
            PaintStyleList.Location = new System.Drawing.Point(83, 77);
            PaintStyleList.Name = "PaintStyleList";
            PaintStyleList.Size = new System.Drawing.Size(154, 69);
            PaintStyleList.TabIndex = 5;
            // 
            // HatchStyleLabel
            // 
            HatchStyleLabel.AutoSize = true;
            SetBoundPropertyName(HatchStyleLabel, "");
            HatchStyleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            HatchStyleLabel.Location = new System.Drawing.Point(3, 149);
            HatchStyleLabel.Name = "HatchStyleLabel";
            HatchStyleLabel.Size = new System.Drawing.Size(74, 62);
            HatchStyleLabel.TabIndex = 6;
            HatchStyleLabel.Text = "Hatch Style";
            HatchStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxControl1
            // 
            SetBoundPropertyName(listBoxControl1, "");
            listBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            listBoxControl1.Location = new System.Drawing.Point(83, 152);
            listBoxControl1.Name = "listBoxControl1";
            listBoxControl1.Size = new System.Drawing.Size(154, 56);
            listBoxControl1.TabIndex = 7;
            // 
            // ColorPick
            // 
            SetBoundPropertyName(ColorPick, "");
            ColorPick.Dock = System.Windows.Forms.DockStyle.Fill;
            ColorPick.EditValue = System.Drawing.Color.Empty;
            ColorPick.Location = new System.Drawing.Point(83, 214);
            ColorPick.Name = "ColorPick";
            ColorPick.Properties.AutoHeight = false;
            ColorPick.Properties.AutomaticColor = System.Drawing.Color.Black;
            ColorPick.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ColorPick.Properties.StoreColorAsInteger = true;
            ColorPick.Size = new System.Drawing.Size(154, 33);
            ColorPick.TabIndex = 8;
            // 
            // ColorLabel
            // 
            ColorLabel.AutoSize = true;
            SetBoundPropertyName(ColorLabel, "");
            ColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            ColorLabel.Location = new System.Drawing.Point(3, 211);
            ColorLabel.Name = "ColorLabel";
            ColorLabel.Size = new System.Drawing.Size(74, 39);
            ColorLabel.TabIndex = 9;
            ColorLabel.Text = "Color";
            ColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PreviewLabel
            // 
            PreviewLabel.AutoSize = true;
            SetBoundPropertyName(PreviewLabel, "");
            PreviewLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            PreviewLabel.Location = new System.Drawing.Point(243, 0);
            PreviewLabel.Name = "PreviewLabel";
            PreviewLabel.Size = new System.Drawing.Size(154, 37);
            PreviewLabel.TabIndex = 10;
            PreviewLabel.Text = "Preview";
            PreviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Preview
            // 
            SetBoundPropertyName(Preview, "");
            Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            Preview.Location = new System.Drawing.Point(243, 40);
            Preview.Name = "Preview";
            MainPanel.SetRowSpan(Preview, 4);
            Preview.Size = new System.Drawing.Size(154, 207);
            Preview.TabIndex = 11;
            Preview.TabStop = false;
            // 
            // StatusEditTest
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(MainPanel);
            Name = "StatusEditTest";
            Size = new System.Drawing.Size(400, 250);
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IDEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DisplayNameEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)PaintStyleList).EndInit();
            ((System.ComponentModel.ISupportInitialize)listBoxControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ColorPick.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Preview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainPanel;
        private System.Windows.Forms.Label DisplayNameLabel;
        private DevExpress.XtraEditors.TextEdit DisplayNameEdit;
        private System.Windows.Forms.Label IdLabel;
        private DevExpress.XtraEditors.TextEdit IDEdit;
        private System.Windows.Forms.Label ColorLabel;
        private System.Windows.Forms.Label HatchStyleLabel;
        private System.Windows.Forms.Label PaintStyleLabel;
        private DevExpress.XtraEditors.ImageListBoxControl PaintStyleList;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraEditors.ColorPickEdit ColorPick;
        private System.Windows.Forms.Label PreviewLabel;
        private System.Windows.Forms.PictureBox Preview;
    }
}
