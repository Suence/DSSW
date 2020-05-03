using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DSSW.Client.Utils
{
    public static class WindowPositionHelper
    {
        private static readonly string _regPath
            = @"Software/DSSW/WindowBounds/";

        public static void SaveSize(Window window)
            => Registry.CurrentUser
                       .CreateSubKey(_regPath + window.Name)
                       .SetValue("Bounds", window.RestoreBounds);

        public static void SetSize(Window window)
        {
            if (window.SizeToContent != SizeToContent.Manual) return;

            RegistryKey key = Registry.CurrentUser
                                      .OpenSubKey(_regPath + window.Name);

            if (key is null) return;

            var windowBounds = Rect.Parse($"{key.GetValue("Bounds")}");
            window.Top = windowBounds.Top;
            window.Left = windowBounds.Left;
            window.Width = windowBounds.Width;
            window.Height = windowBounds.Height;
        }
    }
}
