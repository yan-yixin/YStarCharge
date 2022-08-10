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
        private ExpendUserControlViewModel viewModel;
        public ExpendUserControl()
        {
            InitializeComponent();
            viewModel = new ExpendUserControlViewModel();
            DataContext = viewModel;
            //viewModel.ContentListView = expendListView;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Expend expend = new Expend()
            {
                Number = 1,
                CreateAt = DateTime.Now.ToString("yyyy-MM-dd"),
                Money = 153.45f,
                Project = Project.Repast,

            };
            Expend expend1 = new Expend()
            {
                Number = 2,
                CreateAt = DateTime.Now.ToString("yyyy-MM-dd"),
                Money = 15,
                Project = Project.Other,
                Remark ="忘了怎么花的"
            };
            Expend expend2 = new Expend()
            {
                Number = 3,
                CreateAt = DateTime.Now.ToString("yyyy-MM-dd"),
                Money = 15,
                Project = Project.Other,
                Remark = "忘了怎么花的"
            };
            Expend expend3= new Expend()
            {
                Number = 4,
                CreateAt = DateTime.Now.ToString("yyyy-MM-dd"),
                Money = 15,
                Project = Project.Other,
                Remark = "忘了怎么花的"
            };
            viewModel.Expends.Add(expend);
            viewModel.Expends.Add(expend1);
            viewModel.Expends.Add(expend2);
            viewModel.Expends.Add(expend3);
        }

        private void DeleteTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("确定要删除记录", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Cancel)
            {
                return;
            }
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            int num = Convert.ToInt32(button.Tag);

            var expend = viewModel.Expends.FirstOrDefault(ex => ex.Number == num);
            if (expend != null)
            {
                viewModel.Expends.Remove(expend);
            }
            
        }

        private void EditTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            expendDataGrid.IsReadOnly = false;
        }

        private void AllSelectCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
