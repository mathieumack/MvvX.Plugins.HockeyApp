using MvvX.Plugins.HockeyApp;
using MvvX.Plugins.HockeyApp.Wpf;
using System.IO.IsolatedStorage;
using System.Windows;

namespace Client.Windows
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHockeyClient hockeyClient;

        public App()
        {
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            App.hockeyClient = new HockeyClientWpf();
            App.hockeyClient.Configure("d4f10c8b3fdd46a19382a5f4c103f229", true, true);

            App.hockeyClient.TrackEvent("Start application");

            //send crashes to the HockeyApp server 
            await App.hockeyClient.SendCrashesAsync();

            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            var value = isoStore.AvailableFreeSpace;
        }
    }
}
