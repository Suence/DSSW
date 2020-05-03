using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSSW.Client.StaticObjects
{
    public static class GlobalObjectHolder
    {
        public static string ScreenShotFolder { get; set; }

        static GlobalObjectHolder()
        {

            ScreenShotFolder = Path.Combine($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}", @"地下城与勇士\ScreenShot");
        }
    }
}
