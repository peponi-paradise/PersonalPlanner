using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalPlanner.Dev.Test
{
    public partial class AdornerGuideFlyout : DevExpress.XtraEditors.XtraUserControl
    {
        public string LabelText
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public int CurrentGuideIndex = 0;
        private AdornerGuide Guide;

        public AdornerGuideFlyout()
        {
            InitializeComponent();
        }

        public AdornerGuideFlyout(AdornerGuide guide, int guideCount)
        {
            InitializeComponent();
            Guide = guide;
            InitializeNavigator(guideCount);
        }

        private void InitializeNavigator(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.navigator.Buttons.Add(
        new DevExpress.XtraBars.Docking2010.WindowsUIButton("Button", "appointmentnightclock", DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", false, -1, true, null, true, i == CurrentGuideIndex, true, null, null, 1, false, false));
            }
        }

        private void OnNavigatorButtonChecked(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            CurrentGuideIndex = navigator.Buttons.IndexOf(e.Button);
            Guide.SetGuide(CurrentGuideIndex);
        }

        private void OnExitButtonClick(object sender, EventArgs e)
        {
            Guide.EndGuide();
        }

        private void OnBackButtonClick(object sender, EventArgs e)
        {
            CurrentGuideIndex--;
            if (CurrentGuideIndex < 0)
                CurrentGuideIndex = navigator.Buttons.Count - 1;
            navigator.Buttons[CurrentGuideIndex].Properties.Checked = true;
        }

        private void OnNextButtonClick(object sender, EventArgs e)
        {
            CurrentGuideIndex++;
            if (CurrentGuideIndex > navigator.Buttons.Count - 1)
                CurrentGuideIndex = 0;
            navigator.Buttons[CurrentGuideIndex].Properties.Checked = true;
        }
    }
}