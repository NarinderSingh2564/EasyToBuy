using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.SPClasses
{
    public class SPGetOrderList_Result
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int VendorId { get; set; }
        public int StatusId { get; set; }
        public string UserName { get; set; }
        public string VendorName { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductWeight { get; set; }
        public int Quantity { get; set; }
        public int MRP { get; set; }            
        public int Discount { get; set; }
        public decimal AmountToBePaid { get; set; }
    }
}
