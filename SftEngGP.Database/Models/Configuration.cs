using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Configuration")]
[PrimaryKey(nameof(ConfigId))]
public class Configuration
{
    public int ConfigId { get; set; }
    public string ReadingInterval { get; set; }
    public string ReadingFormat { get; set; }
    public float MinThreshold { get; set; }
    public float MaxThreshold { get; set; }
    public int SensorId { get; set; }
}