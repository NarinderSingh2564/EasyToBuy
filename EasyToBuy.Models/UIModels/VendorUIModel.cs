using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.UIModels
{
    public class VendorUIModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string DealingPerson { get; set; }
        public int Pincode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string FullAddress { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    
    }
}
