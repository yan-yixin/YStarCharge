using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using YStarCharge.Common;
using YStarCharge.Controller;
using YStarCharge.Model;

namespace YStarCharge.ViewModel
{
    public sealed class UserInfoVM : NotifyPropertyChanged
    {
        private UserInfoController controller = new UserInfoController();

        public UserInfo UserInformation { get; set; } = new UserInfo();

        private bool isReadOnly = true;
        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
            set
            {
                if (isReadOnly == value)
                {
                    return;
                }
                isReadOnly = value;
                OnPropertyChanged(this, "IsReadOnly");
            }
        }

        private Thickness thickness;
        public Thickness Thickness
        {
            get
            {
                return thickness;
            }
            set
            {
                if (thickness == value)
                {
                    return;
                }
                thickness = value;
                OnPropertyChanged(this, "Thickness");
            }
        }

        public ICommand Edit => new RelayCommand(obj => {
            IsReadOnly = false;
            Thickness = new Thickness(1);
        });

        public ICommand Sure => new RelayCommand(obj => {
            if(UserInformation.Gender.Trim() != "男" && UserInformation.Gender.Trim() != "女")
            {
                Util.NoticeMessageBox("性别格式不正确，请输入“男”或者“女”。");
                return;
            }

            if(UserInformation.Age <=0 || UserInformation.Age >= 120)
            {
                Util.NoticeMessageBox("超出年龄范围，请输入1到120之前的整数。");
                return;
            }
            IsReadOnly = true;
            Thickness = new Thickness();
            if (!controller.IsExist(UserInformation))
            {
                controller.Insert(UserInformation);
            }
            else
            {
                controller.Update(UserInformation);
            }
        });

        public UserInfoVM()
        {
            UserInformation = controller.Get<UserInfo>(AppContext.Instacne.Username);
            if (UserInformation == null)
            {
                UserInformation = new UserInfo();
            }
        }
    }
}
