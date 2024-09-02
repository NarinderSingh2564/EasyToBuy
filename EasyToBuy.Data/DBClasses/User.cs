using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.DBClasses
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(15)]
        public string UserCode { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(12)]
        public string Mobile { get; set; }
      
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int Pincode { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(30)]
        public string State { get; set; }

        [StringLength(30)]
        public string Country { get; set; }

        [StringLength(200)]
        public string FullAddress { get; set; }

        [StringLength(30)]
        public string IdentificationType { get; set; }

        [StringLength(30)]
        public string IdentificationNumber { get; set; }
        public bool IsActive { get; set; }

        [StringLength(100)]
        public string StatusRemarks { get; set; }
        public bool IsLicensed { get; set; }
        public DateTime? LicenseExpiredOn { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
