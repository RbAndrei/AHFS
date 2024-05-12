using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHFS.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Sex { get; set; }
        public string? CNP { get; set; }
        public int? Age { get; set; }
        public string ? PhoneNr { get; set; }
        public string? Role { get; set; }
        public string? Faculty { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
    }
}
