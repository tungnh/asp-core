using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OM.Application.Services;
using OM.Models;
using System.Diagnostics;

namespace OM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMemberService memberService, ILogger<HomeController> logger)
        {
            _memberService = memberService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var data = _memberService.GetAllMembers();
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
