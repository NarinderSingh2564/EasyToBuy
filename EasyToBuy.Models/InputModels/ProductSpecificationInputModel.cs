using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.InputModels
{
    public class ProductSpecificationInputModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Speciality { get; set; }
        public string Manufacturer { get; set; }
        public string IngredientType { get; set; }
        public string Ingredients { get; set; }
        public string ShelfLife { get; set; }
        public string Benefits { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
