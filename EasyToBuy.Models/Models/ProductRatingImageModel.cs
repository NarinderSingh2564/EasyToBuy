using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.Models
{
    public class ProductRatingImageModel
    {
        public int Id { get; set; }
        public int ProductRatingId { get; set; }
        public string ProductImage { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
