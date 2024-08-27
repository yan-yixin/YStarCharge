using System.ComponentModel;

namespace YStarCharge.Web.Models.Enums
{
    public enum IncomeFrom
    {
        [Description("工资")]
        Salary,
        [Description("副业")]
        Bywork,
        [Description("其他")]
        Other
    }

    public enum ExpensesTo
    {
        [Description("购物")]
        Shopping,
        [Description("旅游")]
        Tour,
        [Description("餐饮")]
        Repast,
        [Description("车辆")]
        Vehicle,
        [Description("其他")]
        Other,
    }
}
