using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.DBClasses
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Password { get; set; }
        public int Mobile { get; set; }

        [StringLength(30)]
        public string DealingPerson { get; set; }
        public int Pincode { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(30)]
        public string State { get; set; }

        [StringLength(30)]
        public string Country { get; set; }

        [StringLength(100)]
        public string FullAddress { get; set; }

        [StringLength(15)]
        public string Status { get; set; }

        [StringLength(100)]
        public string StatusRemarks { get; set; }
        public bool IsLicensed { get; set; }
        public DateTime? LicenseExpiredOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? LastLoginDate { get; set; }

    }
}
