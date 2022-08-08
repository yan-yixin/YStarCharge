using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YStarCharge.Model;

namespace YStarCharge.ViewModel
{
    public sealed class IncomeUserControlViewModel
    {
        public ObservableCollection<Expend> Expends { get; set; } = new ObservableCollection<Expend>();

        public ListView ContentListView { get; set; }

        public ICommand Edit
        {
            get
            {
                return new RelayCommand(obj=> { 
                    
                });
            }
        }

        public ICommand Delete
        {
            get
            {
                return new RelayCommand(obj => {
                    
                });
            }
        }
    }
}
