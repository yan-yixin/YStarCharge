namespace YStarCharge.Model
{
    public class BaseIncomeExpend : NotifyPropertyChanged
    {
        private bool isSelected;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (IsSelected == value)
                {
                    return;
                }
                isSelected = value;
                OnPropertyChanged(this, "IsSeleted");
            }
        }

        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (number == value)
                {
                    return;
                }
                number = value;
                OnPropertyChanged(this, "Number");
            }
        }

        private string createAt;
        public string CreateAt
        {
            get
            {
                return createAt;
            }
            set
            {
                if (createAt == value)
                {
                    return;
                }
                createAt = value;
                OnPropertyChanged(this, "CreateAt");
            }
        }

        private float money;
        public float Money
        {
            get
            {
                return money;
            }
            set
            {
                if (money == value)
                {
                    return;
                }
                money = value;
                OnPropertyChanged(this, "Money");
            }
        }

        private string remark;
        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                if (remark == value) { return; }
                remark = value;
                OnPropertyChanged(this, "Remark");
            }
        }
    }
}
