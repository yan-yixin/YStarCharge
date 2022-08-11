namespace YStarCharge.Model
{
    public class Expend
    {
        public bool IsSelected { get; set; }

        public int Number { get; set; }

        public string CreateAt { get; set; }

        public float Money { get; set; }

        public Project Project { get; set; }

        public string Remark { get; set; }
    }

    public enum Project
    {
        Shopping,
        Travel,
        Repast,
        Other
    }
}
