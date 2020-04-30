using Prism.Commands;
using Prism.Mvvm;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DSSW.Client.ViewModels
{
    public class MonitorViewModel : BindableBase
    {
        #region private
        private string _newScreenShotPath;
        private FileSystemWatcher _fileSystemWatcher;
        #endregion

        public string NewScreenShotPath
        {
            get => _newScreenShotPath;
            set => SetProperty(ref _newScreenShotPath, value);
        }

        public DelegateCommand CopyToClipboardCommand { get; }
        private void CopyToClipboard()
            => Clipboard.SetImage(new BitmapImage(new Uri(NewScreenShotPath)));

        public MonitorViewModel()
        {
            CopyToClipboardCommand = new DelegateCommand(CopyToClipboard);
            MonitorTargetFolder(@"D:\TEST");
        }

        private void MonitorTargetFolder(string targetFolderFullPath)
        {
            _fileSystemWatcher = new FileSystemWatcher(targetFolderFullPath)
            {
                IncludeSubdirectories = true
            };
            _fileSystemWatcher.Created += NewScreenShotCreated;
            _fileSystemWatcher.EnableRaisingEvents = true;
        }
        private void NewScreenShotCreated(object sender, FileSystemEventArgs e)
        {
            NewScreenShotPath = e.FullPath;
        }
    }
}
