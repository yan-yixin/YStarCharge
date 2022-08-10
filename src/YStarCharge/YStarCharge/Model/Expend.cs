using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YStarCharge.Model
{
    public class Expend
    {
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
