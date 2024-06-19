using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.InputModels
{
    public class ProductVariationAndRateInputModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductPackingId { get; set; }
        public int Quantity { get; set; }
        public bool ShowProductWeight { get; set; }
        public int ProductWeightId { get; set; }
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public int StockQuantity { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool SetAsDefault { get; set; }
        public bool IsActive { get; set; }
    }
}
