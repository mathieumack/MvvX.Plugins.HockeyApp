using Microsoft.HockeyApp;
using System;
using System.Windows;

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
            var exception =new NotImplementedException("Custom not implemented exception.");
            App.hockeyClient.TrackException(exception);
        }
    }
}
