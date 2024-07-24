using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.SPClasses
{
    public class SPGetProductSliderItemsByCategoryId_Result
    {
        public int Id { get; set; }
        public int VariationId { get; set; }
        public int CategoryId { get; set; }

        public string PackingMode {  get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public decimal PriceAfterDiscount { get; set; }
        public bool IsActive { get; set; }
    }
}
