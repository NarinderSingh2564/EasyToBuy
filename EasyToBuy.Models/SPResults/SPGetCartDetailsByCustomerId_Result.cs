namespace EasyToBuy.Models.SPResults
{

    public class GetCartDetailsByCustomerId
    {
        public PriceDetails priceDetails { get; set; }
        public List<SPGetCartDetailsByCustomerId_Result> _cartListItems { get; set; }

        public GetCartDetailsByCustomerId()
        {
            priceDetails = new PriceDetails();
            _cartListItems = new List<SPGetCartDetailsByCustomerId_Result>();
        }
    }

    public class SPGetCartDetailsByCustomerId_Result
    {
        public int Id { get; set; }
        public string ProductShortName { get; set; } = string.Empty;
        public int ProductPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal ProductDiscountPrice { get; set; }
        public decimal ProductPriceAfterDiscount{ get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductImageUrl { get; set; } = string.Empty;
        public string DelieveryTimeSpan { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int TotalProductPrice { get; set; }
    }

    public class PriceDetails
    {
        public int TotalPrice { get; set; }
        public int TotalDiscountPrice { get; set; }
        public int TotaCartPrice { get; set; }
    }

}
