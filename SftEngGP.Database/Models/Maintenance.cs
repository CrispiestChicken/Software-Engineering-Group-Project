using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models
{
    [Table("Maintenance")]
    [PrimaryKey(nameof(MaintenanceId))]
    public class Maintenance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaintenanceId { get; set; }
        public string UserEmail { get; set; }
        public int SensorId { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
    }
}