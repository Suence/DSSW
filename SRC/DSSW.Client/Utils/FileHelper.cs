using System;
using System.IO;
using System.Reflection;

namespace DSSW.Client.Utils
{
    public static class FileHelper
    {
        public static string DnfScreenShotFolder { get; }
        public static string SystemStartupFolder { get; }

        static FileHelper()
        {
            DnfScreenShotFolder = Path.Combine($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}", 
                                            @"地下城与勇士\ScreenShot");
            SystemStartupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        }

        public static void OpenThisAppAtBoot()
        {
            string linkFileFullPath = Path.Combine(SystemStartupFolder, "DSSW.lnk");
            
            if (File.Exists(linkFileFullPath)) return;

            CreateShortcut(linkFileFullPath, String.Empty);

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
