using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SftEngGP.Database.Models;

namespace SftEngGP.Database.Data;

public class GpDbContext(DbContextOptions<GpDbContext> options) : GenericGPDbContext(options)
{
    public DbSet<WaterQuality> WaterQuality { get; set; }
    public DbSet<AirQuality> AirQuality { get; set; }
    public DbSet<Weather> Weather { get; set; }
    internal override String connectionName {get; set;} = "DevelopmentConnection";
}