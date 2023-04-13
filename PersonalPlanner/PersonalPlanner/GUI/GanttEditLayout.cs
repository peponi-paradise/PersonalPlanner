using DevExpress.XtraTreeList;
using PersonalPlanner.Define;
using System;

namespace PersonalPlanner.GUI
{
    public partial class GanttEditLayout : EditFormUserControl
    {
        public GanttEditLayout()
        {
            InitializeComponent();

            SetBoundFieldName(IDEdit, nameof(Task.ID));
            SetBoundFieldName(ParentIDEdit, nameof(Task.ParentID));
            SetBoundFieldName(NameEdit, nameof(Task.Name));
            SetBoundFieldName(StartDateEdit, nameof(Task.StartDate));
            SetBoundFieldName(FinishDateEdit, nameof(Task.FinishDate));
            SetBoundFieldName(ProgressEdit, nameof(Task.Progress));
            SetBoundFieldName(ResponsibilityEdit, nameof(Task.Responsibility));

            StartDateEdit.EditValueChanging += StartDateEdit_EditValueChanging;
            FinishDateEdit.EditValueChanging += FinishDateEdit_EditValueChanging;
        }

        private void FinishDateEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if((DateTime)e.NewValue<StartDateEdit.DateTime)e.NewValue=StartDateEdit.DateTime;
        }

