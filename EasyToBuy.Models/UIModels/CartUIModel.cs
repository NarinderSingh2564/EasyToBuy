namespace EasyToBuy.Models.UIModels
{
    public class CartUIModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int VariationId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }
        public string RequestFrom { get; set; }
    }
}
