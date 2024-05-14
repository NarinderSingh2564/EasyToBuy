using System.ComponentModel.DataAnnotations;

namespace EasyToBuy.Data.DBClasses
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
