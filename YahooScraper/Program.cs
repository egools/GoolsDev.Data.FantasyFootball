using YahooFantasyService;
using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FantasyDAO;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FantasyParser;
public class Program
{
    public static async Task Main(string[] args)
    {
        var services = ConfigureServices();
        var serviceProvider = services.BuildServiceProvider();
        await serviceProvider.GetService<App>().Run();
    }

    private static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        var config = LoadConfiguration();
        services.AddSingleton(config);
        services.Configure<YahooServiceSettings>(config.GetSection("YahooServiceSettings"));

        services.AddTransient<App>();
        services.AddTransient<YahooService>();

        services.AddTransient<FantasyFootballUnitOfWork>();
        services.AddDbContext<FantasyFootballContext>(options => options.UseSqlServer(config.GetConnectionString("GoolsDevSqlConnection")));

        return services;
    }

    public static IConfiguration LoadConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        return builder.Build();
    }
}
