using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VendorId { get; set; }
        public string OrderNumber { get; set; }
        public int NumberOfProducts { get; set; }
        public DateTime OrderDate { get; set; }
        public int StockQuantity { get; set; }
        public int StatusId { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int VariationId { get; set; }
        public int Quantity { get; set; }
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
    }
}
