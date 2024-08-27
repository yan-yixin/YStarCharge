using LiveCharts.Wpf;
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

namespace LiveChartDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM mainWindowViewModel = new MainWindowVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
        }

        private void Chart_OnDataClick(object sender, LiveCharts.ChartPoint chartPoint)
        {
            //var chart = (PieChart)chartpoint.ChartView;

            ////clear selected slice.
            //foreach (PieSeries series in chart.Series)
            //    series.PushOut = 0;

            //var selectedSeries = (PieSeries)chartpoint.SeriesView;
            //selectedSeries.PushOut = 8;
        }
    }
}
