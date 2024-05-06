using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyToBuy.Data.DBClasses
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Password { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }
}
