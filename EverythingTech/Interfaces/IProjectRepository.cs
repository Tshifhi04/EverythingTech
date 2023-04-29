using EverythingTech.Models;

namespace EverythingTech.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Projects>> GetAllProjects();
        Task<Projects> GetProjectsByName(string name);
        Task<Projects> GetProjectsById(int  id);

        bool Add(Projects projects);
        bool Update(Projects projects);
        bool Delete(Projects projects);
        bool save();
    }
}
