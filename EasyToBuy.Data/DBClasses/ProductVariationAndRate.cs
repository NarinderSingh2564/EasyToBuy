using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.DBClasses
{
    public class ProductVariationAndRate
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        
        [ForeignKey("ProductPacking")]
        public int ProductPackingId { get; set; }
        public virtual ProductPacking ProductPacking { get; set; }

        public int Quantity { get; set; }
        public bool ShowProductWeight { get; set; }

        
        [ForeignKey("ProductWeights")]
        public int ProductWeightId { get; set; }
        public virtual ProductWeights ProductWeights { get; set; }

        [Column(TypeName = "Decimal(7,2)")]
        public decimal MRP { get; set; }

        [Column(TypeName = "Decimal(7,2)")]
        public decimal Discount { get; set; }

        [Column(TypeName = "Decimal(7,2)")]
        public decimal DiscountPrice { get; set; }

        [Column(TypeName = "Decimal(7,2)")]
        public decimal PriceAfterDiscount { get; set; }
        public int StockQuantity { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool SetAsDefault { get; set; }
        public bool IsActive { get; set; }
    }
}
