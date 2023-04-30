using System.ComponentModel;

namespace YStarCharge.Model
{
    public class Income:BaseIncomeExpend, INotifyPropertyChanged
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
                if(channel == value)
                {
                    return;
                }
                channel = value;
                OnPropertyChanged(this, "Channel");
            }
        }
    }

    public enum IncomeFrom
    {
        工资,
        副业,
        其他,
        全部
    }
}
