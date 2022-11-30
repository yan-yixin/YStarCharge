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
using YStarCharge.Common;
using YStarCharge.ViewModel;

namespace YStarCharge.Windows
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginWindowVM ViewModel;
        public LoginWindow()
        {
            InitializeComponent();

            ViewModel = new LoginWindowVM();
            DataContext = ViewModel;
        }

        private void Window_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(!(bool)e.NewValue)
            {
                Close();
                if (remeberButton.IsChecked == true)
                {
                    Util.SaveUserToLocal(ViewModel.User);
                }
                AppConfigHelper.IsRemeberAccount = (bool)remeberButton.IsChecked;
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            remeberButton.IsChecked = AppConfigHelper.IsRemeberAccount;
            if (AppConfigHelper.IsRemeberAccount)
            {
                ViewModel.User = Util.GetUserFromLocal();
                usernameTextBox.Text = ViewModel.User.Username;
                pwdPasswordBox.Password = ViewModel.User.Password;
            }

        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(ViewModel == null)
            {
                return;
            }
            ViewModel.User.Password = pwdPasswordBox.Password;
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ViewModel == null)
            {
                return;
            }
            ViewModel.User.Username = usernameTextBox.Text;
        }
    }
}
