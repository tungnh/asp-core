namespace OM.Web.Extensions.DependencyInjection
{
    public static class AuthorizationBuilderExtensions
    {
        public static WebApplicationBuilder AddAuthorization(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Member", policy =>
                                  policy.RequireClaim("Member", "Index", "Create", "Edit", "Details", "Delete"));
            });

            return builder;
        }
    }
}
