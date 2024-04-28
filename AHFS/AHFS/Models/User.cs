using System.ComponentModel.DataAnnotations;

namespace AHFS.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ? PhoneNr { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Teacher>? Teacher { get; set; }

        public virtual ICollection<Student>? Student { get; set; }

    }
}
