using OM.Application.Services.Interfaces;
using OM.Application.Utils;

namespace OM.Application.Services.Report
{
    public class ReportServiceFactory : IReportServiceFactory
    {
        public IReportService Create(string reportType)
        {
            return reportType switch
            {
                ReportType.RC01 => new RC01ReportService(),
                ReportType.RC02 => new RC02ReportService(),
                _ => throw new NotSupportedException(),
            };
        }
    }
}
