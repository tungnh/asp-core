using Microsoft.AspNetCore.Mvc;
using OM.Web.Models;
using System.Diagnostics;

namespace OM.Web.Controllers
{
    public class ErrorController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("Error/{statusCode}")]
        public IActionResult Error(int? statusCode)
        {
            if (statusCode.HasValue)
            {
                return statusCode switch
                {
                    403 => View("AccessDenied"),
                    404 => View("NotFound"),
                    _ => View("Index"),
                };
            }
            return View();
        }
    }
}
