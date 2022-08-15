using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YStarCharge.Model
{
    public class UserInfo:NotifyPropertyChanged
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
                OnPropertyChanged(this,"Username");
            }
        }

        public string gender;
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (gender == value)
                {
                    return;
                }
                gender = value;
                OnPropertyChanged(this, "Gender");
            }
            
        }

        public int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age == value)
                {
                    return;
                }
                age = value;
                OnPropertyChanged(this, "Age");
            }

        }

        public string industry;
        public string Industry
        {
            get
            {
                return industry;
            }
            set
            {
                if (industry == value)
                {
                    return;
                }
                industry = value;
                OnPropertyChanged(this, "Industry");
            }

        }

        public string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (address == value)
                {
                    return;
                }
                address = value;
                OnPropertyChanged(this, "Address");
            }

        }
    }
}
