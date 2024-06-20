using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.SPClasses
{
    public class SPGetProductVariationListById_Result
    {
        public int Id { get; set; }
        public string PackingType { get; set; } = string.Empty;
        public int Quantity { get; set; } 
        public string ProductWeight { get; set; } = string.Empty;
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public int StockQuantity { get; set; }
        public bool ShowProductWeight { get; set; }
        public bool SetAsDefault { get; set; }
    }
}
