namespace PersonalPlanner.GUI
{
    partial class StatusEditLayout
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
            MainPanel = new System.Windows.Forms.TableLayoutPanel();
            BackColorPick = new DevExpress.XtraEditors.ColorPickEdit();
            BackColorLabel = new System.Windows.Forms.Label();
            PreviewLabel = new System.Windows.Forms.Label();
            ForeColorLabel = new System.Windows.Forms.Label();
            HatchStyleLabel = new System.Windows.Forms.Label();
            PaintStyleLabel = new System.Windows.Forms.Label();
            DisplayNameLabel = new System.Windows.Forms.Label();
            DisplayNameEdit = new DevExpress.XtraEditors.TextEdit();
            ForeColorPick = new DevExpress.XtraEditors.ColorPickEdit();
            Preview = new System.Windows.Forms.PictureBox();
            PaintStyleList = new DevExpress.XtraEditors.ComboBoxEdit();
            HatchStyleList = new DevExpress.XtraEditors.ComboBoxEdit();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BackColorPick.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DisplayNameEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ForeColorPick.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Preview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PaintStyleList.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HatchStyleList.Properties).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            SetBoundPropertyName(MainPanel, "");
            MainPanel.ColumnCount = 3;
            MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            MainPanel.Controls.Add(BackColorPick, 1, 4);
            MainPanel.Controls.Add(BackColorLabel, 0, 4);
            MainPanel.Controls.Add(PreviewLabel, 2, 0);
            MainPanel.Controls.Add(ForeColorLabel, 0, 3);
            MainPanel.Controls.Add(HatchStyleLabel, 0, 2);
            MainPanel.Controls.Add(PaintStyleLabel, 0, 1);
            MainPanel.Controls.Add(DisplayNameLabel, 0, 0);
            MainPanel.Controls.Add(DisplayNameEdit, 1, 0);
            MainPanel.Controls.Add(ForeColorPick, 1, 3);
            MainPanel.Controls.Add(Preview, 2, 1);
            MainPanel.Controls.Add(PaintStyleList, 1, 1);
            MainPanel.Controls.Add(HatchStyleList, 1, 2);
            MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            MainPanel.Location = new System.Drawing.Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.RowCount = 5;
            MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            MainPanel.Size = new System.Drawing.Size(400, 250);
            MainPanel.TabIndex = 0;
            // 
            // BackColorPick
            // 
            SetBoundPropertyName(BackColorPick, "");
            BackColorPick.Dock = System.Windows.Forms.DockStyle.Fill;
            BackColorPick.EditValue = System.Drawing.Color.Empty;
            BackColorPick.Location = new System.Drawing.Point(83, 214);
            BackColorPick.Name = "BackColorPick";
            BackColorPick.Properties.AutoHeight = false;
            BackColorPick.Properties.AutomaticColor = System.Drawing.Color.Black;
            BackColorPick.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            BackColorPick.Properties.StoreColorAsInteger = true;
            BackColorPick.Size = new System.Drawing.Size(154, 33);
            BackColorPick.TabIndex = 15;
            BackColorPick.EditValueChanged += ColorPick_EditValueChanged;
            // 
            // BackColorLabel
            // 
            BackColorLabel.AutoSize = true;
            SetBoundPropertyName(BackColorLabel, "");
            BackColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            BackColorLabel.Location = new System.Drawing.Point(3, 211);
            BackColorLabel.Name = "BackColorLabel";
            BackColorLabel.Size = new System.Drawing.Size(74, 39);
            BackColorLabel.TabIndex = 14;
            BackColorLabel.Text = "Back Color";
            BackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // ForeColorLabel
            // 
            ForeColorLabel.AutoSize = true;
            SetBoundPropertyName(ForeColorLabel, "");
            ForeColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            ForeColorLabel.Location = new System.Drawing.Point(3, 174);
            ForeColorLabel.Name = "ForeColorLabel";
            ForeColorLabel.Size = new System.Drawing.Size(74, 37);
            ForeColorLabel.TabIndex = 9;
            ForeColorLabel.Text = "Fore Color";
            ForeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HatchStyleLabel
            // 
            HatchStyleLabel.AutoSize = true;
            SetBoundPropertyName(HatchStyleLabel, "");
            HatchStyleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            HatchStyleLabel.Location = new System.Drawing.Point(3, 87);
            HatchStyleLabel.Name = "HatchStyleLabel";
            HatchStyleLabel.Size = new System.Drawing.Size(74, 87);
            HatchStyleLabel.TabIndex = 6;
            HatchStyleLabel.Text = "Hatch Style";
            HatchStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PaintStyleLabel
            // 
            PaintStyleLabel.AutoSize = true;
            SetBoundPropertyName(PaintStyleLabel, "");
            PaintStyleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            PaintStyleLabel.Location = new System.Drawing.Point(3, 37);
            PaintStyleLabel.Name = "PaintStyleLabel";
            PaintStyleLabel.Size = new System.Drawing.Size(74, 50);
            PaintStyleLabel.TabIndex = 4;
            PaintStyleLabel.Text = "Paint Style";
            PaintStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DisplayNameLabel
            // 
            DisplayNameLabel.AutoSize = true;
            SetBoundPropertyName(DisplayNameLabel, "");
            DisplayNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            DisplayNameLabel.Location = new System.Drawing.Point(3, 0);
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
            DisplayNameEdit.Location = new System.Drawing.Point(83, 3);
            DisplayNameEdit.Name = "DisplayNameEdit";
            DisplayNameEdit.Properties.AutoHeight = false;
            DisplayNameEdit.Size = new System.Drawing.Size(154, 31);
            DisplayNameEdit.TabIndex = 3;
            // 
            // ForeColorPick
            // 
            SetBoundPropertyName(ForeColorPick, "");
            ForeColorPick.Dock = System.Windows.Forms.DockStyle.Fill;
            ForeColorPick.EditValue = System.Drawing.Color.Empty;
            ForeColorPick.Location = new System.Drawing.Point(83, 177);
            ForeColorPick.Name = "ForeColorPick";
            ForeColorPick.Properties.AutoHeight = false;
            ForeColorPick.Properties.AutomaticColor = System.Drawing.Color.Black;
            ForeColorPick.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ForeColorPick.Properties.StoreColorAsInteger = true;
            ForeColorPick.Size = new System.Drawing.Size(154, 31);
            ForeColorPick.TabIndex = 8;
            ForeColorPick.EditValueChanged += ColorPick_EditValueChanged;
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
            // PaintStyleList
            // 
            SetBoundPropertyName(PaintStyleList, "");
            PaintStyleList.Dock = System.Windows.Forms.DockStyle.Fill;
            PaintStyleList.Location = new System.Drawing.Point(83, 40);
            PaintStyleList.Name = "PaintStyleList";
            PaintStyleList.Properties.AutoHeight = false;
            PaintStyleList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            PaintStyleList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            PaintStyleList.Size = new System.Drawing.Size(154, 44);
            PaintStyleList.TabIndex = 12;
            PaintStyleList.SelectedIndexChanged += PaintStyleList_SelectedIndexChanged;
            // 
            // HatchStyleList
            // 
            SetBoundPropertyName(HatchStyleList, "");
            HatchStyleList.Dock = System.Windows.Forms.DockStyle.Fill;
            HatchStyleList.Location = new System.Drawing.Point(83, 90);
            HatchStyleList.Name = "HatchStyleList";
            HatchStyleList.Properties.AutoHeight = false;
            HatchStyleList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            HatchStyleList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            HatchStyleList.Size = new System.Drawing.Size(154, 81);
            HatchStyleList.TabIndex = 13;
            HatchStyleList.SelectedIndexChanged += HatchStyleList_SelectedIndexChanged;
            // 
            // StatusEditLayout
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(MainPanel);
            Name = "StatusEditLayout";
            Size = new System.Drawing.Size(400, 250);
            VisibleChanged += StatusEditTest_VisibleChanged;
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BackColorPick.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)DisplayNameEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ForeColorPick.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Preview).EndInit();
            ((System.ComponentModel.ISupportInitialize)PaintStyleList.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)HatchStyleList.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainPanel;
        private System.Windows.Forms.Label DisplayNameLabel;
        private System.Windows.Forms.Label ForeColorLabel;
        private System.Windows.Forms.Label HatchStyleLabel;
        private System.Windows.Forms.Label PaintStyleLabel;
        private System.Windows.Forms.Label PreviewLabel;
        private System.Windows.Forms.PictureBox Preview;
        private DevExpress.XtraEditors.TextEdit DisplayNameEdit;
        private DevExpress.XtraEditors.ColorPickEdit ForeColorPick;
        private DevExpress.XtraEditors.ComboBoxEdit PaintStyleList;
        private DevExpress.XtraEditors.ComboBoxEdit HatchStyleList;
        private DevExpress.XtraEditors.ColorPickEdit BackColorPick;
        private System.Windows.Forms.Label BackColorLabel;
    }
}
