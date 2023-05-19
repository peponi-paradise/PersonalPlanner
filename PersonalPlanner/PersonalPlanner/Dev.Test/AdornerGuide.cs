using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalPlanner.Dev.Test
{
    public record GuideInformation
    {
        public string Description;
        public object TargetControl;
        public Point TargetLocation;
    }

    public class AdornerGuide
    {
        /*-------------------------------------------
         *
         *      Events
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Public members
         *
         -------------------------------------------*/

        public List<GuideInformation> GuideList;

        /*-------------------------------------------
         *
         *      Private members
         *
         -------------------------------------------*/

        private AdornerGuideFlyout Flyout;
        private AdornerUIManager Manager;
        private Guide Guide;

        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        public AdornerGuide(List<GuideInformation> guideList, ContainerControl owner)
        {
            GuideList = guideList;
            Flyout = new AdornerGuideFlyout(this, guideList.Count);
            Manager = new AdornerUIManager();
            Manager.Owner = owner;
            Manager.QueryGuideFlyoutControl += Manager_QueryGuideFlyoutControl;
            Guide = new Guide();
            Manager.Elements.Add(Guide);
        }

        ~AdornerGuide()
        {
        }

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        private void Manager_QueryGuideFlyoutControl(object sender, QueryGuideFlyoutControlEventArgs e)
        {
            e.Control = Flyout;
        }

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public void StartGuide()
        {
            Manager.ShowGuides = DevExpress.Utils.DefaultBoolean.True;
            SetGuide(Flyout.CurrentGuideIndex);
        }

        public void EndGuide()
        {
            Manager.ShowGuides = DevExpress.Utils.DefaultBoolean.Default;
        }

        public void SetGuide(int index)
        {
            if (index < 0 || index > GuideList.Count - 1) return;
            Flyout.LabelText = GuideList[index].Description;
            if (GuideList[index].TargetControl != null) Guide.TargetElement = GuideList[index].TargetControl;
            else Guide.TargetElement = GuideList[index].TargetLocation;
        }

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/
    }
}