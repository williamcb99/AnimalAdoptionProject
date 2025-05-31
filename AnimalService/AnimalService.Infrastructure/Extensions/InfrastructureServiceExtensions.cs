using AnimalService.Application.Interfaces;
using AnimalService.Infrastructure.Persistence;
using AnimalService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace AnimalService.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AnimalDbContext>(options => options.UseInMemoryDatabase("AnimalDb"));

            services.AddScoped<IAnimalRepository, AnimalRepository>();

            return services;
        }
    }
}
