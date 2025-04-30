using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models
{
    [Table(("Users"))]
    [PrimaryKey(nameof(UserId))]
    [Index(nameof(Email), IsUnique=true)]
    public class User
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        
        public string Email { get; set; }
        public string Password { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        public int IncidenceId { get; set; }

    }
}