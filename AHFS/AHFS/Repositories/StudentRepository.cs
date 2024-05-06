using AHFS.Repositories.Interfaces;
using AHFS.Data;
using AHFS.Models;

namespace AHFS.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
