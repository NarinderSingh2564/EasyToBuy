namespace EasyToBuy.Models.UIModels
{
    public class CategoryUIModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int PackingModeId { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
