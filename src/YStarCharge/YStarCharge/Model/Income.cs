using System.ComponentModel;

namespace YStarCharge.Model
{
    public class Income:BaseIncomeExpend, INotifyPropertyChanged
    {
        private IncomeFrom from;
        public IncomeFrom From
        {
            get
            {
                return from;
            }
            set
            {
                if(from == value)
                {
                    return;
                }
                from = value;
                OnPropertyChanged(this, "From");
            }
        }
    }

    public enum IncomeFrom
    {
        工资,
        副业,
        其他
    }
}
