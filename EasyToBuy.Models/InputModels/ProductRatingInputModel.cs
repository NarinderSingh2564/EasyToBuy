using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Models.InputModels
{
    public class ProductRatingInputModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewDescription { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
