using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AHFS.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        public string? Name { get; set; }
        public int? NrCredits { get; set; }

        public int? YearOfStudy { get; set; }
        public int? Semester { get; set; }

        public string? Faculty { get; set; }

        public string? Type { get; set; }

        public int? TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher ? Teacher { get; set; }

        public ICollection<Grade>? Grades { get; set; }

    }
}
