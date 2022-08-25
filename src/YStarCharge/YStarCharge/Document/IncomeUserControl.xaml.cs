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
    /// IncomeUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class IncomeUserControl : UserControl
    {
        private readonly IncomeControlVM viewModel;
        public IncomeUserControl()
        {
            InitializeComponent();
            viewModel = new IncomeControlVM();
            DataContext = viewModel;
        }

        private void AllSelectCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            viewModel.SetCheckBoxChecked(true);
        }

        private void AllSelectCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            viewModel.SetCheckBoxChecked(false);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Income expend = new Income()
            {
                Number = 1,
                CreateAt = DateTime.Now.ToString("yyyy-MM-dd"),
                Money = 15323.45f,
                From = IncomeFrom.工资

            };
            Income expend1 = new Income()
            {
                Number = 2,
                CreateAt = DateTime.Now.ToString("yyyy-MM-dd"),
                Money = 1532,
                From = IncomeFrom.副业,
                Remark = "忘了怎么花的"
            };
            Income expend2 = new Income()
            {
                Number = 3,
                CreateAt = DateTime.Now.ToString("yyyy-MM-dd"),
                Money = 15000,
                From = IncomeFrom.其他,
                Remark = "忘了怎么花的"
            };
            viewModel.Incomes.Add(expend);
            viewModel.Incomes.Add(expend1);
            viewModel.Incomes.Add(expend2);
        }
    }
}
