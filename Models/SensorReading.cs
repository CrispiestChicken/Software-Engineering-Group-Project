using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Models;

[Table("Sensor_reading")]
[PrimaryKey(nameof(Reading_id))]
public class SensorReading
{
    public float Sensor_value { get; set; }
    public DateTime Timestamp { get; set; }
    
    [Required]
    public int Reading_id { get; set; }
    
    public int Sensor_id { get; set; }
    public float Sensor_setpoint { get; set; }
}