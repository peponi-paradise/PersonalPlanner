using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PersonalPlanner.Dev.Test
{
    public partial class MainFrame : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public MainFrame()
        {
            InitializeComponent();

            SetOverFlowButton();
            //NavigationControl.HtmlTemplates.FooterOverflowButton.Template = "< div class=\"container\"><div id = \"dx - item\" class=\"button\"><div class=\"content\"><div class=\"dot\"></div><div class=\"dot\"></div><div class=\"dot\"></div></div></div></div>";
            //NavigationControl.HtmlTemplates.FooterOverflowButton.Styles = ".button {\r\n    padding: 7px;\r\n    border-radius: 3px;\r\n    margin: 1px;\r\n}\r\n\r\n.content{\r\n    display: flex;\r\n    width: 32px;\r\n    height: 32px;\r\n    align-items: center;\r\n    justify-content: center;\r\n}\r\n\r\n.dot {\r\n    width: 2px;\r\n    height: 2px;\r\n    background-color: #000000;\r\n    box-shadow: 0px 0px 2px #FFFFFF;\r\n    margin: 2px;\r\n}";
        }

        private void SetOverFlowButton()
        {
            bool isDarkMode = DevExpress.Utils.Frames.FrameHelper.IsDarkSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);

            string html = File.ReadAllText($@"{Application.StartupPath}\Assets\MainFrameOverFlowButton.html");
            string css = "";
            if (isDarkMode) css = File.ReadAllText($@"{Application.StartupPath}\Assets\MainFrameOverFlowButtonDarkMode.css");
            else css = File.ReadAllText($@"{Application.StartupPath}\Assets\MainFrameOverFlowButtonLightMode.css");

            Navigation.HtmlTemplates.FooterOverflowButton.Template = html;
            Navigation.HtmlTemplates.FooterOverflowButton.Styles = css;
        }
    }
}