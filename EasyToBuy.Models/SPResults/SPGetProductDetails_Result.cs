namespace EasyToBuy.Models.SPResults
{
    public class SPGetProductDetails_Result
    {
        public int Id { get; set; }
        public string ProductShortName { get; set; } = string.Empty;
        public int ProductPrice { get; set; } 
        public int ProductDiscount { get; set; }
        public decimal ProductPriceAfterDiscount { get; set; }
        public string ProductImageUrl { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string PackingMode { get; set; } = string.Empty;
    }
}
