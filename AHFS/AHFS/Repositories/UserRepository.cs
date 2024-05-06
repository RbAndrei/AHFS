using Microsoft.AspNetCore.Identity;
using AHFS.Data;
using AHFS.Repositories.Interfaces;

namespace AHFS.Repositories
{
    public class UserRepository : RepositoryBase<IdentityUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
