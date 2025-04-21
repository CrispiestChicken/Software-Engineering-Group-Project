using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SftEngGP.Database.Models;

namespace SftEngGP.Database.Data;

public class GpDbContext : DbContext
{

    public GpDbContext()
    {

    }

    public GpDbContext(DbContextOptions<GpDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var a = Assembly.GetExecutingAssembly();
        var resources = a.GetManifestResourceNames();
        using var stream = a.GetManifestResourceStream("SftEngGP.Database.appsettings.json");
    
        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();
    
        optionsBuilder.UseSqlServer(
            config.GetConnectionString("DevelopmentConnection"),
            m => m.MigrationsAssembly("SftEngGP.Migrations")
        );

    }

    public DbSet<SensorReading> Readings { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Configuration> Configurations { get; set; }
    public DbSet<Incidence> Incidences { get; set; }
    public DbSet<Measurand> Measurands { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<Update> Updates { get; set; }
    public DbSet<User> Users { get; set; }

}