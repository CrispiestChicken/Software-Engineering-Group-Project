using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Update")]
[PrimaryKey(nameof(UpdateId))]
public class Update
{
    public int UpdateId;
    public string UpdateType;
    public DateOnly DateOfLastUpdate;
}