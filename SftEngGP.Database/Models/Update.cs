using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Update")]
[PrimaryKey(nameof(UpdateId))]
public class Update
{
    public int UpdateId { get; set; }
    public string UpdateType { get; set; }
    public DateOnly DateOfLastUpdate { get; set; }
}