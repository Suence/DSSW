using DSSW.Client.Constants;
using DSSW.Client.Events;
using DSSW.Client.Utils;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.IO;

namespace DSSW.Client.ViewModels
{
    /// <summary>
    /// 监视器(悬浮球)的程序逻辑(ViewModel)
    /// </summary>
    public class MonitorViewModel : BindableBase, IRegionMemberLifetime
    {
        #region private
        /// <summary>
        /// 目录监视器
        /// </summary>
        private FileSystemWatcher _fileSystemWatcher;
        
        /// <summary>
        /// 视图导航对象
        /// </summary>
        private readonly IRegionManager _regionManager;
        
        /// <summary>
        /// 事件聚合器
        /// </summary>
        private readonly IEventAggregator _eventAggregator;
        #endregion

        public MonitorViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            
            // 订阅事件
            _eventAggregator.GetEvent<NewScreenShotEvent>()
                            .Subscribe(NavigateToNewScreenShotView, ThreadOption.UIThread);
            
            // 开始监视目标文件夹(非轮询)
            MonitorTargetFolder(FileHelper.DnfScreenShotFolder);
        }

        /// <summary>
        /// 导航到截图分享视图
        /// </summary>
        /// <param name="fileFullPath"></param>
        private void NavigateToNewScreenShotView(string fileFullPath)
            => _regionManager.RequestNavigate(
                   RegionNames.MainRegion,
                   ViewNames.NewScreenShot,
                   new NavigationParameters
                   {
                       { "NewScreenShotFullPath", fileFullPath}
                   });

        /// <summary>
        /// 监视目标文件夹
        /// </summary>
        /// <param name="targetFolderFullPath"></param>
        private void MonitorTargetFolder(string targetFolderFullPath)
        {
            _fileSystemWatcher = new FileSystemWatcher(targetFolderFullPath, "*.JPG")
            {
                IncludeSubdirectories = true
            };
            // 订阅新文件被创建事件
            _fileSystemWatcher.Created += (_, e) => _eventAggregator.GetEvent<NewScreenShotEvent>().Publish(e.FullPath);
            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// 导航离开时, 销毁此对象
        /// </summary>
        public bool KeepAlive => false;
    }
}
