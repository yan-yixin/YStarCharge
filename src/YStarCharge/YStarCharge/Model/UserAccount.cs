using SqlLib;

namespace YStarCharge.Model
{
    public class UserAccount : NotifyPropertyChanged,IEntity
    {
        public virtual int Id { get; set; }

        private string username;
        public virtual string Username
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

        private string password;
        public virtual string Password
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

        private string headIcon;

        public virtual string HeadIcon
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
