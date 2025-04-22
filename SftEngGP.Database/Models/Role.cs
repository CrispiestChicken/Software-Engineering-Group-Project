using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models;

[Table("Role")]
[PrimaryKey(nameof(RoleId))]
public class Role
{
    [Required] 
    public int RoleId { get; set; }

    public string RoleName { get; set; }

}