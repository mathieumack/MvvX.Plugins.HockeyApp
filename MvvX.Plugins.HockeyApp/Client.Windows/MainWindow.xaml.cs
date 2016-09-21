using System;
using System.Windows;

namespace Client.Windows
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.hockeyClient.TrackEvent("Wpf Button_Click");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException("Custom not implemented exception.");
        }
    }
}
