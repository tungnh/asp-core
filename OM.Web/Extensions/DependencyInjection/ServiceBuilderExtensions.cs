using OM.Application.Services.Interfaces;
using OM.Application.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OM.Application.Services.Report;

namespace OM.Web.Extensions.DependencyInjection
{
    public static class ServiceBuilderExtensions
    {
        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            // Add email sender
            builder.Services.TryAddTransient<IEmailSender, NoOpEmailSender>();
            builder.Services.AddScoped<IMemberService, MemberService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            // Report
            builder.Services.AddScoped<IReportServiceFactory, ReportServiceFactory>();
            return builder;
        }
    }
}
