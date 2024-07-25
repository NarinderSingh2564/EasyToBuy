namespace EasyToBuy.Models.Models
{
    public class ProductPackingModel
    {
        public int Id { get; set; }
        public string PackingType { get; set; }
        public int PackingModeId { get; set; }
        public bool IsActive { get; set; }
    }
}
