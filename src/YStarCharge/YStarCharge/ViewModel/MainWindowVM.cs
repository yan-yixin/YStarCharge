using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YStarCharge.Document;

namespace YStarCharge.ViewModel
{
    internal sealed class MainWindowVM:NotifyPropertyChanged
    {
        public Grid ContentGrid { get; set; }

        private Visibility popup = Visibility.Collapsed;
        public Visibility Popup
        {
            get
            {
                return popup;
            }
            set
            {
                if(popup == value)
                {
                    return;
                }
                popup = value;
                OnPropertyChanged(this, "Popup");
            }
        }

        public ICommand User
        {
            get
            {
                return new RelayCommand(obj=> {
                    UserInfoControl uic = new UserInfoControl();
                    uic.VerticalAlignment = VerticalAlignment.Top;
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(uic);
                });
            }
        }

        public ICommand Detail => new RelayCommand(obj => {
            Popup = popup == Visibility.Collapsed ? Visibility.Hidden | Visibility.Collapsed : Visibility.Visible | Visibility.Collapsed;
        });

        public ICommand ExpendDetial => new RelayCommand(obj => {
            ExpendUserControl euc = new ExpendUserControl();
            ExpendAndIncomeDocument eaid = new ExpendAndIncomeDocument(euc);
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(eaid);
        });

        public ICommand IncomeDetial => new RelayCommand(obj =>
        {
            IncomeUserControl iuc = new IncomeUserControl();
            ExpendAndIncomeDocument eaid = new ExpendAndIncomeDocument(iuc);
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(eaid);
        });

        public ICommand Report => new RelayCommand(obj => {

        });

        public ICommand Close => new RelayCommand(obj => {
            Application.Current.Shutdown();
        });
    }
}
