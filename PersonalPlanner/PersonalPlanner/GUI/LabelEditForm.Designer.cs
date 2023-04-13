namespace PersonalPlanner.GUI
{
    partial class LabelEditForm
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
            this.MainGridControl = new DevExpress.XtraGrid.GridControl();
            this.MainGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGridControl
            // 
            this.MainGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGridControl.Location = new System.Drawing.Point(0, 0);
            this.MainGridControl.MainView = this.MainGridView;
            this.MainGridControl.Name = "MainGridControl";
            this.MainGridControl.Size = new System.Drawing.Size(800, 450);
            this.MainGridControl.TabIndex = 0;
            this.MainGridControl.UseEmbeddedNavigator = true;
            this.MainGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MainGridView});
            // 
            // MainGridView
            // 
            this.MainGridView.GridControl = this.MainGridControl;
            this.MainGridView.Name = "MainGridView";
            this.MainGridView.OptionsView.ShowGroupPanel = false;
            // 
            // LabelEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainGridControl);
            this.Name = "LabelEditForm";
            this.Text = "Label Editor";
            ((System.ComponentModel.ISupportInitialize)(this.MainGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl MainGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView MainGridView;
    }
}