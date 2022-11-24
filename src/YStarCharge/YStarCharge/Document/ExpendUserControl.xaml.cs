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
using System.Windows.Navigation;
using System.Windows.Shapes;
using YStarCharge.Model;
using YStarCharge.ViewModel;

namespace YStarCharge.Document
{
    /// <summary>
    /// ExpendUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ExpendUserControl : UserControl
    {
        private ExpendControlVM viewModel;

        public ExpendUserControl()
        {
            InitializeComponent();
            viewModel = new ExpendControlVM();
            DataContext = viewModel;
            viewModel.DataGrid = expendDataGrid;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void AllSelectCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            viewModel.SetCheckBoxChecked(true);
        }

        private void AllSelectCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            viewModel.SetCheckBoxChecked(false);
        }

    }
}
