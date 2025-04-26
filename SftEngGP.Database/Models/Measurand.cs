using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Measurand")]
[PrimaryKey(nameof(MeasurandId))]
public class Measurand
{
    public int MeasurandId { get; set; }
    public string QuantityType { get; set; }
    public string Quantity { get; set; }
    public string Symbol { get; set; }
    public string Unit { get; set; }
    
    [Required]
    public string Frequency { get; set; }
    public int SensorId { get; set; }
}