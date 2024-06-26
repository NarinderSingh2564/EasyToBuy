namespace EasyToBuy.Models.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int VariationId { get; set; }    
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
