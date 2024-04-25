using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EasyToBuy.Models.Models
{
    public class ImageFileModel
    {
        public string fileName {  get; set; }
        public IFormFile file { get; set; }
    }
}
