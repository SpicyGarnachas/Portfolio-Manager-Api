using SpicyGarnachas.InvestmentApi;
using SpicyGarnachas.InvestmentApi.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;

namespace SpicyGarnachas.InvestmentApi;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
}
