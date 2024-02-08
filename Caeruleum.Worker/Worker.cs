using Caeruleum.Model;
using Caeruleum.Model.Service;

namespace Caeruleum.Worker;

public class Worker(
    ILogger<Worker> logger,
    IPlantService plantService
) : BackgroundService
{
    private Task Idle(CancellationToken stoppingToken)
    {
        int minutes = Random.Shared.Next(2, 10);
        TimeSpan delay = TimeSpan.FromMinutes(minutes);
        logger.LogInformation("Sleeping for {minutes} minutes", minutes);
        return Task.Delay(delay, stoppingToken);
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(1000, stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            int plantId = Random.Shared.Next(10);
            logger.LogInformation("Searching for Plant with Id={plantId}", plantId);

            if (await plantService.GetByIdAsync(plantId) is Plant plant)
            {
                logger.LogInformation("Found : {plant}", plant);
            }
            else
            {
                logger.LogWarning("No Plant with Id={plantId}", plantId);
            }
            
            await Idle(stoppingToken);
        }
    }
}
