using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using YStarCharge.Web.Models.Enums;

namespace YStarCharge.Web.Models
{
    public class Income
    {
        public int Id { get; set; }

        public DateTime CreateAt { get; set; }

        [Required(ErrorMessage = "请输入金额")]
        [Range(0, 1000000)]
        public float Money { get; set; }

        public IncomeFrom From { get; set; }

        [MaxLength(50)]
        public string? Remark { get; set; }

    }
}
