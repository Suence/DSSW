using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DSSW.Client.Utils
{
    /// <summary>
    /// 用于记住窗口位置(通过注册表的方式)
    /// </summary>
    public static class WindowPositionHelper
    {
        /// <summary>
        /// 目标位置(注册表)
        /// </summary>
        private static readonly string _regPath
            = @"Software/DSSW/WindowBounds/";

        /// <summary>
        /// 保存窗口位置
        /// </summary>
        /// <param name="window"></param>
        public static void SaveSize(Window window)
            => Registry.CurrentUser
                       .CreateSubKey(_regPath + window.Name)
                       .SetValue("Bounds", window.RestoreBounds);

        /// <summary>
        /// 设置窗口位置
        /// </summary>
        /// <param name="window"></param>
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
