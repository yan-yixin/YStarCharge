using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YStarCharge.Model;

namespace YStarCharge.ViewModel
{
    public sealed class EditIncomeWindowVM:NotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title == value)
                {
                    return;
                }
                title = value;
                OnPropertyChanged(this, "Title");
            }
        }

        public Income Income { get; set; } = new Income();
    }
}
