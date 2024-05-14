using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToBuy.Data.SPClasses
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
        public int ProductId { get; set; }
        public string VendorName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;
        public string ProductWeight { get; set; } = string.Empty;
        public int MRP { get; set; }
        public int Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
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
