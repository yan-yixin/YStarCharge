using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using YStarCharge.Common;
using YStarCharge.Windows;

namespace YStarCharge.ViewModel
{
    public sealed class LoginWindowViewModel: INotifyPropertyChanged
    {
        private string username = "admin";
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                if (username == value)
                {
                    return;
                }
                username = value;
                OnPropertyChanged("UserName");
            }
        }

        private string password; 

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                if (password == value)
                {
                    return;
                }
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private bool isWindowClose = true;
        public bool IsWindowClose
        {
            get
            {
                return isWindowClose;
            }
            set
            {
                if(isWindowClose == value)
                {
                    return;
                }
                isWindowClose = value;
                OnPropertyChanged("IsWindowClose");
            }
        }

        public ICommand Login
        {
            get
            {
                return new RelayCommand(param => {
                    if (string.IsNullOrWhiteSpace(username))
                    {
                        Util.NoticeMessageBox("用户名不能为空");
                        return;
                    }

                    //显示主界面
                    MainWindow window = new MainWindow();
                    window.Show();

                    //这个界面关闭
                    IsWindowClose = false;

                    //if (string.IsNullOrWhiteSpace(password))
                    //{
                    //    Util.NoticeMessageBox("密码不能为空");
                    //    return;
                    //}

                    //if (username == AppConfigHelper.Username && password == AppConfigHelper.Password)
                    //{
                    //    //显示主界面
                    //    MainWindow window = new MainWindow();
                    //    window.Show();

                    //    //这个界面关闭
                    //    IsWindowClose = false;
                    //    return;
                    //}
                    //Util.NoticeMessageBox("用户名或密码不正确");
                    //TODO
                });
            }
        }

        public ICommand Register
        {
            get
            {
                return new RelayCommand(param => {
                    RegisterWindow window = new RegisterWindow();
                    window.Show();
                });
            }
        }

        public ICommand ForgetPassword
        {
            get
            {
                return new RelayCommand(param=> {
                    MessageBox.Show("显示密码找回");
                    //TODO
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
