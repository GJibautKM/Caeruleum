
namespace Caeruleum.Worker;

public class SideWorker(
    ILogger<SideWorker> logger,
    IConfiguration configuration
) : BackgroundService
{
    private readonly TimeSpan _delay = TimeSpan.FromMinutes(1);
    private readonly string _message = configuration["Message"] ?? $"Default message from {nameof(SideWorker)}";
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(1000, stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Message : `{message}`", _message);

            await Task.Delay(_delay, stoppingToken);
        }
    }
}
