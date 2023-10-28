namespace LibApp.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public byte SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}
