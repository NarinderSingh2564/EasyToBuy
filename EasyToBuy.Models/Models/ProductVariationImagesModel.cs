using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.Models
{
    public class ProductVariationImagesModel
    {
        public int Id { get; set; }
        public int VariationId { get; set; }
        public string Variation { get; set; }
        public string Image { get; set; }

    }
}
