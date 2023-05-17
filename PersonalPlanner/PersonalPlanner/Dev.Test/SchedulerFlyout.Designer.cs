namespace PersonalPlanner.Dev.Test
{
    partial class SchedulerFlyout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedulerFlyout));
            Flyout = new DevExpress.Utils.FlyoutPanel();
            FlyoutControl = new DevExpress.Utils.FlyoutPanelControl();
            ((System.ComponentModel.ISupportInitialize)Flyout).BeginInit();
            Flyout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FlyoutControl).BeginInit();
            SuspendLayout();
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
            Flyout.Size = new System.Drawing.Size(600, 300);
            Flyout.TabIndex = 1;
            Flyout.ButtonClick += Flyout_ButtonClick;
            // 
            // FlyoutControl
            // 
            FlyoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            FlyoutControl.FlyoutPanel = Flyout;
            FlyoutControl.Location = new System.Drawing.Point(0, 0);
            FlyoutControl.Name = "FlyoutControl";
            FlyoutControl.Size = new System.Drawing.Size(600, 270);
            FlyoutControl.TabIndex = 0;
            // 
            // SchedulerFlyout
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(Flyout);
            Name = "SchedulerFlyout";
            Size = new System.Drawing.Size(600, 300);
            ((System.ComponentModel.ISupportInitialize)Flyout).EndInit();
            Flyout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FlyoutControl).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.Utils.FlyoutPanel Flyout;
        private DevExpress.Utils.FlyoutPanelControl FlyoutControl;
    }
}
