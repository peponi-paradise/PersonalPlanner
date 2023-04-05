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
            this.MainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PreviewLabel = new System.Windows.Forms.Label();
            this.ColorLabel = new System.Windows.Forms.Label();
            this.HatchStyleLabel = new System.Windows.Forms.Label();
            this.PaintStyleLabel = new System.Windows.Forms.Label();
            this.DisplayNameLabel = new System.Windows.Forms.Label();
            this.DisplayNameEdit = new DevExpress.XtraEditors.TextEdit();
            this.IdLabel = new System.Windows.Forms.Label();
            this.IDEdit = new DevExpress.XtraEditors.TextEdit();
            this.PaintStyleList = new DevExpress.XtraEditors.ImageListBoxControl();
            this.HatchStyleList = new DevExpress.XtraEditors.ListBoxControl();
            this.ColorPick = new DevExpress.XtraEditors.ColorPickEdit();
            this.Preview = new System.Windows.Forms.PictureBox();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayNameEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaintStyleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HatchStyleList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPick.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.SetBoundPropertyName(this.MainPanel, "");
            this.MainPanel.ColumnCount = 3;
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainPanel.Controls.Add(this.PreviewLabel, 2, 0);
            this.MainPanel.Controls.Add(this.ColorLabel, 0, 4);
            this.MainPanel.Controls.Add(this.HatchStyleLabel, 0, 3);
            this.MainPanel.Controls.Add(this.PaintStyleLabel, 0, 2);
            this.MainPanel.Controls.Add(this.DisplayNameLabel, 0, 1);
            this.MainPanel.Controls.Add(this.DisplayNameEdit, 1, 1);
            this.MainPanel.Controls.Add(this.IdLabel, 0, 0);
            this.MainPanel.Controls.Add(this.IDEdit, 1, 0);
            this.MainPanel.Controls.Add(this.PaintStyleList, 1, 2);
            this.MainPanel.Controls.Add(this.HatchStyleList, 1, 3);
            this.MainPanel.Controls.Add(this.ColorPick, 1, 4);
            this.MainPanel.Controls.Add(this.Preview, 2, 1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RowCount = 5;
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.MainPanel.Size = new System.Drawing.Size(400, 250);
            this.MainPanel.TabIndex = 0;
            // 
            // PreviewLabel
            // 
            this.PreviewLabel.AutoSize = true;
            this.SetBoundPropertyName(this.PreviewLabel, "");
            this.PreviewLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewLabel.Location = new System.Drawing.Point(243, 0);
            this.PreviewLabel.Name = "PreviewLabel";
            this.PreviewLabel.Size = new System.Drawing.Size(154, 37);
            this.PreviewLabel.TabIndex = 10;
            this.PreviewLabel.Text = "Preview";
            this.PreviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorLabel
            // 
            this.ColorLabel.AutoSize = true;
            this.SetBoundPropertyName(this.ColorLabel, "");
            this.ColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorLabel.Location = new System.Drawing.Point(3, 211);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(74, 39);
            this.ColorLabel.TabIndex = 9;
            this.ColorLabel.Text = "Color";
            this.ColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HatchStyleLabel
            // 
            this.HatchStyleLabel.AutoSize = true;
            this.SetBoundPropertyName(this.HatchStyleLabel, "");
            this.HatchStyleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HatchStyleLabel.Location = new System.Drawing.Point(3, 149);
            this.HatchStyleLabel.Name = "HatchStyleLabel";
            this.HatchStyleLabel.Size = new System.Drawing.Size(74, 62);
            this.HatchStyleLabel.TabIndex = 6;
            this.HatchStyleLabel.Text = "Hatch Style";
            this.HatchStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PaintStyleLabel
            // 
            this.PaintStyleLabel.AutoSize = true;
            this.SetBoundPropertyName(this.PaintStyleLabel, "");
            this.PaintStyleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaintStyleLabel.Location = new System.Drawing.Point(3, 74);
            this.PaintStyleLabel.Name = "PaintStyleLabel";
            this.PaintStyleLabel.Size = new System.Drawing.Size(74, 75);
            this.PaintStyleLabel.TabIndex = 4;
            this.PaintStyleLabel.Text = "Paint Style";
            this.PaintStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DisplayNameLabel
            // 
            this.DisplayNameLabel.AutoSize = true;
            this.SetBoundPropertyName(this.DisplayNameLabel, "");
            this.DisplayNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayNameLabel.Location = new System.Drawing.Point(3, 37);
            this.DisplayNameLabel.Name = "DisplayNameLabel";
            this.DisplayNameLabel.Size = new System.Drawing.Size(74, 37);
            this.DisplayNameLabel.TabIndex = 2;
            this.DisplayNameLabel.Text = "Display Name";
            this.DisplayNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DisplayNameEdit
            // 
            this.SetBoundPropertyName(this.DisplayNameEdit, "");
            this.DisplayNameEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayNameEdit.Location = new System.Drawing.Point(83, 40);
            this.DisplayNameEdit.Name = "DisplayNameEdit";
            this.DisplayNameEdit.Size = new System.Drawing.Size(154, 20);
            this.DisplayNameEdit.TabIndex = 3;
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.SetBoundPropertyName(this.IdLabel, "");
            this.IdLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IdLabel.Location = new System.Drawing.Point(3, 0);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(74, 37);
            this.IdLabel.TabIndex = 0;
            this.IdLabel.Text = "ID";
            this.IdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDEdit
            // 
            this.SetBoundPropertyName(this.IDEdit, "");
            this.IDEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDEdit.Location = new System.Drawing.Point(83, 3);
            this.IDEdit.Name = "IDEdit";
            this.IDEdit.Size = new System.Drawing.Size(154, 20);
            this.IDEdit.TabIndex = 1;
            // 
            // PaintStyleList
            // 
            this.SetBoundPropertyName(this.PaintStyleList, "");
            this.PaintStyleList.Dock = System.Windows.Forms.DockStyle.Fill;
            imageListBoxItemImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("imageListBoxItemImageOptions1.Image")));
            imageListBoxItemImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("imageListBoxItemImageOptions2.Image")));
            this.PaintStyleList.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("Solid", "Solid", imageListBoxItemImageOptions1, null),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("Hatch", "Hatch", imageListBoxItemImageOptions2, null)});
            this.PaintStyleList.Location = new System.Drawing.Point(83, 77);
            this.PaintStyleList.Name = "PaintStyleList";
            this.PaintStyleList.Size = new System.Drawing.Size(154, 69);
            this.PaintStyleList.TabIndex = 5;
            this.PaintStyleList.SelectedIndexChanged += new System.EventHandler(this.PaintStyleList_SelectedIndexChanged);
            // 
            // HatchStyleList
            // 
            this.SetBoundPropertyName(this.HatchStyleList, "");
            this.HatchStyleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HatchStyleList.Location = new System.Drawing.Point(83, 152);
            this.HatchStyleList.Name = "HatchStyleList";
            this.HatchStyleList.Size = new System.Drawing.Size(154, 56);
            this.HatchStyleList.TabIndex = 7;
            this.HatchStyleList.SelectedIndexChanged += new System.EventHandler(this.HatchStyleList_SelectedIndexChanged);
            // 
            // ColorPick
            // 
            this.SetBoundPropertyName(this.ColorPick, "");
            this.ColorPick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorPick.EditValue = System.Drawing.Color.Empty;
            this.ColorPick.Location = new System.Drawing.Point(83, 214);
            this.ColorPick.Name = "ColorPick";
            this.ColorPick.Properties.AutoHeight = false;
            this.ColorPick.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.ColorPick.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ColorPick.Properties.StoreColorAsInteger = true;
            this.ColorPick.Size = new System.Drawing.Size(154, 33);
            this.ColorPick.TabIndex = 8;
            this.ColorPick.EditValueChanged += new System.EventHandler(this.ColorPick_EditValueChanged);
            // 
            // Preview
            // 
            this.SetBoundPropertyName(this.Preview, "");
            this.Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Preview.Location = new System.Drawing.Point(243, 40);
            this.Preview.Name = "Preview";
            this.MainPanel.SetRowSpan(this.Preview, 4);
            this.Preview.Size = new System.Drawing.Size(154, 207);
            this.Preview.TabIndex = 11;
            this.Preview.TabStop = false;
            // 
            // StatusEditTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.MainPanel);
            this.Name = "StatusEditTest";
            this.Size = new System.Drawing.Size(400, 250);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayNameEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaintStyleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HatchStyleList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPick.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).EndInit();
            this.ResumeLayout(false);

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
        private DevExpress.XtraEditors.ListBoxControl HatchStyleList;
        private DevExpress.XtraEditors.ColorPickEdit ColorPick;
        private System.Windows.Forms.Label PreviewLabel;
        private System.Windows.Forms.PictureBox Preview;
    }
}
