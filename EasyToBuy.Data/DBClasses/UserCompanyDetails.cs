using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToBuy.Data.DBClasses
{
    public class UserCompanyDetails
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [StringLength(30)]
        public string CompanyName { get; set; }

        [StringLength(200)]
        public string Description{ get; set; }

        [StringLength(30)]
        public string DealingPerson { get; set; }

        [StringLength(15)]
        public string GSTIN { get; set; }
        public int Pincode { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(30)]
        public string State { get; set; }

        [StringLength(30)]
        public string Country { get; set; }

        [StringLength(200)]
        public string FullAddress { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }
}
