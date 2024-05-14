namespace EasyToBuy.Models.UIModels
{
    public class CartUIModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }
        public string RequestFrom { get; set; }
    }
}
