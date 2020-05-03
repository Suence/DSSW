using System;
using System.IO;

namespace DSSW.Client.Utils
{
    public static class GlobalObjectHolder
    {
        public static string ScreenShotFolder { get; set; }

        static GlobalObjectHolder()
        {
            ScreenShotFolder = Path.Combine($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}", 
                                            @"地下城与勇士\ScreenShot");
        }
    }
}
