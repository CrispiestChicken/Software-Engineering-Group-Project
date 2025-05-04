using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Sensor")]
[PrimaryKey(nameof(SensorId))]
public class Sensor
{
    [Required]
    public int SensorId { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    
    [Required]
    public string SensorType { get; set; }
    public ICollection<SensorReading> Readings { get; set; } = new List<SensorReading>();
    
}