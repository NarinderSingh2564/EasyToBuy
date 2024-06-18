using System.ComponentModel.DataAnnotations;

namespace EasyToBuy.Data.DBClasses
{
    public class ProductPacking
    {
        [Key]
        public int Id { get; set; }

        [DataType("Varchar(50)")]
        public string PackingType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}