using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.DBClasses
{
    public class ProductImages
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductVariationAndRate")]
        public int VariationId { get; set; }
        public virtual ProductVariationAndRate ProductVariationAndRate { get; set; }

        [DataType("Varchar(50)")]
        public string Image { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }
}
