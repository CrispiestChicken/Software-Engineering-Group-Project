using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SftEngGP.Database.Models;

namespace SftEngGP.Database.Data
{
    public class GpDbContext(DbContextOptions<GpDbContext> options) : GenericGPDbContext(options)
    {
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorReading> SensorReadings { get; set; }
        internal override String connectionName { get; set; } = "DevelopmentConnection";
    }
}