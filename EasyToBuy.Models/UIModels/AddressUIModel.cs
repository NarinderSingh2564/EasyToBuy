using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.UIModels
{
    public class AddressUIModel
    {       
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public int AddressTypeId { get; set; }
        public string Pincode { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
