using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Maintenance")]
[PrimaryKey(nameof(MaintenanceId))]
public class Maintenance
{
    [Required]
    public int MaintenanceId { get; set; }
    public string UserEmail { get; set; }
    public string MaintenanceType { get; set; }
    public DateOnly Date { get; set; }
    public string CallLog { get; set; }
    public string Comments { get; set; }
}