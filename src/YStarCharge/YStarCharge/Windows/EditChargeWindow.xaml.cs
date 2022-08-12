using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using YStarCharge.ViewModel;

namespace YStarCharge.Windows
{
    /// <summary>
    /// AddChargeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EditChargeWindow : Window
    {
        public EditChargeWindowViewModel ViewModel;
        public EditChargeWindow()
        {
            InitializeComponent();
            ViewModel = new EditChargeWindowViewModel();
            DataContext = ViewModel;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
