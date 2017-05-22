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
            App.hockeyClient.Configure("4fb69a0e-d187-4d09-ae6c-4a9a7594d572", "1.0.0.0", true, true, true);
            
            App.hockeyClient.TrackEvent("Start application from HockeyApp");

            //send crashes to the HockeyApp server 
            await App.hockeyClient.SendCrashesAsync();

            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            var value = isoStore.AvailableFreeSpace;
        }
    }
}
