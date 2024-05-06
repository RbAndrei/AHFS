using AHFS.Repositories.Interfaces;
using AHFS.Data;
using AHFS.Models;

namespace AHFS.Repositories
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
