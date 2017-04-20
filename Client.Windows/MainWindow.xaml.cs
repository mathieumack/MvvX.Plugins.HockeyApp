using Microsoft.HockeyApp;
using System;
using System.Windows;
using MvvX.Plugins.HockeyApp;
using System.Collections.Generic;
using System.IO;
using MvvX.Plugins.HockeyApp.Wpf;

namespace Client.Windows
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            i++;
            App.hockeyClient.TrackEvent("Wpf Button_Click");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException("Custom not implemented exception.");
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            var exception = new NotImplementedException("Custom not implemented exception.");
            App.hockeyClient.TrackException(exception);
        }

        private async void Button4_Click(object sender, RoutedEventArgs e)
        {
            var bytes = File.ReadAllBytes(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg");
            var list = new List<IHockeyAppAttachment>();
            list.Add(new HockeyAppAttachment() { DataBytes = bytes, FileName = "Koala.jpg", ContentType = "image/jpeg" });
            var result = await App.hockeyClient.SendFeedbackAsync("Description", "mail@domain.com", "Sujet", "Nom", list);
        }
    }
}
