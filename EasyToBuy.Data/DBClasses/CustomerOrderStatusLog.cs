using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToBuy.Data.DBClasses
{
    public class CustomerOrderStatusLog
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CustomerOrder")]
        public int OrderId { get; set; }
        public virtual CustomerOrder CustomerOrder { get; set; }

        [ForeignKey("OrderStatus")]
        public int StatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
