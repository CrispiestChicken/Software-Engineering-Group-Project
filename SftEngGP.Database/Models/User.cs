using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table(("Users"))]
[PrimaryKey(nameof(UserId))]
public class User
{
    public int UserId;
    public string FName;
    public string LName;
    public string Address;
    public int RoleId;
    public int IncidenceId;

}