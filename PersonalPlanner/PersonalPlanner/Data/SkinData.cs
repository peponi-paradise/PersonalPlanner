using DevExpress.LookAndFeel;
using System.Threading.Tasks;

namespace PersonalPlanner.Data
{
    public static class SkinData
    {
        /*-------------------------------------------
         *
         *      Public functions
         *
         -------------------------------------------*/

        public static void SaveAllSkinData()
        {
            var settings = Properties.Settings.Default;
            settings.SkinName = UserLookAndFeel.Default.SkinName;
            settings.Palette = UserLookAndFeel.Default.ActiveSvgPaletteName;
        }

        public static async Task SaveAllSkinDataAsync() => await Task.Run(() => { SaveAllSkinData(); });
    }
}