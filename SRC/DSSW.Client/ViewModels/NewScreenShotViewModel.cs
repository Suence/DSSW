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
    /// <summary>
    /// 截图分享视图的程序逻辑(ViewModel)
    /// </summary>
    public class NewScreenShotViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        #region private
        /// <summary>
        /// 新截图的路径
        /// </summary>
        private string _newScreenShotPath;
        
        /// <summary>
        /// 导航对象
        /// </summary>
        private readonly IRegionManager _regionManager;
        
        /// <summary>
        /// 图片是否已被复制
        /// </summary>
        private bool _isCopied;
        
        /// <summary>
        /// 是否可以自动关闭视图
        /// </summary>
        private bool _canAutoExit;
        
        /// <summary>
        /// 用户的注意力是否还在此视图
        /// </summary>
        private bool _isFocused;

        #endregion

        /// <summary>
        /// 是否可以自动关闭视图
        /// </summary>
        public bool CanAutoExit
        {
            get => _canAutoExit;
            set => SetProperty(ref _canAutoExit, value);
        }

        /// <summary>
        /// 图片是否已被复制
        /// </summary>
        public bool IsCopied
        {
            get => _isCopied;
            set => SetProperty(ref _isCopied, value);
        }
        
        /// <summary>
        /// 新截图的路径
        /// </summary>
        public string NewScreenShotPath
        {
            get => _newScreenShotPath;
            set => SetProperty(ref _newScreenShotPath, value);
        }
        
        /// <summary>
        /// 复制图片到剪贴板
        /// </summary>
        public DelegateCommand CopyToClipboardCommand { get; }
        private void CopyToClipboard()
        {
            IsCopied = true;
            Clipboard.SetImage(new BitmapImage(new Uri(NewScreenShotPath)));
        }

        /// <summary>
        /// 返回到监视器视图
        /// </summary>
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

            // 开始无操作计时
            Start();
        }

        /// <summary>
        /// 开始无操作计时
        /// </summary>
        public DelegateCommand StartTimeCommand { get; }
        private async void Start()
        {
            _isFocused = false;
            for (int i = 0; i < 70; ++i)
            {
                await Task.Delay(TimeSpan.FromSeconds(0.1));

                // 如果用户的注意力重新回到此视图, 则取消任务
                if (_isFocused)
                {
                    return;
                }
            }
            CanAutoExit = true;
        }

        /// <summary>
        /// 用户的注意力重新回到此视图
        /// </summary>
        public DelegateCommand ResetTimeCommand { get; }
        private void ResetTime() => _isFocused = true;

        public bool IsNavigationTarget(NavigationContext navigationContext)
            => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        /// <summary>
        /// 获取新图片(史诗截图)的路径 (由监视器传递的参数)
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            NewScreenShotPath = navigationContext.Parameters["NewScreenShotFullPath"].ToString();
        }

        /// <summary>
        /// 导航离开时, 销毁此视图
        /// </summary>
        public bool KeepAlive => false;
    }
}
