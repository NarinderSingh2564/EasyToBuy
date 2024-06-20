using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.DBClasses
{
    public class ProductSpecification
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Speciality { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Manufacturer { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string IngredientType { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Ingredients { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ShelfLife { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Benefits { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }
}
