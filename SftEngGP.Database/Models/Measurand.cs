using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Measurand")]
[PrimaryKey(nameof(MeasurandId))]
public class Measurand
{
    public int MeasurandId;
    public string QuantityType;
    public string Quantity;
    public string Symbol;
    public string Unit;
    public string MeasurmentFrequency;
    public string SensorId;
}