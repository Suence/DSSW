using System.Windows;

namespace DSSW.Client.Views
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void DragMoveWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
            => DragMove();

        private void CloseSettingsWindow(object sender, RoutedEventArgs e)
            => Close();
    }
}
