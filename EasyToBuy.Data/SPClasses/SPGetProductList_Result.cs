using System.ComponentModel.DataAnnotations;

namespace EasyToBuy.Data.SPClasses
{
    public class SPGetProductList_Result
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public string ProductImage { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string ProductWeight { get; set; } = string.Empty;
        public bool ShowProductWeight { get; set; }
        public string PackingMode { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public bool IsActive { get; set; }

    }
}
