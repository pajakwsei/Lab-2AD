using System.ComponentModel.DataAnnotations;

namespace LibApp.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public byte SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int PayAsYouGo = 1;
        public static readonly int Monthly = 2;
        public static readonly int Quaterly = 3;
        public static readonly int Annually = 4;
    }
}
