using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSSW.Client.ViewModels
{
    public class SettingsWindowViewModel : BindableBase
    {
        #region private
        private string _title = "Text";
        #endregion
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public SettingsWindowViewModel()
        {

        }
    }
}
