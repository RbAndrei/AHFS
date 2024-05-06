using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AHFS.Models
{
    public class Grade
    {

        [Key]
        public int GradeId { get; set; }
        public int? SubjectId { get; set; }

        public double? GradeValue { get; set; }
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }

        [ForeignKey("SubjectId")]
        public Subject? Subject { get; set; }

    }
}
