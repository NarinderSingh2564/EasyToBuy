
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToBuy.Data.DBClasses
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("ProductVariationAndRate")]
        public int VariationId { get; set; }
        public virtual ProductVariationAndRate ProductVariationAndRate { get; set; }

        public int Quantity {  get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsPlaced { get; set; }
    }
}
