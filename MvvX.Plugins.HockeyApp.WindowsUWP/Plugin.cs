using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace MvvX.Plugins.HockeyApp.WindowsUWP
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IHockeyClient>(new HockeyClientWindowsUWP());
        }
    }
}
