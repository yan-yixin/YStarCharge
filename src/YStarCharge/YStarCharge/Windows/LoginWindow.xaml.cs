using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using YStarCharge.ViewModel;

namespace YStarCharge.Windows
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginWindowViewModel ViewModel;
        public LoginWindow()
        {
            InitializeComponent();

            ViewModel = new LoginWindowViewModel();
            DataContext = ViewModel;
        }

        private void Window_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(!(bool)e.NewValue)
            {
                Close();
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(ViewModel == null)
            {
                return;
            }
            ViewModel.Password = pwdPasswordBox.Password;
        }
    }
}
