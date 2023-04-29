using EverythingTech.Data;
using EverythingTech.Interfaces;
using EverythingTech.Models;
using Microsoft.EntityFrameworkCore;

namespace EverythingTech.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public bool Add(AppUser user)
        {
           _context.Add(user);
            return save();
        }

        public bool Delete(AppUser user)
        {
            _context.Remove(user);
            return save();
        }

        public async Task<AppUser> GetUserByEmail(string email)
        {
            return await _context.Users.FindAsync(email);

        }

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByName(string name)
        {
            return await _context.Users.FindAsync(name);
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
           return await _context.Users.ToListAsync();
        }

        public bool save()
        {

            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(AppUser user)
        {
            _context.Add(user);
            return save();
        }
    }
}
