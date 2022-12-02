
using LiveCharts;
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
using YStarCharge.Model;
using YStarCharge.ViewModel;

namespace YStarCharge.Document
{
    /// <summary>
    /// StatisticsUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ChartUserControl : UserControl
    {
        private ChartUserControlVM viewModel;
        private SolidColorBrush foreColor = new SolidColorBrush(Color.FromRgb(255,255,255));
        private TimeUnit timeUnit;
        private List<BaseIncomeExpend> Datas;
        private DateTime date;
        public ChartUserControl()
        {
            InitializeComponent();
            viewModel = new ChartUserControlVM();
            DataContext = viewModel;

        }

        public ChartUserControl(TimeUnit unit,List<BaseIncomeExpend> datas,DateTime date) : this()
        {
            timeUnit = unit;
            Datas = datas;
            this.date = date;
            lineChart.Visibility = Visibility.Hidden;
            columnsChart.Visibility = Visibility.Hidden;
            pieChart.Visibility = Visibility.Hidden;
        }

        private void AppendPieChartData()
        {
            viewModel.PieChartSeries.Clear();
            foreach (var name in Enum.GetNames(typeof(ExpendTo)))
            {
                PieSeries ps = new PieSeries()
                {
                    Title = name,
                    DataLabels = true,
                    Foreground = foreColor,
                    Values = new ChartValues<float>(),
                   
            };
                var expends = Datas.OrderBy(e => e.CreateAt);
                if (expends != null)
                {
                    ps.Values.Add(expends.Sum(r => r.Amount));
                }
                viewModel.PieChartSeries.Add(ps);
            }
        }

        private void AppendBarChartData()
        {
            viewModel.CloumnsChartSerise.Clear();
            ColumnSeries colunmseries = new ColumnSeries
            {
                DataLabels = true,
                Foreground = foreColor,
                Title = "金额",
                Values = new ChartValues<float>()
            };
            viewModel.CloumnsChartSerise.Add(colunmseries);
            var expends = Datas.OrderBy(e => e.CreateAt);
            switch (timeUnit)
            {
                case TimeUnit.年:
                    AppenYearData(colunmseries);
                    break;
                case TimeUnit.月:
                    AppenMonthData(colunmseries);
                    break;
                case TimeUnit.日:
                    AppenDayData(colunmseries);
                    break;
            }
        }

        private void AppendLineChartData()
        {
            viewModel.LineChartSerise.Clear();
            LineSeries lineSeries = new LineSeries
            {
                DataLabels = true,
                Foreground = foreColor,
                Title = "金额",
                Values = new ChartValues<float>()
            };
            viewModel.LineChartSerise.Add(lineSeries);
            var expends = Datas.OrderBy(e => e.CreateAt);

            switch (timeUnit)
            {
                case TimeUnit.年:
                    AppenYearData(lineSeries);
                    break;
                case TimeUnit.月:
                    AppenMonthData(lineSeries);
                    break;
                case TimeUnit.日:
                    AppenDayData(lineSeries);
                    break;
            }
        }

        private void AppenYearData(Series series)
        {
            var expends = Datas.OrderBy(e => e.CreateAt);
            for (int i = date.Year - 5; i <= date.Year + 5; i++)
            {
                viewModel.AxisXLabel.Add(i.ToString());

                var result = expends.Where(e => e.CreateAt.Year == i);
                if (result != null)
                {
                    var money = result.Sum(r => r.Amount);
                    series.Values.Add(money);
                }
            }
        }

        private void AppenMonthData(Series series)
        {
            var expends = Datas.OrderBy(e => e.CreateAt);
            for (int i = 1; i <= 12; i++)
            {
                viewModel.AxisXLabel.Add(i.ToString());

                var result = expends.Where(e => e.CreateAt.Month == i);
                if (result != null)
                {
                    var money = result.Sum(r => r.Amount);
                    series.Values.Add(money);
                }
            }
        }

        private void AppenDayData(Series series)
        {
            //根据月显示
            int maxDay = DateTime.DaysInMonth(date.Year,date.Month);
            var expends = Datas.OrderBy(e => e.CreateAt);
            for (int i = 1; i <= maxDay; i++)
            {
                viewModel.AxisXLabel.Add(i.ToString());

                var result = expends.Where(e => e.CreateAt.Day == i);
                if (result != null)
                {
                    var money = result.Sum(r => r.Amount);
                    series.Values.Add(money);
                }
            }
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            lineChart.Visibility = Visibility.Hidden;
            columnsChart.Visibility = Visibility.Hidden;
            pieChart.Visibility = Visibility.Hidden;
            if (sender is RadioButton)
            {
                var rb = sender as RadioButton;
                switch (rb.Content)
                {
                    case "折线图":
                        lineChart.Visibility = Visibility.Visible;
                        AppendLineChartData();
                        break;
                    case "柱状图":
                        columnsChart.Visibility = Visibility.Visible;
                        AppendBarChartData();
                        break;
                    case "饼形图":
                        AppendPieChartData();
                        pieChart.Visibility = Visibility.Visible;
                        break;
                    default: break;
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lineChart.Visibility = Visibility.Visible;
            AppendLineChartData();
        }


    }
}
