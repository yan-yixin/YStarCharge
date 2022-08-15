using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using YStarCharge.Model;

namespace YStarCharge.ViewModel
{
    public sealed class UserInfoVM:NotifyPropertyChanged
    {
        public UserInfo UserInformation { get; set; }

        private bool isReadOnly = true;
        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
            set
            {
                if(isReadOnly == value)
                {
                    return;
                }
                isReadOnly = value;
                OnPropertyChanged(this,"IsReadOnly");
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
                if(thickness == value)
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

        public ICommand Sure => new RelayCommand(obj=> {
            IsReadOnly = true;
            Thickness = new Thickness();
        });
    }
}
