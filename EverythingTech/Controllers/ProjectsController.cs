using EverythingTech.Data;
using EverythingTech.Interfaces;
using EverythingTech.Models;
using EverythingTech.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EverythingTech.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectsController(IProjectRepository  projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Projects> projects = await _projectRepository.GetAllProjects();
            return View(projects);
        }
        public async Task<IActionResult> Index1()
        {
          //  IEnumerable<Projects> projects = await _projectRepository.GetAllProjects();
            return View();
        }
        public async Task<IActionResult> Create(Projects projects)
        {
            if(!ModelState.IsValid)
            {
                return View(projects);
            }
            _projectRepository.Add(projects);
            return RedirectToAction("Index");
            
        }
        //public IActionResult Create() 
        //{
        //    return View();
        //}
        public async Task<IActionResult> Details(int id)
        {
            Projects projects = await _projectRepository.GetProjectsById(id);
            return View(projects);

        }
    }
}
