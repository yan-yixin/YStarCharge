namespace YStarCharge.Model
{
    public class Expend
    {
        public bool IsSelected { get; set; }

        public int Number { get; set; }

        public string CreateAt { get; set; }

        public float Money { get; set; }

        public ExpendTo To { get; set; }

        public string Remark { get; set; }
    }

    public enum ExpendTo
    {
        购物,
        旅游,
        餐饮,
        其他
    }


}
