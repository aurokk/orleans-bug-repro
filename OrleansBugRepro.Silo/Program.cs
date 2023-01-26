using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

const string invariant = "MySql.Data.MySqlConnector";

using var host = new HostBuilder()
    .UseOrleans(
        builder => builder
            .ConfigureEndpoints(
                siloPort: int.Parse(Environment.GetEnvironmentVariable("SILO_PORT") ?? "0"),
                gatewayPort: int.Parse(Environment.GetEnvironmentVariable("GATE_PORT") ?? "0")
            )
            .UseAdoNetClustering(
                options =>
                {
                    options.ConnectionString = "Server=127.0.0.1;Port=30005;Database=pay;Uid=pay_user;Pwd=pay_password;";
                    options.Invariant = invariant;
                }
            )
            .ConfigureLogging(x => x.AddJsonConsole())
    )
    .Build();

await host.RunAsync();