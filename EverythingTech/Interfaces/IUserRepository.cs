using EverythingTech.Models;

namespace EverythingTech.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<AppUser> GetUserByEmail(string email);
        Task<AppUser> GetUserByName(string name);
        Task<AppUser> GetUserByIdAsync(string id);

        bool Add(AppUser user);
        bool Update(AppUser user);
        bool Delete(AppUser user);
        bool save();
    }
}
