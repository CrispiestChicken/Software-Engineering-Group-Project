using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Configuration")]
[PrimaryKey(nameof(ConfigId))]
public class Configuration
{
    public int ConfigId;
    public string ReadingInterval;
    public string ReadingFormat;
    public float MinThreshold;
    public float MaxThreshold;
    public int SensorId;
}