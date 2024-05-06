using Microsoft.AspNetCore.Identity;

namespace AHFS.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<IdentityUser>
    {
    }
}