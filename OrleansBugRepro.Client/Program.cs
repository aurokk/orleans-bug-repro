using Dodo.Tools.Types;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrleansBugRepro.Interfaces;

var host = new HostBuilder()
    .UseOrleansClient(builder => builder.UseLocalhostClustering())
    .Build();

await host.StartAsync();

for (var i = 0; i < 100_000; i++)
{
    var client = host.Services.GetRequiredService<IClusterClient>();
    var grain = client.GetGrain<ITestGrain>(i.ToString());

    var token = UUId.NewUUId().ToString();
    var response = await grain.GetTestType0();

    if (response.SomeString == null) throw new ApplicationException("SomeString is null");
}