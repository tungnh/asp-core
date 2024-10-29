using OM.Application.Data.Repositories;
using OM.Infrastructure.Data.Repositories;

namespace OM.Web.Extensions.DependencyInjection
{
    public static class RepositoryBuilderExtensions
    {
        public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMemberRepository, MemberRepository>();
            return builder;
        }
    }
}
