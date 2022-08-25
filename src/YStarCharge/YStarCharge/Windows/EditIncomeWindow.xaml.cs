using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
    }
}
