using Microsoft.AspNetCore.Identity;

namespace AHFS.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(IdentityUser user);

        void DeleteUser(IdentityUser user);

        void UpdateUser(IdentityUser user);

        IdentityUser GetUserById(string id);

        List<IdentityUser> GetUsers();
    }
}

