using DSSW.Client.Views;
using Prism.Mvvm;
using Prism.Regions;

namespace DSSW.Client.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(Monitor));
        }
    }
}
