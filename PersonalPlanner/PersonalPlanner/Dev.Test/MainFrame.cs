using DevExpress.XtraBars.Navigation;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Views.Widget;

namespace PersonalPlanner.Dev.Test
{
    public partial class MainFrame : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public MainFrame()
        {
            InitializeComponent();

            SetOverFlowButton();
            InitScheduler();

            Navigation.ElementClicked += Navigation_ElementClicked;
            View.DocumentClosed += View_DocumentClosed;

            AccordionControlElement element = new AccordionControlElement();
            element.Name = "AAA";
            element.Text = "AAA";
            element.Style = ElementStyle.Item;
            GroupMemoLists.Elements.Add(element);

            element = new AccordionControlElement();
            element.Name = "BBB";
            element.Text = "BBB";
            element.Style = ElementStyle.Item;
            GroupMemoLists.Elements.Add(element);

            Navigation.RegisterElementClick(GroupMemoLists);

            Calendar.Click += CalendarLabel_Click;
            Calendar.ContextButtons[0].Click += CalendarShowButton_Click;
            Scheduler.Click += Scheduler_Click;
            Scheduler.ContextButtons[0].Click += SchedulerShowButton_Click;
        }

        private void View_DocumentClosed(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            if (e.Document == SchedulerDoc) InitSchedulerOnly();
            else if (MemoDocs.Contains((Document)e.Document)) RemoveMemoDoc((Document)e.Document);
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

        private void Navigation_ElementClicked(AccordionControlElement element, Point point) => ShowMemoContextMenu(element, point);

        private bool ActivateWidget(AccordionControlElement element)
        {
            // Activate widget
            var doc = View.Documents.FindFirst(item => item.Caption == element.Name);
            if (doc != null) View.Controller.Activate(doc);
            else return false;
            return true;
        }

        private bool ActivateWidget(DevExpress.XtraBars.Docking2010.Views.Widget.Document doc)
        {
            // Activate widget
            if (View.Documents.Contains(doc)) View.Controller.Activate(doc);
            else return false;
            return true;
        }
    }
}