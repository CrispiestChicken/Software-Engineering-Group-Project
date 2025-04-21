using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Sensor")]
[PrimaryKey(nameof(SensorId))]
public class Sensor
{
    [Required]
    public int SensorId;
    public float Latitude;
    public string Longitude;
    public string SensorType;
}