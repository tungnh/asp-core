using OM.Application.Services.Interfaces;

namespace OM.Application.Services.Report
{
    public class RC01ReportService : BaseReportService, IReportService
    {
        public string GetReportTemplate() => "This is report template for RC01";

        public object GetReportData()
        {
            return "This is report data for RC01";
        }
    }
}
