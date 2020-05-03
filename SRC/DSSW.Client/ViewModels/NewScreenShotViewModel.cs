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
        private bool _canAutoExit;
        private bool _isFocused;

        #endregion

        public bool CanAutoExit
        {
            get => _canAutoExit;
            set => SetProperty(ref _canAutoExit, value);
        }

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
        {
            _regionManager.RequestNavigate(
                           RegionNames.MainRegion,
                           ViewNames.Monitor);
            _isFocused = true;
        }

        public NewScreenShotViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            CopyToClipboardCommand = new DelegateCommand(CopyToClipboard);
            BackToMonitorCommand = new DelegateCommand(BackToMonitor);
            StartTimeCommand = new DelegateCommand(Start);
            ResetTimeCommand = new DelegateCommand(ResetTime);
            Start();
        }

        public async void AutoBackToMonitor()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            BackToMonitor();
        }
        public DelegateCommand StartTimeCommand { get; }
        private async void Start()
        {
            _isFocused = false;
            for (int i = 0; i < 100; ++i)
            {
                await Task.Delay(TimeSpan.FromSeconds(0.1));
                System.Diagnostics.Debug.WriteLine("Running");
                if (_isFocused)
                {
                    return;
                }
            }
            CanAutoExit = true;
        }
        public DelegateCommand ResetTimeCommand { get; }
        private void ResetTime()
        {
            _isFocused = true;
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
