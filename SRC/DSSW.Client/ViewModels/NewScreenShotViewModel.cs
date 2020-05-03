using DSSW.Client.Constants;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DSSW.Client.ViewModels
{
    public class NewScreenShotViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        #region private
        private string _newScreenShotPath;
        private readonly IRegionManager _regionManager;
        private bool _isCopied;
        #endregion

        public bool IsCopied
        {
            get => _isCopied;
            set => SetProperty(ref _isCopied, value);
        }

        public string NewScreenShotPath
        {
            get => _newScreenShotPath;
            set => SetProperty(ref _newScreenShotPath, value);
        }

        public DelegateCommand CopyToClipboardCommand { get; }
        private void CopyToClipboard()
        {
            IsCopied = true;
            Clipboard.SetImage(new BitmapImage(new Uri(NewScreenShotPath)));
        }

        public DelegateCommand BackToMonitorCommand { get; }


        private void BackToMonitor()
            => _regionManager.RequestNavigate(
                RegionNames.MainRegion,
                ViewNames.Monitor);

        public NewScreenShotViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            CopyToClipboardCommand = new DelegateCommand(CopyToClipboard);
            BackToMonitorCommand = new DelegateCommand(BackToMonitor);
            //AutoBackToMonitor();
        }

        public async void AutoBackToMonitor()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            BackToMonitor();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
            => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            NewScreenShotPath = navigationContext.Parameters["NewScreenShotFullPath"].ToString();
        }
        public bool KeepAlive => false;
    }
}
