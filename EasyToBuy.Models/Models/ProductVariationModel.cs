using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.Models
{
    public class ProductVariationModel
    {
        public int VariationId { get; set; }
        public string Variation { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
