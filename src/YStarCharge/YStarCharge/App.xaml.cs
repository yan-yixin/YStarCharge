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
            //第一次启动初始化数据库
            if (!Common.AppConfigHelper.IsInitlize)
            {
                //初始话数据库，如果没有表，自动创建表
            }

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        
    }
}
