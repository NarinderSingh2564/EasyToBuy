using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToBuy.Data.DBClasses
{
    public class CustomerOrderStatusLog
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string OrderNumber { get; set; }

        [ForeignKey("ProductVariationAndRate")]
        public int VariationId { get; set; }
        public virtual ProductVariationAndRate ProductVariationAndRate { get; set; }
        public int VendorId { get; set; }
      
        [ForeignKey("OrderStatus")]
        public int StatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
