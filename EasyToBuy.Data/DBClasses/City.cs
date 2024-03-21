using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToBuy.Data.DBClasses
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string CityName { get; set; } = string.Empty;

        [ForeignKey("States")]
        public int StateId { get; set; }
        public State States { get; set; } 
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}