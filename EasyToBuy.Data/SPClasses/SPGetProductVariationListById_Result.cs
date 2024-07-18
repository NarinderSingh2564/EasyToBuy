using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.SPClasses
{
    public class SPGetProductVariationListById_Result
    {

        public int Id { get; set; }
        public string PackingType { get; set; }
        public int Quantity { get; set; }
        public int ProductPackingId { get; set; }
        public int ProductWeightId { get; set; }
        public string ProductWeight { get; set; }
        public decimal ProductWeightValue { get; set; }
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public int StockQuantity { get; set; }
        public bool ShowProductWeight { get; set; }
        public bool SetAsDefault { get; set; }
        public bool IsActive { get; set; }

    }
}
