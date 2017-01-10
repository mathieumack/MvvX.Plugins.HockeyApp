using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MvvX.Plugins.HockeyApp;
using MvvX.Plugins.HockeyApp.Droid;
using System.IO.IsolatedStorage;
using System.Collections.Generic;

namespace Client.Android
{
    [Activity(Label = "Client.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        public static IHockeyClient hockeyClient;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += Button_Click;

            Button crashButton = FindViewById<Button>(Resource.Id.MyButton2);
            crashButton.Click += CrashButton_Click;
        }

        protected override void OnStart()
        {
            base.OnStart();
            hockeyClient = new HockeyClientDroid(this, this.Application);
            hockeyClient.Configure("$APPId", "1.0", true, true, true);

            hockeyClient.TrackEvent("Start application from HockeyApp");

            hockeyClient.TrackEvent(
            "Custom Properties",
            new Dictionary<string, string> { { "UserName", "Test Username" } },
            new Dictionary<string, double> { { "Version", 3.0 } }
            );
        }

        private void Button_Click(object sender, EventArgs e)
        {
            count++;
            hockeyClient.TrackEvent("Droid Button_Click");
        }


        private void CrashButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("Custom not implemented exception.");
        }
    }
}

