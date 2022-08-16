namespace YStarCharge.Model
{
    public sealed class ChangePassowrdModel:NotifyPropertyChanged
    {
        private string originPassword;

        public string OriginPassword
        {
            get
            {
                return originPassword;
            }
            set
            {
                if(originPassword == value)
                {
                    return;
                }
                originPassword = value;
                OnPropertyChanged(this, "OriginPassword");
            }
        }

        private string newPassword;

        public string NewPassword
        {
            get
            {
                return newPassword;
            }
            set
            {
                if (newPassword == value)
                {
                    return;
                }
                newPassword = value;
                OnPropertyChanged(this, "NewPassword");
            }
        }

        private string surePassword;

        public string SurePassword
        {
            get
            {
                return surePassword;
            }
            set
            {
                if (surePassword == value)
                {
                    return;
                }
                surePassword = value;
                OnPropertyChanged(this, "SurePassword");
            }
        }
    }
}
