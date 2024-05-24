using EasyToBuy.Data.DBClasses;
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
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatus { get; set; }
        public int OrderCount { get; set; }
    }
}