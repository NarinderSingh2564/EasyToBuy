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
        public string ProductName { get; set; } = string.Empty;
        public string ProductShortName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductImageUrl { get; set; } = string.Empty;
        public string ProductTimeSpan { get; set; } = string.Empty;
        public string ProductWeight { get; set; } = string.Empty;
        public int ProductPrice { get; set; }
        public int ProductDiscount { get; set; }
        public decimal ProductDiscountPrice { get; set; }
        public decimal ProductPriceAfterDiscount{ get; set; }
        public int Quantity { get; set; }
        public decimal TotalProductPrice { get; set; }
        public bool ShowProductWeight { get; set; }
    }

    public class PriceDetails
    {
        public int TotalProductPrice { get; set; }
        public decimal TotalDiscountPrice { get; set; }
        public decimal TotalCartPrice { get; set; }
    }

}
