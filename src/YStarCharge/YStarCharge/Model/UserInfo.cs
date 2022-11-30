using SqlLib;

namespace YStarCharge.Model
{
    public class UserInfo : NotifyPropertyChanged,IEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }


        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(name == value)
                {
                    return;
                }
                name = value;
                OnPropertyChanged(this,"Name");
            }
        }

        private string gender;
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

        private int age;
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

        private string industry;
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

        private string address;
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
