using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using YStarCharge.Windows;

namespace YStarCharge
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
