using System;
using System.Windows;
using YStarCharge.ViewModel;

namespace YStarCharge.Windows
{
    /// <summary>
    /// AddChargeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EditExpendWindow : Window
    {
        public EditExpendWindowVM ViewModel;
        public EditExpendWindow()
        {
            InitializeComponent();
            ViewModel = new EditExpendWindowVM();
            DataContext = ViewModel;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(ViewModel.Expend.CreateAt == DateTime.MinValue)
            {
                ViewModel.Expend.CreateAt = DateTime.Now;
            }
        }
    }
}
