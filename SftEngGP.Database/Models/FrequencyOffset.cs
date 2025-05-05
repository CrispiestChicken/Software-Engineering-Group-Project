using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SftEngGP.Database.Models
{
    [Table("FrequencyOffset")]
    [PrimaryKey(nameof(FrequencyId))]
    public class FrequencyOffset
    {
        [Required]
        public int FrequencyId { get; set; }
        public string Frequency { get; set; }
        public TimeSpan TimeDifference { get; set; }
        public int DateDifference { get; set; }
    }
}