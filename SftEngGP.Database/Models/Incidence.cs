using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Incidence")]
[PrimaryKey(nameof(IncidenceId))]
public class Incidence
{
    public int IncidenceId;
    public string IncidenceType;
    public DateOnly DateOfEvent;
    public string Alert;
}