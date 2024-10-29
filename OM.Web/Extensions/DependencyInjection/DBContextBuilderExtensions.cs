using Microsoft.EntityFrameworkCore;
using OM.Infrastructure.Data;

namespace OM.Web.Extensions.DependencyInjection
{
    public static class DBContextBuilderExtensions
    {
        public static WebApplicationBuilder AddDBContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            return builder;
        }
    }
}
