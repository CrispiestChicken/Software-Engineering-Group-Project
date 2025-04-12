namespace SftEngGP.Models;

internal class Weather
{
    public DateTime? Date { get; set; } 
    public double? Temperature { get; set; }
    public int? Humidity { get; set; }
    public double? WindSpeed { get; set; }
    public int? WindDirection { get; set; }
}