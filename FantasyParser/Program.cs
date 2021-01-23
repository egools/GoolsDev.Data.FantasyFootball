using YahooFantasyService;
using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FantasyComponents;
using Microsoft.EntityFrameworkCore;
using FantasyComponents.DAL;

namespace FantasyParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<App>().Run();
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
}
