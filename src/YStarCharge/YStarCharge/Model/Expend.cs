using System.ComponentModel;

namespace YStarCharge.Model
{
    public class Expend: BaseIncomeExpend, INotifyPropertyChanged
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

    public enum ExpendTo
    {
        购物,
        旅游,
        餐饮,
        其他
    }


}
