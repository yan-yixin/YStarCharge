using System.ComponentModel;

namespace YStarCharge.Web.Models.Enums
{
    [Description("图表类型")]
    public enum StatisticsType
    {
        [Description("饼形图")]
        PieChart,
        [Description("柱状图")]
        BarChart,
        [Description("折线图")]
        LineChart,
    }
}
