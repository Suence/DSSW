using DSSW.Client.Properties;
using System.Windows;
using System.Windows.Controls;

namespace DSSW.Client.Views
{
    /// <summary>
    /// Interaction logic for Monitor
    /// </summary>
    public partial class Monitor : UserControl
    {
        public Monitor() => InitializeComponent();

        private void OpenSettingsWindow(object sender, RoutedEventArgs e)
            => new SettingsWindow().ShowDialog();

        private void ExitApplication(object sender, RoutedEventArgs e)
            => Application.Current.Shutdown();
    }
}
