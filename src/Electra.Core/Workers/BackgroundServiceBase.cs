using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Electra.Core.Workers;

public abstract class BackgroundServiceBase(
    IServiceProvider sp,
    ILogger<BackgroundServiceBase> log,
    IConfiguration config)
    : BackgroundService
{

    protected abstract override Task ExecuteAsync(CancellationToken stoppingToken);
}