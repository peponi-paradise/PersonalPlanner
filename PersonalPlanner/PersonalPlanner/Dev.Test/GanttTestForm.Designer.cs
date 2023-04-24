namespace PersonalPlanner.Dev.Test
{
    partial class GanttTestForm
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
            MainGanttControl = new DevExpress.XtraGantt.GanttControl();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)MainGanttControl).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // MainGanttControl
            // 
            MainGanttControl.Dock = System.Windows.Forms.DockStyle.Fill;
            MainGanttControl.Location = new System.Drawing.Point(3, 3);
            MainGanttControl.Name = "MainGanttControl";
            MainGanttControl.NewItemRowText = "Click here to add a new row";
            MainGanttControl.OptionsBehavior.ResizeNodes = false;
            MainGanttControl.OptionsMenu.ShowAddNodeItems = DevExpress.Utils.DefaultBoolean.True;
            MainGanttControl.OptionsView.NewItemRowPosition = DevExpress.XtraTreeList.TreeListNewItemRowPosition.Top;
            MainGanttControl.OptionsView.ShowHorzLines = true;
            MainGanttControl.OptionsView.ShowIndicator = true;
            tableLayoutPanel1.SetRowSpan(MainGanttControl, 2);
            MainGanttControl.Size = new System.Drawing.Size(897, 444);
            MainGanttControl.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(906, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(95, 134);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(906, 228);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(95, 134);
            button2.TabIndex = 1;
            button2.Text = "button1";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(MainGanttControl, 0, 0);
            tableLayoutPanel1.Controls.Add(button2, 1, 1);
            tableLayoutPanel1.Controls.Add(button1, 1, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1004, 450);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // GanttTestForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1004, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "GanttTestForm";
            Text = "GanttTestForm";
            ((System.ComponentModel.ISupportInitialize)MainGanttControl).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGantt.GanttControl MainGanttControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}