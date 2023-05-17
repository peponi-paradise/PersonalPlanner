namespace PersonalPlanner.Dev.Test
{
    partial class MemoFlyout
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
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoFlyout));
            MemoPreview = new DevExpress.XtraEditors.MemoEdit();
            Flyout = new DevExpress.Utils.FlyoutPanel();
            FlyoutControl = new DevExpress.Utils.FlyoutPanelControl();
            ((System.ComponentModel.ISupportInitialize)MemoPreview.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Flyout).BeginInit();
            Flyout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FlyoutControl).BeginInit();
            FlyoutControl.SuspendLayout();
            SuspendLayout();
            // 
            // MemoPreview
            // 
            MemoPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            MemoPreview.Location = new System.Drawing.Point(2, 2);
            MemoPreview.Margin = new System.Windows.Forms.Padding(0);
            MemoPreview.Name = "MemoPreview";
            MemoPreview.Properties.AcceptsTab = true;
            MemoPreview.Size = new System.Drawing.Size(296, 166);
            MemoPreview.TabIndex = 0;
            // 
            // Flyout
            // 
            Flyout.Controls.Add(FlyoutControl);
            Flyout.Location = new System.Drawing.Point(0, 0);
            Flyout.Name = "Flyout";
            Flyout.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Left;
            Flyout.OptionsButtonPanel.AllowGlyphSkinning = true;
            Flyout.OptionsButtonPanel.ButtonPanelContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            Flyout.OptionsButtonPanel.ButtonPanelLocation = DevExpress.Utils.FlyoutPanelButtonPanelLocation.Bottom;
            buttonImageOptions1.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("buttonImageOptions1.SvgImage");
            Flyout.OptionsButtonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.Utils.PeekFormButton("Show", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false) });
            Flyout.OptionsButtonPanel.ShowButtonPanel = true;
            Flyout.Padding = new System.Windows.Forms.Padding(0, 0, 0, 30);
            Flyout.Size = new System.Drawing.Size(300, 200);
            Flyout.TabIndex = 1;
            Flyout.ButtonClick += Flyout_ButtonClick;
            // 
            // FlyoutControl
            // 
            FlyoutControl.Controls.Add(MemoPreview);
            FlyoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            FlyoutControl.FlyoutPanel = Flyout;
            FlyoutControl.Location = new System.Drawing.Point(0, 0);
            FlyoutControl.Name = "FlyoutControl";
            FlyoutControl.Size = new System.Drawing.Size(300, 170);
            FlyoutControl.TabIndex = 0;
            // 
            // MemoFlyout
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(Flyout);
            Name = "MemoFlyout";
            Size = new System.Drawing.Size(300, 200);
            ((System.ComponentModel.ISupportInitialize)MemoPreview.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Flyout).EndInit();
            Flyout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FlyoutControl).EndInit();
            FlyoutControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraEditors.MemoEdit MemoPreview;
        private DevExpress.Utils.FlyoutPanel Flyout;
        private DevExpress.Utils.FlyoutPanelControl FlyoutControl;
    }
}
