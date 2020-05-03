using DSSW.Client.Utils;
using DSSW.Client.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Resources;

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
            containerRegistry.RegisterForNavigation<NewScreenShot>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            StreamResourceInfo streamInfo = GetResourceStream(new Uri("Assets/Cursors/basic.cur", UriKind.Relative));
            Mouse.OverrideCursor = new Cursor(streamInfo.Stream);
            FileHelper.OpenThisAppAtBoot();
        }
    }
}
