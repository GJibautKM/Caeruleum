using Caeruleum.InMemoryDb.Service;
using Caeruleum.Model.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Caeruleum.InMemoryDb.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCaeruleumInMemoryDb(this IServiceCollection services)
    {
        services.TryAddSingleton<IPlantService, PlantService>();

        return services;
    }
}
