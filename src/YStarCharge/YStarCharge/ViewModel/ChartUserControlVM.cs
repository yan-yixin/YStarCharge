using System.Collections.Generic;
using LiveCharts;

namespace YStarCharge.ViewModel
{
    public class ChartUserControlVM
    {
        public SeriesCollection PieChartSeries { get; set; } = new SeriesCollection();

        public SeriesCollection LineChartSerise { get; set; } = new SeriesCollection();

        public SeriesCollection CloumnsChartSerise { get; set; } = new SeriesCollection();

        public List<string> AxisXLabel { get; set; } = new List<string>();

    }
}
