using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EasyToBuy.Models.UIModels
{
    public class ProductVariationImagesUIModel
    {
        public int VariationId { get; set; }
        public List<IFormFile> Images { get; set; }
        public int CreatedBy { get; set; }
    }
}
