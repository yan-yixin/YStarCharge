using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using YStarCharge.Common;
using YStarCharge.Model;

namespace YStarCharge.ViewModel
{
    public class ChangePasswordVM:NotifyPropertyChanged
    {
        public ChangePassowrdModel Model { get; set; } = new ChangePassowrdModel();

        private bool isClose = true;
        public bool IsClose
        {
            get
            {
                return isClose;
            }
            set
            {
                if(isClose == value)
                {
                    return;
                }
                isClose = value;
                OnPropertyChanged(this, "IsClose");
            }
        }

        public ICommand OK => new RelayCommand(obj =>
        {
            if(Model.OriginPassword != AppConfigHelper.Password)
            {
                Util.NoticeMessageBox("原始密码输入不正确");
                return;
            }

            if(Model.NewPassword != Model.SurePassword)
            {
                Util.NoticeMessageBox("两次密码输入不一致");
                return;
            }
            AppConfigHelper.Password = Model.SurePassword;
            IsClose = false;
        });

        public ICommand Cancel => new RelayCommand(obj =>
        {
            IsClose = false;
        });
    }
}
