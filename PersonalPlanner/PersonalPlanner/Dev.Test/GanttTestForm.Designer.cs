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
            ((System.ComponentModel.ISupportInitialize)MainGanttControl).BeginInit();
            SuspendLayout();
            // 
            // MainGanttControl
            // 
            MainGanttControl.Location = new System.Drawing.Point(12, 12);
            MainGanttControl.Name = "MainGanttControl";
            MainGanttControl.NewItemRowText = "Click here to add a new row";
            MainGanttControl.OptionsBehavior.ResizeNodes = false;
            MainGanttControl.OptionsMenu.ShowAddNodeItems = DevExpress.Utils.DefaultBoolean.True;
            MainGanttControl.OptionsView.NewItemRowPosition = DevExpress.XtraTreeList.TreeListNewItemRowPosition.Top;
            MainGanttControl.OptionsView.ShowHorzLines = true;
            MainGanttControl.OptionsView.ShowIndicator = true;
            MainGanttControl.Size = new System.Drawing.Size(826, 426);
            MainGanttControl.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(844, 12);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(148, 134);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(844, 152);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(148, 134);
            button2.TabIndex = 1;
            button2.Text = "button1";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // GanttTestForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1004, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(MainGanttControl);
            Name = "GanttTestForm";
            Text = "GanttTestForm";
            ((System.ComponentModel.ISupportInitialize)MainGanttControl).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGantt.GanttControl MainGanttControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}