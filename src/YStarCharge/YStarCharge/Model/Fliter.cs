namespace YStarCharge.Model
{
    public class Fliter: NotifyPropertyChanged
    {

        private float minMoney;

        public float MinMoney
        {
            get
            {
                return minMoney;
            }
            set
            {
                if (minMoney == value)
                {
                    return;
                }
                minMoney = value;
                OnPropertyChanged(this,"MinMoney");
            }
        }

        private float maxMoney;

        public float MaxMoney
        {
            get
            {
                return maxMoney;
            }
            set
            {
                if (maxMoney == value)
                {
                    return;
                }
                maxMoney = value;
                OnPropertyChanged(this,"MaxMoney");
            }
        }

        private string startDate;
        public string StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                if (startDate == value)
                {
                    return;
                }
                startDate = value;
                OnPropertyChanged(this, "StartDate");
            }
        }

        private string endDate;

        public string EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                if (endDate == value)
                {
                    return;
                }
                endDate = value;
                OnPropertyChanged(this,"EndDate");
            }
        }

        private ExpendTo to;

        public ExpendTo To
        {
            get
            {
                return to;
            }
            set
            {
                if (to == value)
                {
                    return;
                }
                to = value;
                OnPropertyChanged(this, "To");
            }
        }
    }
}
