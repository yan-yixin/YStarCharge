using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using YStarCharge.Model;

namespace YStarCharge.ViewModel
{
    public class ChangePasswordVM:NotifyPropertyChanged
    {
        public UserAccount User { get; set; }

        private string newPassword;

        public string NewPassword
        {
            get
            {
                return newPassword;
            }
            set
            {
                if(newPassword == value)
                {
                    return;
                }
                newPassword = value;
                OnPropertyChanged(this, "NewPassword");
            }
        }

        private bool isClose;
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

        });

        public ICommand Cancel => new RelayCommand(obj =>
        {
            IsClose = false;
        });
    }
}
