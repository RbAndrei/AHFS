using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace AHFS.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        public int TeacherId { get; set; }

        public string Name { get; set; }
        public int NrCredits { get; set; }

        public string Faculty { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Grade>? Grade { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher? Teacher { get; set; }

    }
}
