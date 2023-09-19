using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationProject.Models;

namespace WebApplicationProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        ProjectDbContext dbContext;
        public HomeController(ProjectDbContext _context)
        {
            dbContext = _context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string uid, string pwd)
        {
            UserData userObj = dbContext.UserSet.Where(x => (x.UserName == uid) && (x.Password == pwd)).FirstOrDefault();
            if (userObj!=null)
            {
                ViewBag.Message = "Welcome to Admin";
                return RedirectToAction("index","Employee");
            }
            else
            {
                ViewBag.Message = "Invalid User Id or Password";
                return View();
            }
            
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
         
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}