namespace Caeruleum.Model.Service;

public interface IPlantService
{
    IAsyncEnumerable<Plant> GetAllAsync();
    ValueTask<Plant?> GetByIdAsync(int plantId);
}
