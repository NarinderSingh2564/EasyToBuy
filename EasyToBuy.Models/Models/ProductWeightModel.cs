using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.Models
{
    public class ProductWeightModel
    {
        public int Id { get; set; }
        public string ProductWeight { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
