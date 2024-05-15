using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.SPClasses
{
    public class SPGetVendorOrdersCountById_Result
    {
        [Key]
        public int VendorId { get; set; }
        public string VendorName { get; set; } = string.Empty;
        public int PendingOrder { get; set; } 
        public int DeliveredOrder { get; set; } 
        public int CancelOrder { get; set; } 
        public int TotalOrder { get; set; } 
    }
}
