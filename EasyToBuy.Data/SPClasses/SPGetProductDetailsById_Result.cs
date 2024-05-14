namespace EasyToBuy.Data.SPClasses
{
    public class SPGetProductDetailsById_Result
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;
        public string PackingMode { get; set; } = string.Empty;
        public string ProductWeight { get; set; } = string.Empty;
        public int MRP { get; set; }
        public int Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public bool ShowProductWeight { get; set; }
        public int Quantity { get; set; }
    }
}
