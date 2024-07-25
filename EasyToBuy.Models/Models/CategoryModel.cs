namespace EasyToBuy.Models.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public int PackingModeId { get; set; }
        public string PackingMode {  get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
