using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToBuy.Data.DBClasses
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string CountryCode { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string CountryName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

    }
}