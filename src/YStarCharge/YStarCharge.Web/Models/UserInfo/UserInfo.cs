using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YStarCharge.Web.Models
{
    public class UserInfo
    {
        public int Id { get; set; }

        [ForeignKey("Username")]
        public string? Username { get; set; }

        [MaxLength(20)]
        public string? Name {  get; set; }

        public Gender Gender { get;set; }

        [Range(1,120)]
        public int Age { get; set; }

        public string? Industry { get; set; }

        public string? Address { get; set; }

    }

    public enum Gender
    {
        [Description("男")]
        Man,
        [Description("女")]
        Women,
    }
}
