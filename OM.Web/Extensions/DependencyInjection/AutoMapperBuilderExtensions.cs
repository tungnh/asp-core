using AutoMapper;
using OM.Application.Mapper;

namespace OM.Web.Extensions.DependencyInjection
{
    public static class AutoMapperBuilderExtensions
    {
        public static WebApplicationBuilder AddMapper(this WebApplicationBuilder builder)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            builder.Services.AddSingleton(mapperConfig.CreateMapper());
            return builder;
        }
    }
}
