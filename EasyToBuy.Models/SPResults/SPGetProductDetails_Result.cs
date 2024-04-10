namespace EasyToBuy.Models.SPResults
{
    public class SPGetProductDetails_Result
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductShortName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductImageUrl { get; set; } = string.Empty;
        public string PackingMode { get; set; } = string.Empty;
        public string ProductWeight { get; set; } = string.Empty;
        public int ProductPrice { get; set; } 
        public int ProductDiscount { get; set; }
        public decimal ProductDiscountPrice { get; set; }
        public decimal ProductPriceAfterDiscount { get; set; }
        public bool ShowProductWeight { get; set; }
        public int Quantity { get; set; }

    }
}
