namespace EasyToBuy.Data.SPClasses
{
    public class SPGetProductList_Result
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public decimal TotalVolume { get; set; }
        public int PackingModeId { get; set; }
        public string PackingMode { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public int VariationId { get; set; }
        public string ProductWeight { get; set; } = string.Empty;
        public bool ShowProductWeight { get; set; }
        public int Quantity { get; set; }

    }
}
