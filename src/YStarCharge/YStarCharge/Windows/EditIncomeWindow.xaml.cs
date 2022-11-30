using System;
using System.Windows;
using YStarCharge.ViewModel;

namespace YStarCharge.Windows
{
    /// <summary>
    /// EditIncomeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EditIncomeWindow : Window
    {
        public EditIncomeWindowVM ViewModel { get; private set; }

        public EditIncomeWindow()
        {
            InitializeComponent();

            ViewModel = new EditIncomeWindowVM();
            DataContext = ViewModel;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Income.CreateAt == DateTime.MinValue)
            {
                ViewModel.Income.CreateAt = DateTime.Now;
            }
        }
    }
}
