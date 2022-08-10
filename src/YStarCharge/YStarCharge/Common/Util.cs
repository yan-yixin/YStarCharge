using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace YStarCharge.Common
{
    internal static class Util
    {
        public static void NoticeMessageBox(string content)
        {
            MessageBox.Show(content, "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
