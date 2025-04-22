using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Incidence")]
[PrimaryKey(nameof(IncidenceId))]
public class Incidence
{
    public int IncidenceId { get; set; }
    public string IncidenceType { get; set; }
    public DateOnly DateOfEvent { get; set; }
    public string Alert { get; set; }
}