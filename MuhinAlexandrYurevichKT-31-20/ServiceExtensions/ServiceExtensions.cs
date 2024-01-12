using MuhinAlexandrYurevichKT_31_20.Interfaces.StudentInterfaces;
using static MuhinAlexandrYurevichKT_31_20.Interfaces.StudentInterfaces.IStudentService;

namespace MuhinAlexandrYurevichKT_31_20.ServiceExtensions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            return services;
        }
    }
}
