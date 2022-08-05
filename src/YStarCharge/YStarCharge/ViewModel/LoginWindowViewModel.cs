using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using YStarCharge.Common;
using YStarCharge.Model;
using YStarCharge.Windows;

namespace YStarCharge.ViewModel
{
    public sealed class LoginWindowViewModel: INotifyPropertyChanged
    {
        private string username;
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
                    if (string.IsNullOrWhiteSpace(password))
                    {
                        Util.NoticeMessageBox("密码不能为空");
                        return;
                    }
                    if(username == "yixin" && password == "123")
                    {
                        //显示主界面
                        MainWindow window = new MainWindow();
                        window.Show();
                        return;
                    }
                    Util.NoticeMessageBox("用户名或密码不正确");
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
