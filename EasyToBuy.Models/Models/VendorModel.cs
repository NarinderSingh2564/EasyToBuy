using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.Models
{
    public class VendorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string DealingPerson { get; set; }
        public int Pincode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string FullAddress { get; set; }
        public string Status { get; set; }
        public string StatusRemarks { get; set; }
        public bool IsLicensed { get; set; }
        public DateTime? LicenseExpiredOn { get; set; }
       
    }
}
