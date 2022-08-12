namespace YStarCharge.Model
{
    public class Income
    {
        public bool IsSelected { get; set; }

        public int Number { get; set; }

        public string CreateAt { get; set; }

        public float Money { get; set; }

        public IncomeFrom From { get; set; }

        public string Remark { get; set; }
    }

    public enum IncomeFrom
    {
        工资,
        副业,
        其他
    }
}
