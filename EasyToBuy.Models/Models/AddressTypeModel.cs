namespace EasyToBuy.Models.Models
{
    public class AddressTypeModel
    {
        public int Id { get; set; }
        public string TypeOfAddress { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
