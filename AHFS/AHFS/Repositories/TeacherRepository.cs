using AHFS.Repositories.Interfaces;
using AHFS.Data;
using AHFS.Models;

namespace AHFS.Repositories
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
