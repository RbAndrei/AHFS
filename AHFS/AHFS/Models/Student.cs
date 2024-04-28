using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHFS.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public string Class { get; set; }
        public string Group { get; set; }
        public string Subgroup { get; set; }
        public bool Scholarship { get; set; }
        public int FinalGrade { get; set; }
        public string Faculty { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
