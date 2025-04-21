using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Sensor_Reading")]
[PrimaryKey(nameof(ReadingId))]
public class SensorReading
{
    public float SensorValue { get; set; }
    public DateTime Timestamp { get; set; }
    
    [Required]
    public int ReadingId { get; set; }
    
    public int SensorId { get; set; }
    public float SensorSetpoint { get; set; }
}