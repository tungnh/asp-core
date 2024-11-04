namespace OM.Application.Services.Interfaces
{
    public interface IReportServiceFactory
    {
        IReportService Create(string reportType);
    }
}
