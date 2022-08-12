using System.ComponentModel;

namespace YStarCharge.Model
{
    public class Expend:INotifyPropertyChanged
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
                if(IsSelected == value)
                {
                    return;
                }
                isSelected = value;
                OnPropertyChanged("IsSeleted");
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
                OnPropertyChanged("Number");
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
                OnPropertyChanged("CreateAt");
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
                if(money == value)
                {
                    return;
                }
                money = value;
                OnPropertyChanged("Money");
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
                OnPropertyChanged("To");
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
                if(remark == value) { return; }
                remark = value;
                OnPropertyChanged("Remark");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
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
