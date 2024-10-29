using OM.Application.Data.Queries;
using OM.Infrastructure.Data.Queries;

namespace OM.Web.Extensions.DependencyInjection
{
    public static class QueryBuilderExtensions
    {
        public static WebApplicationBuilder AddQueries(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMemberQuery, MemberQuery>();
            return builder;
        }
    }
}
