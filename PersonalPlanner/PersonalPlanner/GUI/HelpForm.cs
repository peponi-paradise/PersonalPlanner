using CefSharp.WinForms;
using System.Windows.Forms;

namespace PersonalPlanner.GUI
{
    public partial class HelpForm : DevExpress.XtraEditors.XtraForm
    {
        private ChromiumWebBrowser WebBrowser;

        public HelpForm()
        {
            InitializeComponent();
        }

        public HelpForm(string htmlPath)
        {
            InitializeComponent();
            InitHelp(htmlPath);
        }

        private void InitHelp(string htmlPath)
        {
            WebBrowser = new ChromiumWebBrowser(htmlPath);
            WebBrowser.Dock = DockStyle.Fill;
            this.Controls.Add(WebBrowser);
        }
    }
}