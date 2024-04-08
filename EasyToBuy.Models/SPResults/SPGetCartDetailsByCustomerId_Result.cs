namespace EasyToBuy.Models.SPResults
{
    public class SPGetCartDetailsByCustomerId_Result
    {
        public int Id { get; set; }
        public string ProductShortName { get; set; } = string.Empty;
        public int ProductPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public string ProductImageUrl { get; set; } = string.Empty ;
        public int Quantity { get; set; }
        public int TotalProductPrice { get; set; }
    }
}
