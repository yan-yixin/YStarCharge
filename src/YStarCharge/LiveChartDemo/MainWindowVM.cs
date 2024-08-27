using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveChartDemo
{
    public class MainWindowVM
    {
        SeriesCollection lineSeriesCollection = new SeriesCollection();
        SeriesCollection colunmSeriesCollection = new SeriesCollection();
        SeriesCollection pieSeriesCollection = new SeriesCollection();
        List<string> _lineXLabels = new List<string>();
        List<string> _columnXLabels = new List<string>();

        public MainWindowVM()
        {
            GetLineSeriesData();
            GetColunmSeriesData();
            GetPieSeriesData();
        }

        #region 属性
        /// <summary>
        /// 折线图集合
        /// </summary>
        public SeriesCollection LineSeriesCollection
        {
            get
            {
                return lineSeriesCollection;
            }

            set
            {
                lineSeriesCollection = value;
            }
        }

        /// <summary>
        /// 柱状图集合
        /// </summary>
        public SeriesCollection ColunmSeriesCollection
        {
            get
            {
                return colunmSeriesCollection;
            }

            set
            {
                colunmSeriesCollection = value;
            }
        }

        /// <summary>
        /// 饼图图集合
        /// </summary>
        public SeriesCollection PieSeriesCollection
        {
            get
            {
                return pieSeriesCollection;
            }

            set
            {
                pieSeriesCollection = value;
            }
        }

        /// <summary>
        /// 折线图X坐标
        /// </summary>
        public List<string> LineXLabels
        {
            get
            {
                return _lineXLabels;
            }

            set
            {
                _lineXLabels = value;
            }
        }

        /// <summary>
        /// 柱状图X坐标
        /// </summary>
        public List<string> ColumnXLabels
        {
            get
            {
                return _columnXLabels;
            }

            set
            {
                _columnXLabels = value;
            }
        }
        #endregion

        #region 方法
        void GetLineSeriesData()
        {
            List<string> titles = new List<string> { "苹果"};
            List<List<double>> values = new List<List<double>>
            {
                new List<double> { 30, 40, 60 },
                new List<double> { 20, 10, 50 },
                new List<double> { 10, 50, 30 }
            };
            List<string> _dates = new List<string>();
            _dates = GetCurrentMonthDates();
            for (int i = 0; i < titles.Count; i++)
            {
                LineSeries lineseries = new LineSeries();
                lineseries.DataLabels = true;
                lineseries.Title = titles[i];
                lineseries.Values = new ChartValues<double>(values[i]);
                LineXLabels.Add("苹果");
                LineSeriesCollection.Add(lineseries);
            }
        }

        void GetColunmSeriesData()
        {
            List<string> titles = new List<string> { "Edge", "Chrome", "Firefox", "Other" };
            List<double> columnValues = new List<double> { 10, 70, 15, 5 };

            for (int i = 0; i < titles.Count; i++)
            {
                ColumnXLabels.Add(titles[i]);
            }
            ColumnSeries colunmseries = new ColumnSeries();
            colunmseries.DataLabels = true;
            colunmseries.Title = "浏览器份额";
            colunmseries.Values = new ChartValues<double>(columnValues);
            ColunmSeriesCollection.Add(colunmseries);

        }

        void GetPieSeriesData()
        {
            List<string> titles = new List<string> { "C#", "Java", "Python" };
            List<double> pieValues = new List<double> { 60, 30, 10 };
            ChartValues<double> chartvalue = new ChartValues<double>();
            for (int i = 0; i < titles.Count; i++)
            {
                chartvalue = new ChartValues<double>();
                chartvalue.Add(pieValues[i]);
                PieSeries series = new PieSeries();
                series.DataLabels = true;
                series.Title = titles[i];
                series.Values = chartvalue;
                PieSeriesCollection.Add(series);
            }
        }

        void ThreeColumnData()
        {
            List<string> titles = new List<string> { "苹果", "香蕉", "梨" };
            //三列示例数据
            List<List<double>> threeColunmValues = new List<List<double>>
            {
                new List<double> { 30, 40, 60 },
                new List<double> { 20, 10, 50 },
                new List<double> { 10, 50, 30 }
            };


            for (int i = 0; i < titles.Count; i++)
            {
                ColumnSeries colunmseries = new ColumnSeries();
                colunmseries.DataLabels = true;
                colunmseries.Title = titles[i];
                colunmseries.Values = new ChartValues<double>(threeColunmValues[i]);

                ColunmSeriesCollection.Add(colunmseries);
            }
        }

        /// <summary>
        /// 获取当前月的每天的日期
        /// </summary>
        /// <returns>日期集合</returns>
        List<string> GetCurrentMonthDates()
        {
            List<string> dates = new List<string>();
            DateTime dt = DateTime.Now;
            int year = dt.Year;
            int mouth = dt.Month;
            int days = DateTime.DaysInMonth(year, mouth);
            //本月第一天时间      
            DateTime dt_First = dt.AddDays(1 - (dt.Day));
            dates.Add(String.Format("{0:d}", dt_First.Date));

            for (int i = 1; i < days; i++)
            {
                DateTime temp = dt_First.AddDays(i);
                dates.Add(String.Format("{0:d}", temp.Date));
            }
            return dates;
        }
        #endregion
    }
}
