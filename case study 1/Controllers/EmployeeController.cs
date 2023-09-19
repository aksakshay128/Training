using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationProject.Models;

namespace WebApplicationProject.Controllers
{
    public class EmployeeController : Controller
    {
        private ProjectDbContext _dbConext;

        public EmployeeController(ProjectDbContext dbConext)
        {
            _dbConext = dbConext;
        }
        public IActionResult Index()
        {
            return View(_dbConext.EmployeeSet.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeData obj)
        {
            _dbConext.EmployeeSet.Add(obj);
            _dbConext.SaveChanges();
            return View();
        }
        public IActionResult Delete(int id)
        {
            EmployeeData obj = _dbConext.EmployeeSet.Find(id);
            _dbConext.EmployeeSet.Remove(obj);
            _dbConext.SaveChanges();
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }

        [Authorize]
        public IActionResult Details(EmployeeData obj)
        {
            return View(_dbConext.EmployeeSet.Find(obj));
        }
    }
}
