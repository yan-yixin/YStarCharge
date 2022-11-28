using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using YStarCharge.Common;
using YStarCharge.Controller;
using YStarCharge.Model;
using YStarCharge.Windows;

namespace YStarCharge.ViewModel
{
    public sealed class LoginWindowVM: NotifyPropertyChanged
    {
        private UserAccountController controller = new UserAccountController();
        public UserAccount User { get; set; } = new UserAccount()
        {
            Username = AppConfigHelper.Username
        };

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
                OnPropertyChanged(this, "IsWindowClose");
            }
        }

        public ICommand Login => new RelayCommand(param => {
            if (string.IsNullOrWhiteSpace(User.Username))
            {
                Util.NoticeMessageBox("用户名不能为空");
                return;
            }

            if (string.IsNullOrWhiteSpace(User.Password))
            {
                Util.NoticeMessageBox("密码不能为空");
                return;
            }

            var userTemp = controller.GetAccount(User.Username);
            if(userTemp == null || userTemp.Password != User.Password)
            {
                Util.NoticeMessageBox("用户名或密码不正确");
                return;
            }
            //显示主界面
            MainWindow window = new MainWindow();
            window.Show();

            //这个界面关闭
            IsWindowClose = false;
        });

        public ICommand Register => new RelayCommand(param =>
        {
            RegisterWindow window = new RegisterWindow();
            window.Show();
        });

        public ICommand ForgetPassword => new RelayCommand(param =>
        {
            //TODO
            ChangePassowrdWindow cpw = new ChangePassowrdWindow();
            if(cpw.ShowDialog() == true)
            {
                var newPasword = cpw.ViewModel.Model.SurePassword;
                int ret = controller.Update(User);
            }
        });
    }
}
