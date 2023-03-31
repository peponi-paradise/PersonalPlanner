using DevExpress.LookAndFeel;
using System.Threading.Tasks;

namespace WorkCalendar.Data
{
    public static class SkinData
    {
        public static void SaveAllSkinData()
        {
            var settings = Properties.Settings.Default;
            settings.SkinName = UserLookAndFeel.Default.SkinName;
            settings.Palette = UserLookAndFeel.Default.ActiveSvgPaletteName;
            settings.Save();
        }

        public static async Task SaveAllSkinDataAsync()
        {
            await Task.Run(() =>
            {
                SaveAllSkinData();
            });
        }
    }
}