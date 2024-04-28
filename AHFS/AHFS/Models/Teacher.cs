using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AHFS.Models
{
    public class Teacher
    {
        [Key]
        public int StudentId { get; set; }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ? PhoneNr { get; set; }
        public string Role { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

    }
}
