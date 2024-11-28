using OM.Application.Data.Repositories;
using OM.Infrastructure.Data.Repositories;

namespace OM.Web.Extensions.DependencyInjection
{
    public static class RepositoryBuilderExtensions
    {
        public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMemberRepository, MemberRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductDetailRepository, ProductDetailRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            return builder;
        }
    }
}
