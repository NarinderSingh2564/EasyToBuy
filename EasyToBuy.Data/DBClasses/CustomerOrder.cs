using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToBuy.Data.DBClasses
{
    public class CustomerOrder
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
      
        [StringLength(20)]
        public string OrderNumber { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }

        [ForeignKey("OrderStatus")]
        public int StatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity {  get; set; }
        public int MRP { get; set; }
        public int Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal AmountToBePaid { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
