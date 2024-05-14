namespace EasyToBuy.Models.UIModels
{
    public class ProductUIModel
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string ProductName { get; set; }
        public int MRP { get; set; }
        public int Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public int CategoryId { get; set; }
        public int ProductWeightId { get; set; }
        public bool ShowProductWeight { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
