using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Weather", Schema = "dbo")]
[PrimaryKey(nameof(datetime))]

public class Weather
{
    public DateTime datetime { get; set; }
    public double? temperature { get; set; }
    public double? relative_humidity { get; set; }
    public double? wind_speed { get; set; }
    public int? wind_direction { get; set; }
}

