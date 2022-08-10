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
    internal sealed class MainWindowViewModel
    {

        public Grid ContentGrid { get; set; }
        public ICommand User
        {
            get
            {
                return new RelayCommand(obj=> {
                    UserInfoControl uic = new UserInfoControl();
                    ContentGrid.Children.Add(uic);
                });
            }
        }

        public ICommand Expend
        {
            get
            {
                return new RelayCommand(obj => {
                    ExpendAndIncomeDocument iuc = new ExpendAndIncomeDocument();
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(iuc);
                });
            }
        }

        public ICommand Report
        {
            get
            {
                return new RelayCommand(obj => {

                });
            }
        }


        public ICommand Close
        {
            get => new RelayCommand(obj=> {
                Application.Current.Shutdown();
            });
        }
    }
}
