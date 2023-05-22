using PersonalPlanner.Data;
using System;

namespace PersonalPlanner.GUI.Frame
{
    public partial class MainFrame
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

        /*-------------------------------------------
         *
         *      Private members
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Constructor / Destructor
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Event functions
         *
         -------------------------------------------*/

        private void SkinPaletteGallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            GlobalData.Parameters.SkinPaletteName = e.Item.Caption;
            SetOverFlowButton();
            ResetGanttWidgets();
        }

        private void SkinGallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            SkinGalleryEdit.EditValue = GlobalData.Parameters.SkinName = e.Item.Caption;
            SetOverFlowButton();
            ResetGanttWidgets();
        }

        private void WorkingTimeStart_EditValueChanged(object sender, System.EventArgs e)
        {
            GlobalData.Parameters.OfficeStart = (TimeSpan)WorkingTimeStart.EditValue;
            SetWorkingTime();
        }

        private void WorkingTimeEnd_EditValueChanged(object sender, System.EventArgs e)
        {
            GlobalData.Parameters.OfficeEnd = (TimeSpan)WorkingTimeEnd.EditValue;
            SetWorkingTime();
        }

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

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