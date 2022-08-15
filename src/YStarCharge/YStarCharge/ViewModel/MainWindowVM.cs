using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YStarCharge.Document;
using YStarCharge.Windows;

namespace YStarCharge.ViewModel
{
    internal sealed class MainWindowVM:NotifyPropertyChanged
    {
        public Grid ContentGrid { get; set; }

        public LoginWindowVM LoginWindowVM { get; } = new LoginWindowVM();

        public event EventHandler WindowClose;

        private Visibility menuPopup = Visibility.Collapsed;
        public Visibility Popup
        {
            get
            {
                return menuPopup;
            }
            set
            {
                if(menuPopup == value)
                {
                    return;
                }
                menuPopup = value;
                OnPropertyChanged(this, "Popup");
            }
        }

        private bool isOpen;
        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
            set
            {
                if(isOpen == value)
                {
                    return;
                }
                isOpen = value;
                OnPropertyChanged(this, "IsOpen");
            }
        }

        public ICommand UserManager => new RelayCommand(obj=> {
            IsOpen = isOpen ? false : true;
        
        });

        public ICommand UserInfo => new RelayCommand(obj => {
            UserInfoControl uic = new UserInfoControl();
            uic.VerticalAlignment = VerticalAlignment.Top;
            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(uic);
        });

        public ICommand Logout => new RelayCommand(obj=> {
            //关闭主界面
            OnWindowClose();

            LoginWindow lw = new LoginWindow();
            lw.Show();
        });

        public ICommand Detail => new RelayCommand(obj => {
            Popup = menuPopup == Visibility.Collapsed ? Visibility.Hidden | Visibility.Collapsed : Visibility.Visible | Visibility.Collapsed;
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

        private void OnWindowClose()
        {
            WindowClose?.Invoke(this,EventArgs.Empty);
        }
    }
}
