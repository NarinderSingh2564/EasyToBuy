using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EasyToBuy.Data.DBClasses
{
    public class Address
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public string City { get; set; }
        public string State{ get; set; }
        public string Country{ get; set; }

        [StringLength(100)]
        public string FullAddress { get; set; } = string.Empty;

        [StringLength(10)]
        public string Pincode { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeliveryAddress { get; set; }

    }
}
