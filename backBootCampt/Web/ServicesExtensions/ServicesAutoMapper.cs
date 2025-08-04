using Business.AutoMapper;

namespace Web.ServicesExtensions
{
    public static class ServicesAutoMapper
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            // Registra AutoMapper usando el perfil AutoMapperProfile definido en el proyecto
            services.AddAutoMapper(typeof(AutoMapperModel));
            return services;
        }
    }
}
