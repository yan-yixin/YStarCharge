using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YStarCharge.Model
{
    public class UserAccount:NotifyPropertyChanged
    {
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if(username == value)
                {
                    return;
                }
                username = value;
                OnPropertyChanged(this, "Username");
            }
        }

        public string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if(password == value)
                {
                    return;
                }
                password = value;
                OnPropertyChanged(this, "Password");
            }
        }

        public string headIcon;

        public string HeadIcon
        {
            get
            {
                return headIcon;
            }
            set
            {
                if(headIcon == value)
                {
                    return;
                }
                headIcon = value;
                OnPropertyChanged(this, "HeadIcon");
            }
        }
    }
}
