using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OM.Application.Utils;
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

        [Authorize(Roles = Roles.Administrator)]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Roles = Roles.User)]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
