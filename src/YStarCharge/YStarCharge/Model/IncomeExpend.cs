using SqlLib;
using System;

namespace YStarCharge.Model
{
    public class BaseIncomeExpend : NotifyPropertyChanged,IEntity
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

        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id == value)
                {
                    return;
                }
                id = value;
                OnPropertyChanged(this, "Id");
            }
        }

        public string Username { get; set; }

        private DateTime createAt;
        public DateTime CreateAt
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

        private float amount;
        public float Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (amount == value)
                {
                    return;
                }
                amount = value;
                OnPropertyChanged(this, "Amount");
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
