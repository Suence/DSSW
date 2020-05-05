using Prism.Commands;
using Prism.Mvvm;
using System.Diagnostics;

namespace DSSW.Client.ViewModels
{
    /// <summary>
    /// 设置功能的程序逻辑
    /// </summary>
    public class SettingsWindowViewModel : BindableBase
    {
        /// <summary>
        /// 窗口标题
        /// </summary>
        public string Title { get; set; } = "程序设置";
        
        /// <summary>
        /// C 站帖子链接
        /// </summary>
        public string ColgAddress { get; set; } = "https://bbs.colg.cn/thread-7855396-1-1.html";
        
        /// <summary>
        /// 贴吧帖子链接
        /// </summary>
        public string TiebaAddress { get; set; } = "https://tieba.baidu.com";

        /// <summary>
        /// 使用默认浏览器打开链接
        /// </summary>
        public DelegateCommand<string> GoToBroswerCommand { get; set; }
        private void GotoBroswer(string address)
            => Process.Start(address);

        public SettingsWindowViewModel()
            => GoToBroswerCommand = new DelegateCommand<string>(GotoBroswer);
    }
}
