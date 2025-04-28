using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SftEngGP.Database.Models;

namespace SftEngGP.Database.Data;

public class GpDbContext : GenericGPDbContext
{
    internal override String connectionName {get; set;} = "DevelopmentConnection";
}