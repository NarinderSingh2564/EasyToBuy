using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.Models
{
    public class CustomerAddressModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int AddressTypeId { get; set; }
        public string FullAddress { get; set; } = string.Empty;
        public string TypeOfAddress { get; set; }
        public string Pincode { get; set; } = string.Empty;
        public bool IsDeliveryAddress { get; set; }      
    }
}
