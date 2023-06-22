namespace PersonalPlanner.GUI.Forms
{
    partial class ResourceEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourceEditForm));
            MainGridControl = new DevExpress.XtraGrid.GridControl();
            MainGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)MainGridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainGridView).BeginInit();
            SuspendLayout();
            // 
            // MainGridControl
            // 
            MainGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            MainGridControl.Location = new System.Drawing.Point(0, 0);
            MainGridControl.MainView = MainGridView;
            MainGridControl.Name = "MainGridControl";
            MainGridControl.Size = new System.Drawing.Size(800, 420);
            MainGridControl.TabIndex = 0;
            MainGridControl.UseEmbeddedNavigator = true;
            MainGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { MainGridView });
            // 
            // MainGridView
            // 
            MainGridView.DetailHeight = 327;
            MainGridView.GridControl = MainGridControl;
            MainGridView.Name = "MainGridView";
            MainGridView.OptionsView.ShowGroupPanel = false;
            // 
            // ResourceEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 420);
            Controls.Add(MainGridControl);
            IconOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ResourceEditForm.IconOptions.SvgImage");
            Name = "ResourceEditForm";
            Text = "ResourcesTest";
            ((System.ComponentModel.ISupportInitialize)MainGridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl MainGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView MainGridView;
    }
}