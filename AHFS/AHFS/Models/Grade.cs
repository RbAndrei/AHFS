using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AHFS.Models
{
    public class Grade
    {

        [Key]
        public int GradeId { get; set; }
        public int SubjectId { get; set; }

        public double GradeValue { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }


        [ForeignKey("SubjectId")]
        public virtual Subject? Subject { get; set; }

    }
}
