using Caeruleum.InMemoryDb.Extensions;
using Serilog;
using Serilog.Events;

string logTemplate = "{Timestamp:HH:mm:ss}|{Level:u4}|{SourceContext}|{Message:lj}{NewLine}{Exception}";

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
services.AddSerilog(loggerCfg =>
{
    loggerCfg.WriteTo.Console(outputTemplate: logTemplate);
    loggerCfg.MinimumLevel.Is(LogEventLevel.Information);
    loggerCfg.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
    loggerCfg.MinimumLevel.Override("System", LogEventLevel.Warning);
    loggerCfg.MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information);
});
services.AddCaeruleumInMemoryDb();
services.AddControllers();
services.AddRazorPages();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();
app.Run();
