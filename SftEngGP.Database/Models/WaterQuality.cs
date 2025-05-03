using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Water_quality", Schema = "dbo")]
[PrimaryKey(nameof(date), nameof(time))]

public class WaterQuality
{
    public DateOnly date { get; set; } = DateOnly.MinValue;
    public TimeOnly time { get; set; } = TimeOnly.MinValue;
    public double? nitrate { get; set; }
    public double? nitrite { get; set; }
    public double? phosphate { get; set; }
    public double? EC { get; set; }
    
    
}

