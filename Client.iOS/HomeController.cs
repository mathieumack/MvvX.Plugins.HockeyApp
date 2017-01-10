using System;
using MvvX.Plugins.HockeyApp;
using MvvX.Plugins.HockeyApp.Touch;
using UIKit;

namespace Client.iOS
{
    public partial class HomeController : UIViewController
    {
        public static IHockeyClient hockeyClient;
        public HomeController() : base("HomeController", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            hockeyClient = new HockeyClientTouch();
            hockeyClient.Configure("$AppID", "1.0", true, true, true);

            hockeyClient.TrackEvent("Start iOS application from HockeyApp");
            // Perform any additional setup after loading the view, typically from a nib.
        }
    }
}