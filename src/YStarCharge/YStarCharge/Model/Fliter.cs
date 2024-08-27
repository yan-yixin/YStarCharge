using System;
using System.ComponentModel;

namespace YStarCharge.Model
{

    public class BaseFliter : NotifyPropertyChanged
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
                OnPropertyChanged(this, "MinMoney");
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
                OnPropertyChanged(this, "MaxMoney");
            }
        }

        private DateTime startDate;
        public DateTime StartDate
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

        private DateTime endDate;

        public DateTime EndDate
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
                OnPropertyChanged(this, "EndDate");
            }
        }

    }

    public class ExpendFliter: BaseFliter, INotifyPropertyChanged
    {
        private ExpendTo direction;

        public ExpendTo Direction
        {
            get
            {
                return direction;
            }
            set
            {
                if (direction == value)
                {
                    return;
                }
                direction = value;
                OnPropertyChanged(this, "Direction");
            }
        }
    }

    public class IncomeFliter : BaseFliter, INotifyPropertyChanged
    {
        private IncomeFrom channel;

        public IncomeFrom Channel
        {
            get
            {
                return channel;
            }
            set
            {
                if (channel == value)
                {
                    return;
                }
                channel = value;
                OnPropertyChanged(this, "Channel");
            }
        }
    }


}
