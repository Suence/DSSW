using DSSW.Client.Constants;
using DSSW.Client.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.IO;

namespace DSSW.Client.ViewModels
{
    public class MonitorViewModel : BindableBase, IRegionMemberLifetime
    {
        #region private
        private FileSystemWatcher _fileSystemWatcher;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        #endregion

        public MonitorViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<NewScreenShotEvent>()
                            .Subscribe(NavigateToNewScreenShotView, ThreadOption.UIThread);
            MonitorTargetFolder(@"C:\Users\Suence\Documents\地下城与勇士\ScreenShot");
        }

        private void NavigateToNewScreenShotView(string fileFullPath)
            => _regionManager.RequestNavigate(
                   RegionNames.MainRegion,
                   ViewNames.NewScreenShot,
                   new NavigationParameters
                   {
                       { "NewScreenShotFullPath", fileFullPath}
                   });

        private void MonitorTargetFolder(string targetFolderFullPath)
        {
            _fileSystemWatcher = new FileSystemWatcher(targetFolderFullPath)
            {
                IncludeSubdirectories = true
            };
            _fileSystemWatcher.Created += (_, e) => _eventAggregator.GetEvent<NewScreenShotEvent>().Publish(e.FullPath);
            _fileSystemWatcher.EnableRaisingEvents = true;
        }
        public bool KeepAlive => false;
    }
}
