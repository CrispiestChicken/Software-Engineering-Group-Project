using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SftEngGP.Database.Models;

namespace SftEngGP.Database.Data
{
    public abstract class GenericGPDbContext: DbContext {
    
        internal abstract string connectionName { get; set; }
    
        public GenericGPDbContext()
        {

        }

        public GenericGPDbContext(DbContextOptions options) : base(options)
        {
        
        }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {   
                var a = Assembly.GetExecutingAssembly();
                using var stream = a.GetManifestResourceStream("SftEngGP.Database.appsettings.json");
                
                var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

                optionsBuilder.UseSqlServer(
                    config.GetConnectionString(connectionName),
                    m => m.MigrationsAssembly("SftEngGP.Migrations")
                );
            }
        }

        public DbSet<SensorReading> Readings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Incidence> Incidences { get; set; }
        public DbSet<Measurand> Measurands { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }
        public DbSet<Sensor> Sensors { get; set; }

    public DbSet<Update> Updates { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<FrequencyOffset> FrequencyOffsets { get; set; }}
}