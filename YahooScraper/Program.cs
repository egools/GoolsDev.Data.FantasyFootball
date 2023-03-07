using FantasyRepo.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using YahooFantasyService;
using YahooScraper;

var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

await new ServiceCollection()
        .AddSingleton(config)
        .Configure<YahooServiceSettings>(config.GetSection("YahooServiceSettings"))
        .AddTransient<App>()
        .AddTransient<YahooService>()
        .AddTransient<FantasyFootballUnitOfWork>()
        .AddDbContext<FantasyFootballContext>(options => options.UseSqlServer(config.GetConnectionString("GoolsDevSqlConnection")))
    .BuildServiceProvider()
    .GetService<App>()
    .Run();
