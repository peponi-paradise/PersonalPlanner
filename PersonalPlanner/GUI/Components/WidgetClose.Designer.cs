namespace PersonalPlanner.GUI.Components
{
    partial class WidgetClose
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainPanel = new DevExpress.Utils.Layout.TablePanel();
            RadioPanel = new DevExpress.Utils.Layout.TablePanel();
            WidgetOnly = new System.Windows.Forms.RadioButton();
            WidgetAndData = new System.Windows.Forms.RadioButton();
            labelControl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)MainPanel).BeginInit();
            MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RadioPanel).BeginInit();
            RadioPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 50F) });
            MainPanel.Controls.Add(RadioPanel);
            MainPanel.Controls.Add(labelControl);
            MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            MainPanel.Location = new System.Drawing.Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F) });
            MainPanel.Size = new System.Drawing.Size(300, 150);
            MainPanel.TabIndex = 0;
            // 
            // RadioPanel
            // 
            MainPanel.SetColumn(RadioPanel, 1);
            RadioPanel.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F) });
            MainPanel.SetColumnSpan(RadioPanel, 2);
            RadioPanel.Controls.Add(WidgetOnly);
            RadioPanel.Controls.Add(WidgetAndData);
            RadioPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            RadioPanel.Location = new System.Drawing.Point(53, 33);
            RadioPanel.Name = "RadioPanel";
            MainPanel.SetRow(RadioPanel, 1);
            RadioPanel.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 26F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 26F) });
            MainPanel.SetRowSpan(RadioPanel, 2);
            RadioPanel.Size = new System.Drawing.Size(194, 84);
            RadioPanel.TabIndex = 1;
            // 
            // WidgetOnly
            // 
            WidgetOnly.AutoSize = true;
            WidgetOnly.Checked = true;
            RadioPanel.SetColumn(WidgetOnly, 0);
            WidgetOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            WidgetOnly.Location = new System.Drawing.Point(3, 3);
            WidgetOnly.Name = "WidgetOnly";
            RadioPanel.SetRow(WidgetOnly, 0);
            WidgetOnly.Size = new System.Drawing.Size(188, 36);
            WidgetOnly.TabIndex = 0;
            WidgetOnly.TabStop = true;
            WidgetOnly.Text = "Widget only";
            WidgetOnly.UseVisualStyleBackColor = true;
            // 
            // WidgetAndData
            // 
            WidgetAndData.AutoSize = true;
            RadioPanel.SetColumn(WidgetAndData, 0);
            WidgetAndData.Dock = System.Windows.Forms.DockStyle.Fill;
            WidgetAndData.Location = new System.Drawing.Point(3, 45);
            WidgetAndData.Name = "WidgetAndData";
            RadioPanel.SetRow(WidgetAndData, 1);
            WidgetAndData.Size = new System.Drawing.Size(188, 36);
            WidgetAndData.TabIndex = 0;
            WidgetAndData.Text = "Widget and data";
            WidgetAndData.UseVisualStyleBackColor = true;
            // 
            // labelControl
            // 
            MainPanel.SetColumn(labelControl, 0);
            MainPanel.SetColumnSpan(labelControl, 4);
            labelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            labelControl.Location = new System.Drawing.Point(5, 3);
            labelControl.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            labelControl.Name = "labelControl";
            MainPanel.SetRow(labelControl, 0);
            labelControl.Size = new System.Drawing.Size(292, 24);
            labelControl.TabIndex = 0;
            labelControl.Text = "   Please select remove mode";
            // 
            // WidgetClose
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(MainPanel);
            Name = "WidgetClose";
            Size = new System.Drawing.Size(300, 150);
            ((System.ComponentModel.ISupportInitialize)MainPanel).EndInit();
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RadioPanel).EndInit();
            RadioPanel.ResumeLayout(false);
            RadioPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel MainPanel;
        private DevExpress.Utils.Layout.TablePanel RadioPanel;
        private System.Windows.Forms.RadioButton WidgetOnly;
        private System.Windows.Forms.RadioButton WidgetAndData;
        private DevExpress.XtraEditors.LabelControl labelControl;
    }
}
