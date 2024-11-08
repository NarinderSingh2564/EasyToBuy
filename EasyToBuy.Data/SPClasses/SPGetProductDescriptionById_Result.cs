namespace EasyToBuy.Data.SPClasses
{
    public class SPGetProductDescriptionById_Result
    {
        public int Id { get; set; }
        public int VariationId { get; set; }
        public int CategoryId {  get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public int TotalRatingAndReviewCount { get; set; }
        public string Rating { get; set; }
    }
}
