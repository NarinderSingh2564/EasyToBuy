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
        public int UserId { get; set; }
        public string OrderNumber { get; set; }
        public int NumberOfProducts { get; set; }
        public DateTime OrderDate { get; set; }
        public int StatusId { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int MRP { get; set; }
        public int Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
    }
}
