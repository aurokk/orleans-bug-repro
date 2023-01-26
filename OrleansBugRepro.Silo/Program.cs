using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using var host = new HostBuilder()
    .UseOrleans(
        builder => builder
            .ConfigureEndpoints(
                siloPort: int.Parse(Environment.GetEnvironmentVariable("SILO_PORT") ?? "0"),
                gatewayPort: int.Parse(Environment.GetEnvironmentVariable("GATE_PORT") ?? "0")
            )
            .UseLocalhostClustering()
            .ConfigureLogging(x => x.AddJsonConsole())
    )
    .Build();

await host.RunAsync();