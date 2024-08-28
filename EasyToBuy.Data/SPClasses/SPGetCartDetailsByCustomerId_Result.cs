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
        public int VariationId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;
        public string ProductWeight { get; set; } = string.Empty;
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalProductPrice { get; set; }
        public bool ShowProductWeight { get; set; }
        public bool SetAsDefault { get; set; }
    }

    public class PriceDetails
    {
        public decimal TotalProductPrice { get; set; }
        public decimal TotalDiscountPrice { get; set; }
        public decimal TotalCartPrice { get; set; }
    }

}
