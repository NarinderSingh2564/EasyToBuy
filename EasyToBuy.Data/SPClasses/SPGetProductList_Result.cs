using System.ComponentModel.DataAnnotations;

namespace EasyToBuy.Data.SPClasses
{
    public class SPGetProductList_Result
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int MRP { get; set; }
        public int Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public string ProductImage { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int ProductWeightId { get; set; }
        public bool ShowProductWeight { get; set; }
        public bool IsActive { get; set; }
        public string PackingMode { get; set; } = string.Empty;
        public string ProductWeight { get; set; } = string.Empty;
        public int Quantity { get; set; }

    }
}
