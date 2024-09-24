namespace EasyToBuy.Data.SPClasses
{
    public class SPGetProductDetailsByOrderNumberAndUserId_Result
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal AmountToBePaid { get; set; }
    }
}
