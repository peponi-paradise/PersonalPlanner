using DevExpress.LookAndFeel;
using System.Threading.Tasks;

namespace WorkCalendar.Data
{
    public static class SkinData
    {
        public static async Task SaveAllSkinData()
        {
            await Task.Run(() =>
            {
                var settings = Properties.Settings.Default;
                settings.SkinName = UserLookAndFeel.Default.SkinName;
                settings.Palette = UserLookAndFeel.Default.ActiveSvgPaletteName;
                settings.Save();
            });
        }
    }
}