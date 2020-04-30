using DSSW.Client.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace DSSW.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
            => Container.Resolve<MainWindow>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Monitor>();
        }
    }
}
