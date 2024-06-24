using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.Models
{
    public class ProductPackingModel
    {
        public int Id { get; set; }
        public string PackingType { get; set; }
        public bool IsActive { get; set; }
    }
}
