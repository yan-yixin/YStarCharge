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
            FrameworkCompatibilityPreferences.KeepTextBoxDisplaySynchronizedWithTextProperty = false;

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        
    }
}
