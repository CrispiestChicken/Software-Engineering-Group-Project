using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Models;


[Table("Weather")]
[PrimaryKey(nameof(Date))]
internal class Weather
{
    public DateTime? Date { get; set; }
    [Required]
    public double? Temperature { get; set; }
    public int? Humidity { get; set; }
    public double? WindSpeed { get; set; }
    public int? WindDirection { get; set; }
}