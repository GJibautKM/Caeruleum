using Caeruleum.Model;
using Caeruleum.Model.Service;
using Microsoft.Extensions.Logging;

namespace Caeruleum.InMemoryDb.Service;

internal class PlantService(
    ILogger<PlantService> logger
) : IPlantService
{
    public IAsyncEnumerable<Plant> GetAllAsync()
    {
        logger.LogDebug("{methodName}()", nameof(GetAllAsync));
        
        IEnumerable<Plant> plants = InMemoryPlants.Plants;
        return plants.ToAsyncEnumerable();
    }

    public ValueTask<Plant?> GetByIdAsync(int plantId)
    {
        Plant? plant = InMemoryPlants.GetById(plantId);

        logger.LogDebug("{methodName}({plantId}) => {plant}", nameof(GetByIdAsync), plantId, plant);

        return ValueTask.FromResult(plant);
    }
}
