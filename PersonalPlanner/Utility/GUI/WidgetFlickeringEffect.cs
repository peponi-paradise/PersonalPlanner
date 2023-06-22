using DevExpress.XtraBars.Docking2010.Views.Widget;
using System.Drawing;
using System.Threading.Tasks;

namespace PersonalPlanner.Utility.GUI
{
    public static class WidgetFlickeringEffect
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
         *      Event functions
         *
         -------------------------------------------*/

        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public static async Task Flickering(Document doc)
        {
            var currentColor = doc.AppearanceCaption.BackColor;
            var isDarkColor = IsDarkColor(currentColor);
            int R = isDarkColor ? currentColor.R + 100 : currentColor.R - 100;
            int G = isDarkColor ? currentColor.G + 100 : currentColor.G - 100;
            int B = isDarkColor ? currentColor.B + 100 : currentColor.B - 100;
            if (R < 0) R = 0; else if (R > 255) R = 255;
            if (G < 0) G = 0; else if (G > 255) G = 255;
            if (B < 0) B = 0; else if (B > 255) B = 255;
            Color flickeringColor = Color.FromArgb(R, G, B);

            for (int i = 0; i < 3; i++)
            {
                doc.AppearanceCaption.BackColor = flickeringColor;
                await Task.Delay(100);
                doc.AppearanceCaption.BackColor = currentColor;
                if (i != 2) await Task.Delay(100);
            }
        }

        /*-------------------------------------------
         *
         *      Private functions
         *
         -------------------------------------------*/

        private static bool IsDarkColor(Color color)
        {
            int colorTotal = color.R + color.G + color.B;
            if (colorTotal < (255 * 3) / 2) return true;
            return false;
        }

        /*-------------------------------------------
         *
         *      Helper functions
         *
         -------------------------------------------*/
    }
}