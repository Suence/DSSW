using DSSW.Client.Constants;
using DSSW.Client.Views;
using Prism.Mvvm;
using Prism.Regions;

namespace DSSW.Client.ViewModels
{
    /// <summary>
    /// Shell 的程序逻辑(ViewModel)
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        private string _title = "DSSW";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            // 将监视器视图注入到 MainRegion 区域中
            regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(Monitor));
        }
    }
}
