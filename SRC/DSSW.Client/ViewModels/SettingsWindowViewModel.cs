using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DSSW.Client.ViewModels
{
    public class SettingsWindowViewModel : BindableBase
    {
        public string Title { get; set; } = "程序设置";
        public string ColgAddress { get; set; } = "https://bbs.colg.cn/thread-7855396-1-1.html";
        public string TiebaAddress { get; set; } = "https://tieba.baidu.com";

        public DelegateCommand<string> GoToBroswerCommand { get; set; }
        private void GotoBroswer(string address)
            => Process.Start(address);

        public SettingsWindowViewModel()
            => GoToBroswerCommand = new DelegateCommand<string>(GotoBroswer);
    }
}
