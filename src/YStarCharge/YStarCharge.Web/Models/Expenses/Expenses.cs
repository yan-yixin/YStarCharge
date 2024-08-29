using System.ComponentModel.DataAnnotations;
using YStarCharge.Web.Models.Enums;

namespace YStarCharge.Web.Models
{
    public class Expenses
    {
        public int Id { get; set; }

        public bool IsSelected { get; set; }

        public DateTime CreateAt { get; set; }

        [Range(0, 1000000)]
        public float Money { get; set; }

        public ExpensesTo To { get; set; }

        [MaxLength(50)]
        public string? Remark { get; set; }
    }
}
