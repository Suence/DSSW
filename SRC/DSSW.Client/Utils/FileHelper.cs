using System;
using System.IO;
using System.Reflection;

namespace DSSW.Client.Utils
{
    /// <summary>
    /// 文件系统帮助类
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// DNF 截图文件夹路径
        /// </summary>
        public static string DnfScreenShotFolder { get; }
        
        /// <summary>
        /// 自启动程序文件夹
        /// </summary>
        public static string SystemStartupFolder { get; }

        static FileHelper()
        {
            DnfScreenShotFolder = Path.Combine($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}", 
                                            @"地下城与勇士\ScreenShot");
            SystemStartupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        }

        /// <summary>
        /// 将程序添加到开机自启
        /// </summary>
        public static void OpenThisAppAtBoot()
        {
            string linkFileFullPath = Path.Combine(SystemStartupFolder, "DSSW.lnk");
            
            // 如果快捷方式已经存在, 则不进行任何操作
            if (File.Exists(linkFileFullPath)) return;

            CreateShortcut(linkFileFullPath, String.Empty);

            // 创建快捷方式
            void CreateShortcut(string lnkFilePath, string args = "")
            {
                var shellType = Type.GetTypeFromProgID("WScript.Shell");
                dynamic shell = Activator.CreateInstance(shellType);
                var shortcut = shell.CreateShortcut(lnkFilePath);
                shortcut.TargetPath = Assembly.GetEntryAssembly().Location;
                shortcut.Arguments = args;
                shortcut.WorkingDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                shortcut.Save();
            }
        }
    }
}
