using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OM.Infrastructure.Identity;

namespace OM.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UserManager<User> _userManager;

        public BaseController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
    }
}
