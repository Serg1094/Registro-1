using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Repositories;

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

            services.AddTransient<IExpedientes, ExpedientesRepository>();
            services.AddTransient<IAtenciones, AtencionesRepository>();
            services.AddTransient<IDiagnosticos, DiagnosticosRepository>();
            services.AddTransient<ISignosVitales, SignosVitalesRepository>();

            return services;
        }
    }
}