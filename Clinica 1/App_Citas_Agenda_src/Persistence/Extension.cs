using Core.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Data;


namespace Persistence
{
    public static class Extension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (ServiceProvider provider = services.BuildServiceProvider())
                configuration = ServiceProviderServiceExtensions.GetService<IConfiguration>(provider);

            services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(configuration["sql:cx"]));

            services.AddTransient<ICitas, CitasRepository>();
            services.AddTransient<ITurnos, TurnosRepository>();
            services.AddTransient<IConsultorios, ConsultoriosRepository>();

            return services;
        }
    }
}