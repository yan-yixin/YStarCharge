using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace YStarCharge.Document
{
    /// <summary>
    /// StatisticsDoucmentUserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class StatisticsDoucment : UserControl
    {
        public StatisticsDoucment()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            fliterComboBox.ItemsSource = Enum.GetNames(typeof(TimeUnit));
            string[] project = new string[] { "收入","支出"};
            expendComboBox.ItemsSource = project;
            fliterComboBox.SelectedIndex = 0;
            expendComboBox.SelectedIndex = 0;
        }
    }
}
