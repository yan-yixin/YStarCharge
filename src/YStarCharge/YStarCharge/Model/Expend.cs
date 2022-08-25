using System.ComponentModel;

namespace YStarCharge.Model
{
    public class Expend: BaseIncomeExpend, INotifyPropertyChanged
    {
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

    public enum ExpendTo
    {
        购物,
        旅游,
        餐饮,
        其他
    }


}
