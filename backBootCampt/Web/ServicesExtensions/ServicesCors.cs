using System.Configuration;

namespace Web.ServicesExtensions
{
    public static class ServicesCors
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services , IConfiguration configuration)
        {
            var originsAllowed = configuration.GetSection("Cors:originsAllowed").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy("PoliticaCors", policy =>
                {
                    policy.WithOrigins(originsAllowed)
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
