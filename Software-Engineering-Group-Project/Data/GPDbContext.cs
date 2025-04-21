using Microsoft.EntityFrameworkCore;
using SftEngGP.Models;

namespace SftEngGP.Data;

public class GpDbContext : DbContext
{

    public GpDbContext()
    {

    }

    public GpDbContext(DbContextOptions<GpDbContext> options) : base(options)
    {
        
    }

    public DbSet<Entry> Entries { get; set; }

}