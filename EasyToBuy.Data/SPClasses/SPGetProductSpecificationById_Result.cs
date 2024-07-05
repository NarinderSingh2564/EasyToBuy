using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.SPClasses
{


    public class SPGetProductSpecificationById_Result
    {
        public int Id { get; set; }
        public string Speciality { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string IngredientType { get; set; } = string.Empty;
        public string Ingredients { get; set; } = string.Empty;
        public string ShelfLife { get; set; } = string.Empty;
        public string Benefits { get; set; } = string.Empty;
    }
}
