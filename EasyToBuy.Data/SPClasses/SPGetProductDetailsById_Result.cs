using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.SPClasses
{
    [NotMapped]
    public class SPGetProductDetailsById_Result
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;
        public string PackingMode { get; set; } = string.Empty;
        public string ProductWeight { get; set; } = string.Empty;
        public int ProductPrice { get; set; }
        public int ProductDiscount { get; set; }
        public decimal ProductDiscountPrice { get; set; }
        public decimal ProductPriceAfterDiscount { get; set; }
        public bool ShowProductWeight { get; set; }
        public int Quantity { get; set; }
    }
}
