using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models
{
    [Table("Incidence")]
    [PrimaryKey(nameof(IncidenceId))]
    public class Incidence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IncidenceId { get; set; }
        public string IncidenceType { get; set; }
        public DateTime DateOfEvent { get; set; }
        public int SensorId { get; set; }
        public string Alert { get; set; }
    }
}