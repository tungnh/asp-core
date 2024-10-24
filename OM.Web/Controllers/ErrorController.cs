using Microsoft.AspNetCore.Mvc;

namespace OM.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult Error(int? statusCode)
        {
            if (statusCode.HasValue)
            {
                if (statusCode == 404)
                {
                    return View("404");
                }
                else
                {
                    return View("Error");
                }

            }
            return View();
        }
    }
}
