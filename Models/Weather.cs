namespace SftEngGP.Models;

internal class Weather
{
    public DateTime? Date { get; set; } 
    public string? Temperature { get; set; }
    public string? Humidity { get; set; }
    public string? WindSpeed { get; set; }
    public string? WindDirection { get; set; }
}