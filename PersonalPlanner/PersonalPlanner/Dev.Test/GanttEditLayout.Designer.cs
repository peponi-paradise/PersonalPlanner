namespace PersonalPlanner.Dev.Test
{
    public partial class GanttEditLayout
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

        private void InitializeComponent()
        {
            MainPanel = new System.Windows.Forms.TableLayoutPanel();
            ResponsibilityEdit = new DevExpress.XtraEditors.TextEdit();
            FinishDateEdit = new DevExpress.XtraEditors.DateEdit();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            NameEdit = new DevExpress.XtraEditors.TextEdit();
            StartDateEdit = new DevExpress.XtraEditors.DateEdit();
            ProgressEdit = new DevExpress.XtraEditors.SpinEdit();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ResponsibilityEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FinishDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FinishDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NameEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProgressEdit.Properties).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            SetBoundPropertyName(MainPanel, "");
            MainPanel.ColumnCount = 6;
            MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6666718F));
            MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6666679F));
            MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6666679F));
            MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6666679F));
            MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6666679F));
            MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6666679F));
            MainPanel.Controls.Add(ResponsibilityEdit, 3, 0);
            MainPanel.Controls.Add(FinishDateEdit, 3, 1);
            MainPanel.Controls.Add(label7, 2, 0);
            MainPanel.Controls.Add(label6, 4, 1);
            MainPanel.Controls.Add(label5, 2, 1);
            MainPanel.Controls.Add(label4, 0, 1);
            MainPanel.Controls.Add(label3, 0, 0);
            MainPanel.Controls.Add(NameEdit, 1, 0);
            MainPanel.Controls.Add(StartDateEdit, 1, 1);
            MainPanel.Controls.Add(ProgressEdit, 5, 1);
            MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            MainPanel.Location = new System.Drawing.Point(0, 0);
            MainPanel.Margin = new System.Windows.Forms.Padding(0);
            MainPanel.Name = "MainPanel";
            MainPanel.RowCount = 2;
            MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
            MainPanel.Size = new System.Drawing.Size(600, 100);
            MainPanel.TabIndex = 0;
            // 
            // ResponsibilityEdit
            // 
            SetBoundPropertyName(ResponsibilityEdit, "");
            ResponsibilityEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            ResponsibilityEdit.EditValue = "None";
            ResponsibilityEdit.Location = new System.Drawing.Point(301, 3);
            ResponsibilityEdit.Name = "ResponsibilityEdit";
            ResponsibilityEdit.Properties.AutoHeight = false;
            ResponsibilityEdit.Size = new System.Drawing.Size(93, 44);
            ResponsibilityEdit.TabIndex = 13;
            // 
            // FinishDateEdit
            // 
            SetBoundPropertyName(FinishDateEdit, "");
            FinishDateEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            FinishDateEdit.EditValue = null;
            FinishDateEdit.Location = new System.Drawing.Point(301, 53);
            FinishDateEdit.Name = "FinishDateEdit";
            FinishDateEdit.Properties.AutoHeight = false;
            FinishDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            FinishDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            FinishDateEdit.Size = new System.Drawing.Size(93, 44);
            FinishDateEdit.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            SetBoundPropertyName(label7, "");
            label7.Dock = System.Windows.Forms.DockStyle.Fill;
            label7.Location = new System.Drawing.Point(202, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(93, 50);
            label7.TabIndex = 6;
            label7.Text = "Responsibility";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            SetBoundPropertyName(label6, "");
            label6.Dock = System.Windows.Forms.DockStyle.Fill;
            label6.Location = new System.Drawing.Point(400, 50);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(93, 50);
            label6.TabIndex = 5;
            label6.Text = "Progress";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            SetBoundPropertyName(label5, "");
            label5.Dock = System.Windows.Forms.DockStyle.Fill;
            label5.Location = new System.Drawing.Point(202, 50);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(93, 50);
            label5.TabIndex = 4;
            label5.Text = "Finish Date";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            SetBoundPropertyName(label4, "");
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Location = new System.Drawing.Point(3, 50);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(94, 50);
            label4.TabIndex = 3;
            label4.Text = "Start Date";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            SetBoundPropertyName(label3, "");
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(94, 50);
            label3.TabIndex = 2;
            label3.Text = "Name";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameEdit
            // 
            SetBoundPropertyName(NameEdit, "");
            NameEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            NameEdit.EditValue = "New Name";
            NameEdit.Location = new System.Drawing.Point(103, 3);
            NameEdit.Name = "NameEdit";
            NameEdit.Properties.AutoHeight = false;
            NameEdit.Size = new System.Drawing.Size(93, 44);
            NameEdit.TabIndex = 9;
            // 
            // StartDateEdit
            // 
            SetBoundPropertyName(StartDateEdit, "");
            StartDateEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            StartDateEdit.EditValue = null;
            StartDateEdit.Location = new System.Drawing.Point(103, 53);
            StartDateEdit.Name = "StartDateEdit";
            StartDateEdit.Properties.AutoHeight = false;
            StartDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            StartDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            StartDateEdit.Size = new System.Drawing.Size(93, 44);
            StartDateEdit.TabIndex = 10;
            // 
            // ProgressEdit
            // 
            SetBoundPropertyName(ProgressEdit, "");
            ProgressEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            ProgressEdit.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            ProgressEdit.Location = new System.Drawing.Point(499, 53);
            ProgressEdit.Name = "ProgressEdit";
            ProgressEdit.Properties.AutoHeight = false;
            ProgressEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ProgressEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            ProgressEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            ProgressEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            ProgressEdit.Size = new System.Drawing.Size(98, 44);
            ProgressEdit.TabIndex = 12;
            // 
            // GanttEditLayout
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(MainPanel);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "GanttEditLayout";
            Size = new System.Drawing.Size(600, 100);
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ResponsibilityEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)FinishDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)FinishDateEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)NameEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartDateEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProgressEdit.Properties).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit FinishDateEdit;
        private DevExpress.XtraEditors.DateEdit StartDateEdit;
        private DevExpress.XtraEditors.TextEdit ResponsibilityEdit;
        private System.Windows.Forms.TableLayoutPanel MainPanel;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit NameEdit;
        private DevExpress.XtraEditors.SpinEdit ProgressEdit;
    }
}