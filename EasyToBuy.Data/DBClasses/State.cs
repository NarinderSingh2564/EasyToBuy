using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToBuy.Data.DBClasses
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string StateName { get; set; }

        [ForeignKey("Countrys")]
        public int CountryId { get; set; }
        public Country Countrys { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}