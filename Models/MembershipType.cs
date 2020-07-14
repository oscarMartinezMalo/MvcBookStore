using System.ComponentModel.DataAnnotations;

namespace MvcBookStore.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGO = 1;
    }
}