using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Plugins;

namespace MvvX.Plugins.HockeyApp.Droid
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            Mvx.RegisterSingleton<IHockeyClient>(new HockeyClientDroid(activity.Activity.ApplicationContext, activity.Activity.Application));
        }
    }
}
