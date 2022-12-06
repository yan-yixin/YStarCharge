using System;

namespace YStarCharge.Model
{
    public class Querier :NotifyPropertyChanged
    {
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if (date == value)
                {
                    return;
                }
                date = value;
                OnPropertyChanged(this, "Date");
            }
        }

        private TimeUnit timeUnit;
        public TimeUnit TimeUnit
        {
            get
            {
                return timeUnit;
            }
            set
            {
                if (timeUnit == value)
                {
                    return;
                }
                timeUnit = value;
                OnPropertyChanged(this, "TimeUnit");
            }
        }

        private IncomeAndExpend incomeAndExpend;
        public IncomeAndExpend IncomeAndExpend
        {
            get
            {
                return incomeAndExpend;
            }
            set
            {
                if (incomeAndExpend == value)
                {
                    return;
                }
                incomeAndExpend = value;
                OnPropertyChanged(this, "IncomeAndExpend");
            }
        }

    }
}
