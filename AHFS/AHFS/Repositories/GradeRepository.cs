using AHFS.Repositories.Interfaces;
using AHFS.Repositories;
using AHFS.Data;
using AHFS.Models;

namespace AHFS.Repositories
{
    public class GradeRepository : RepositoryBase<Grade>, IGradeRepository
    {
        public GradeRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
