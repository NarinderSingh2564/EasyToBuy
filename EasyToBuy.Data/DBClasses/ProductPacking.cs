using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToBuy.Data.DBClasses
{
    public class ProductPacking
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductPackingMode")]
        public int PackingModeId { get; set; }
        public virtual ProductPackingMode ProductPackingMode { get; set; }

        [DataType("Varchar(50)")]
        public string PackingType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}