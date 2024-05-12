using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHFS.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNr { get; set; }
        public string? Class { get; set; }
        public string? Group { get; set; }
        public string? Subgroup { get; set; }
        public bool? Scholarship { get; set; }
        public double? FinalGrade { get; set; }
        public string? Faculty { get; set; }
        public string? Sex { get; set; }
        public string? CNP { get; set; }
        public int? Age { get; set; }
        public int? YearOfStudy { get; set; }
        public int? Semester { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }

        public ICollection<Grade>? Grades { get; set; }

    }
}
