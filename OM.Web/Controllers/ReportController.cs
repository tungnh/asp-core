using Microsoft.AspNetCore.Mvc;
using OM.Application.Models.Report;
using OM.Application.Services.Interfaces;

namespace OM.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportServiceFactory _reportServiceFactory;

        public ReportController(IReportServiceFactory reportServiceFactory)
        {
            _reportServiceFactory = reportServiceFactory;
        }

        [Route("Report/Index/{reportType}")]
        public IActionResult Index(string reportType)
        {
            var reportService = _reportServiceFactory.Create(reportType);
            return View(reportService.GetReportData());
        }
    }
}
