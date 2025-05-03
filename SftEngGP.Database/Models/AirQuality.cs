using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Air_quality", Schema = "dbo")]
[PrimaryKey(nameof(date), nameof(time))]
public class AirQuality
{
    public DateOnly date { get; set; } 
    public TimeOnly time { get; set; }
    public double? nitrogen_dioxide { get; set; }
    public double? sulphur_dioxide { get; set; }
    public double? PM2_5 { get; set; }
    public double? PM10 { get; set; }
}
