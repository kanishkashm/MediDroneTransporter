using MDT.Core.Interfaces;
using MDT.Infrastructure.Persistence;
using MDT.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MDT.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<MdtContext>(opt => opt.UseInMemoryDatabase(databaseName: "MediDroneTrnsDb"));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IDroneRepository, DroneRepository>();
            services.AddScoped<IMedicationRepository, MedicationRepository>();
            services.AddScoped<IDeliveryDetailsRepository, DeliveryDetailsRepository>();

            return services;
        }
    }
}