        private void StartDateEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if ((DateTime)e.NewValue > FinishDateEdit.DateTime) e.NewValue = FinishDateEdit.DateTime;
        }

        private void InitializeComponent()
        {
            MainPanel = new System.Windows.Forms.TableLayoutPanel();
            ResponsibilityEdit = new DevExpress.XtraEditors.TextEdit();
            ProgressEdit = new DevExpress.XtraEditors.TextEdit();
            FinishDateEdit = new DevExpress.XtraEditors.DateEdit();
            ParentIDEdit = new DevExpress.XtraEditors.TextEdit();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            IDEdit = new DevExpress.XtraEditors.TextEdit();
            NameEdit = new DevExpress.XtraEditors.TextEdit();
            StartDateEdit = new DevExpress.XtraEditors.DateEdit();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ResponsibilityEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProgressEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FinishDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FinishDateEdit.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ParentIDEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IDEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NameEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartDateEdit.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartDateEdit.Properties.CalendarTimeProperties).BeginInit();
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
            MainPanel.Controls.Add(ResponsibilityEdit, 1, 2);
            MainPanel.Controls.Add(ProgressEdit, 5, 1);
            MainPanel.Controls.Add(FinishDateEdit, 3, 1);
            MainPanel.Controls.Add(ParentIDEdit, 3, 0);
            MainPanel.Controls.Add(label7, 0, 2);
            MainPanel.Controls.Add(label6, 4, 1);
            MainPanel.Controls.Add(label5, 2, 1);
            MainPanel.Controls.Add(label4, 0, 1);
            MainPanel.Controls.Add(label1, 0, 0);
            MainPanel.Controls.Add(label2, 2, 0);
            MainPanel.Controls.Add(label3, 4, 0);
            MainPanel.Controls.Add(IDEdit, 1, 0);
            MainPanel.Controls.Add(NameEdit, 5, 0);
            MainPanel.Controls.Add(StartDateEdit, 1, 1);
            MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            MainPanel.Location = new System.Drawing.Point(0, 0);
            MainPanel.Margin = new System.Windows.Forms.Padding(0);
            MainPanel.Name = "MainPanel";
            MainPanel.RowCount = 3;
            MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.3333321F));
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
            ResponsibilityEdit.Location = new System.Drawing.Point(103, 69);
            ResponsibilityEdit.Name = "ResponsibilityEdit";
            ResponsibilityEdit.Properties.AutoHeight = false;
            ResponsibilityEdit.Size = new System.Drawing.Size(93, 28);
            ResponsibilityEdit.TabIndex = 13;
            // 
            // ProgressEdit
            // 
            SetBoundPropertyName(ProgressEdit, "");
            ProgressEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            ProgressEdit.EditValue = 0;
            ProgressEdit.Location = new System.Drawing.Point(499, 36);
            ProgressEdit.Name = "ProgressEdit";
            ProgressEdit.Properties.AutoHeight = false;
            ProgressEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            ProgressEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            ProgressEdit.Size = new System.Drawing.Size(98, 27);
            ProgressEdit.TabIndex = 12;
            // 
            // FinishDateEdit
            // 
            SetBoundPropertyName(FinishDateEdit, "");
            FinishDateEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            FinishDateEdit.EditValue = null;
            FinishDateEdit.Location = new System.Drawing.Point(301, 36);
            FinishDateEdit.Name = "FinishDateEdit";
            FinishDateEdit.Properties.AutoHeight = false;
            FinishDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            FinishDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            FinishDateEdit.Size = new System.Drawing.Size(93, 27);
            FinishDateEdit.TabIndex = 11;
            // 
            // ParentIDEdit
            // 
            SetBoundPropertyName(ParentIDEdit, "");
            ParentIDEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            ParentIDEdit.EditValue = -1;
            ParentIDEdit.Location = new System.Drawing.Point(301, 3);
            ParentIDEdit.Name = "ParentIDEdit";
            ParentIDEdit.Properties.AutoHeight = false;
            ParentIDEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            ParentIDEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            ParentIDEdit.Size = new System.Drawing.Size(93, 27);
            ParentIDEdit.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            SetBoundPropertyName(label7, "");
            label7.Dock = System.Windows.Forms.DockStyle.Fill;
            label7.Location = new System.Drawing.Point(3, 66);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(94, 34);
            label7.TabIndex = 6;
            label7.Text = "Responsibility";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            SetBoundPropertyName(label6, "");
            label6.Dock = System.Windows.Forms.DockStyle.Fill;
            label6.Location = new System.Drawing.Point(400, 33);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(93, 33);
            label6.TabIndex = 5;
            label6.Text = "Progress";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            SetBoundPropertyName(label5, "");
            label5.Dock = System.Windows.Forms.DockStyle.Fill;
            label5.Location = new System.Drawing.Point(202, 33);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(93, 33);
            label5.TabIndex = 4;
            label5.Text = "Finish Date";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            SetBoundPropertyName(label4, "");
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Location = new System.Drawing.Point(3, 33);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(94, 33);
            label4.TabIndex = 3;
            label4.Text = "Start Date";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            SetBoundPropertyName(label1, "");
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(94, 33);
            label1.TabIndex = 0;
            label1.Text = "ID";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            SetBoundPropertyName(label2, "");
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(202, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(93, 33);
            label2.TabIndex = 1;
            label2.Text = "Parent ID";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            SetBoundPropertyName(label3, "");
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(400, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(93, 33);
            label3.TabIndex = 2;
            label3.Text = "Name";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDEdit
            // 
            SetBoundPropertyName(IDEdit, "");
            IDEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            IDEdit.EditValue = 0;
            IDEdit.Location = new System.Drawing.Point(103, 3);
            IDEdit.Name = "IDEdit";
            IDEdit.Properties.AutoHeight = false;
            IDEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            IDEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            IDEdit.Size = new System.Drawing.Size(93, 27);
            IDEdit.TabIndex = 7;
            // 
            // NameEdit
            // 
            SetBoundPropertyName(NameEdit, "");
            NameEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            NameEdit.EditValue = "New Name";
            NameEdit.Location = new System.Drawing.Point(499, 3);
            NameEdit.Name = "NameEdit";
            NameEdit.Properties.AutoHeight = false;
            NameEdit.Size = new System.Drawing.Size(98, 27);
            NameEdit.TabIndex = 9;
            // 
            // StartDateEdit
            // 
            SetBoundPropertyName(StartDateEdit, "");
            StartDateEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            StartDateEdit.EditValue = null;
            StartDateEdit.Location = new System.Drawing.Point(103, 36);
            StartDateEdit.Name = "StartDateEdit";
            StartDateEdit.Properties.AutoHeight = false;
            StartDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            StartDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            StartDateEdit.Size = new System.Drawing.Size(93, 27);
            StartDateEdit.TabIndex = 10;
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
            ((System.ComponentModel.ISupportInitialize)ProgressEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)FinishDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)FinishDateEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ParentIDEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)IDEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)NameEdit.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartDateEdit.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartDateEdit.Properties).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit IDEdit;
        private DevExpress.XtraEditors.TextEdit ProgressEdit;
        private DevExpress.XtraEditors.DateEdit FinishDateEdit;
        private DevExpress.XtraEditors.TextEdit ParentIDEdit;
        private DevExpress.XtraEditors.TextEdit NameEdit;
        private DevExpress.XtraEditors.DateEdit StartDateEdit;
        private DevExpress.XtraEditors.TextEdit ResponsibilityEdit;
        private System.Windows.Forms.TableLayoutPanel MainPanel;
    }
}