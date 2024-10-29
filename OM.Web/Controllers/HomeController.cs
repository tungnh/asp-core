using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OM.Infrastructure.Identity;

namespace OM.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UserManager<User> userManager) : base(userManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
