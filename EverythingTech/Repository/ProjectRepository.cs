using EverythingTech.Data;
using EverythingTech.Interfaces;
using EverythingTech.Models;
using Microsoft.EntityFrameworkCore;

namespace EverythingTech.Repository
{
    public class ProjectRepository : IProjectRepository
    {

        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public bool Add(Projects projects)
        {
            _context.Add(projects);
            return save();
        }

        public bool Delete(Projects projects)
        {
            _context.Remove(projects);
            return save();
        }

        public async Task<IEnumerable<Projects>> GetAllProjects()
        {
            return await _context.Projects.ToListAsync();
        }
        public async Task<Projects> GetProjectsById(int id)
        {
            return await _context.Projects.FindAsync(id);
        }
        public async Task<Projects> GetProjectsByName(string name)
        {
            return await _context.Projects.FindAsync(name);
        }

        public bool save()
        {

            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Projects projects)
        {
            throw new NotImplementedException();
        }
    }
}
