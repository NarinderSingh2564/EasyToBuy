using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.DBClasses
{
    public class ProductRatingImages
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductRating")]
        public int ProductRatingId { get; set; }
        public virtual ProductRating ProductRating { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string ProductImage { get; set; }
        public int CreatedBy {  get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive {  get; set; }
    }
}
