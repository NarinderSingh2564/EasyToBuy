
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

        [ForeignKey("ProductVariationAndRate")]
        public int VariationId { get; set; }
        public virtual ProductVariationAndRate ProductVariationAndRate { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "Decimal(7,2)")]
        public decimal MRP { get; set; }

        [Column(TypeName = "Decimal(7,2)")]
        public decimal Discount { get; set; }

        [Column(TypeName = "Decimal(7,2)")]
        public decimal DiscountPrice { get; set; }

        [Column(TypeName = "Decimal(7,2)")]
        public decimal AmountToBePaid { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
