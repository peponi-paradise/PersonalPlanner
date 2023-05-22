namespace PersonalPlanner.GUI.Forms
{
    partial class LoadingDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingDialog));
            progressBarControl = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            labelCopyright = new DevExpress.XtraEditors.LabelControl();
            labelStatus = new DevExpress.XtraEditors.LabelControl();
            peImage = new DevExpress.XtraEditors.PictureEdit();
            VersionLabel = new DevExpress.XtraEditors.LabelControl();
            peLogo = new DevExpress.XtraEditors.HyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)progressBarControl.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)peImage.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)peLogo.Properties).BeginInit();
            SuspendLayout();
            // 
            // progressBarControl
            // 
            progressBarControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBarControl.EditValue = 0;
            progressBarControl.Location = new System.Drawing.Point(23, 313);
            progressBarControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            progressBarControl.Name = "progressBarControl";
            progressBarControl.Size = new System.Drawing.Size(584, 11);
            progressBarControl.TabIndex = 5;
            // 
            // labelCopyright
            // 
            labelCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            labelCopyright.Location = new System.Drawing.Point(23, 364);
            labelCopyright.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new System.Drawing.Size(265, 14);
            labelCopyright.TabIndex = 6;
            labelCopyright.Text = "Copyright 2023. \"ClockStrikes\" all rights reserved";
            // 
            // labelStatus
            // 
            labelStatus.Location = new System.Drawing.Point(23, 297);
            labelStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 1);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new System.Drawing.Size(55, 14);
            labelStatus.TabIndex = 7;
            labelStatus.Text = "Starting...";
            // 
            // peImage
            // 
            peImage.Dock = System.Windows.Forms.DockStyle.Top;
            peImage.EditValue = resources.GetObject("peImage.EditValue");
            peImage.Location = new System.Drawing.Point(1, 1);
            peImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            peImage.Name = "peImage";
            peImage.Properties.AllowFocused = false;
            peImage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            peImage.Properties.Appearance.Options.UseBackColor = true;
            peImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            peImage.Properties.ShowMenu = false;
            peImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            peImage.Properties.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            peImage.Properties.SvgImageSize = new System.Drawing.Size(250, 250);
            peImage.Size = new System.Drawing.Size(638, 290);
            peImage.TabIndex = 9;
            // 
            // VersionLabel
            // 
            VersionLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            VersionLabel.Appearance.BackColor = System.Drawing.Color.Transparent;
            VersionLabel.Appearance.Options.UseBackColor = true;
            VersionLabel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            VersionLabel.Location = new System.Drawing.Point(570, 260);
            VersionLabel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new System.Drawing.Size(0, 14);
            VersionLabel.TabIndex = 6;
            // 
            // peLogo
            // 
            peLogo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            peLogo.EditValue = "https://peponi-paradise.tistory.com";
            peLogo.Location = new System.Drawing.Point(404, 362);
            peLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            peLogo.Name = "peLogo";
            peLogo.Properties.AllowFocused = false;
            peLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            peLogo.Properties.Appearance.Options.UseBackColor = true;
            peLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            peLogo.Size = new System.Drawing.Size(203, 18);
            peLogo.TabIndex = 8;
            peLogo.TabStop = false;
            // 
            // LoadingDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(640, 400);
            Controls.Add(VersionLabel);
            Controls.Add(peImage);
            Controls.Add(labelStatus);
            Controls.Add(labelCopyright);
            Controls.Add(progressBarControl);
            Controls.Add(peLogo);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "LoadingDialog";
            Padding = new System.Windows.Forms.Padding(1);
            Text = "LoadingScreen";
            ((System.ComponentModel.ISupportInitialize)progressBarControl.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)peImage.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)peLogo.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl progressBarControl;
        private DevExpress.XtraEditors.LabelControl labelCopyright;
        private DevExpress.XtraEditors.LabelControl labelStatus;
        private DevExpress.XtraEditors.PictureEdit peImage;
        private DevExpress.XtraEditors.LabelControl VersionLabel;
        private DevExpress.XtraEditors.HyperLinkEdit peLogo;
    }
}
