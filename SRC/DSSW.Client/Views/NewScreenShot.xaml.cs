using System.Windows.Controls;

namespace DSSW.Client.Views
{
    /// <summary>
    /// Interaction logic for NewScreenShot
    /// </summary>
    public partial class NewScreenShot : UserControl
    {
        public NewScreenShot()
        {
            InitializeComponent();
        }

        private void OpenSettingsWindow(object sender, System.Windows.RoutedEventArgs e)
        {
            new SettingsWindow().ShowDialog();
        }
    }
}
