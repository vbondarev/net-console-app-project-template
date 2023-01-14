using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace HostedConsoleApplicationProjectTemplate;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        using var host =  CreateHostBuilder(args).Build();

        await host.RunAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host
            .CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, builder) =>
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                builder
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{environment}.json", true);
            })
            .ConfigureLogging((_, builder) =>
            {
                builder.AddSerilog();
            });
    }
}
