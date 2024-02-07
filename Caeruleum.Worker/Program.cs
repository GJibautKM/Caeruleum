using Caeruleum.InMemoryDb.Extensions;
using Caeruleum.Worker;
using Serilog;
using Serilog.Events;

string logTemplate = "{Timestamp:HH:mm:ss}|{Level:u4}|{SourceContext}|{Message:lj}{NewLine}{Exception}";

var builder = Host.CreateApplicationBuilder(args);
IServiceCollection services = builder.Services;
services.AddSerilog(loggerCfg =>
{
    loggerCfg.WriteTo.Console(outputTemplate: logTemplate);
    loggerCfg.MinimumLevel.Is(LogEventLevel.Debug);
    loggerCfg.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
    loggerCfg.MinimumLevel.Override("System", LogEventLevel.Warning);
    loggerCfg.MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information);
});
services.AddCaeruleumInMemoryDb();
services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
