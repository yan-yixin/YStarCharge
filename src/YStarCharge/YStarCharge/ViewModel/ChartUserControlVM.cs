using System;
using System.Collections.Generic;
using LiveCharts;

namespace YStarCharge.ViewModel
{
    public class ChartUserControlVM : NotifyPropertyChanged
    {
        public SeriesCollection PieChartSeries { get; set; } = new SeriesCollection();

        public SeriesCollection LineChartSerise { get; set; } = new SeriesCollection();

        public SeriesCollection CloumnsChartSerise { get; set; } = new SeriesCollection();

        public List<string> AxisXLabel { get; set; } = new List<string>();

        private Func<double, string> formatter;
        public Func<double,string> Formatter
        {
            get
            {
                return formatter;
            }
            set
            {
                if(formatter == value)
                {
                    return;
                }
                formatter = value;
                OnPropertyChanged(this, "Formatter");
            }
        }

        public ChartUserControlVM()
        {
            Formatter = value => value.ToString("N");
        }

    }
}
