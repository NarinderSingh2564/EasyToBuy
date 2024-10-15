using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.DBClasses
{
    public class Pincodes
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string Zone { get; set; } = string.Empty;

        [StringLength(30)]
        public string Direction { get; set; } = string.Empty; 

        [StringLength(50)]
        public string OfficeName { get; set; } = string.Empty;

        [StringLength(50)]
        public string OfficeType { get; set; } = string.Empty;

        [StringLength(10)]
        public string Pincode { get; set; } = string.Empty;

        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        [StringLength(50)]
        public string State { get; set; } = string.Empty;

        [StringLength(30)]
        public string Latitude { get; set; } = string.Empty;

        [StringLength(30)]
        public string Longitude { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }
}
