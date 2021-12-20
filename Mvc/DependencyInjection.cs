using Microsoft.EntityFrameworkCore;
using Mvc.Data.Context;

namespace Mvc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyPOSContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("MyPOSConnection"));
            });

            return services;
        }
    }
}
