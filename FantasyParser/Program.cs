using YahooFantasyService;
using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

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

            return services;
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }


        public (double, double) CalculateExpectedResult(int leftRating, int rightRating)
        {
            var leftExpected = 1 / (1 + Math.Pow(10, ((rightRating - leftRating) / 400)));
            var rightExpected = 1 - leftExpected;
            return (leftExpected, rightExpected);
        }

        public (int, int) CalculateEloChange(double leftExpected, double rightExpected, double leftScore, double rightScore)
        {
            var lWin = leftScore > rightScore;
            var rWin = !lWin;

            var leftChange = Convert.ToInt32(32 * ((lWin ? 1 : 0) - leftExpected));

            var rightChange = Convert.ToInt32(32 * ((rWin ? 1 : 0) - rightExpected));

            return (leftChange, rightChange);
        }

        public (int, int) CalculateEloChangeAdjusted(double leftExpected, double rightExpected, double leftScore, double rightScore, double leftProjected, double rightProjected)
        {
            var lWin = leftScore > rightScore;
            var rWin = !lWin;

            var leftMarginMod = Math.Tanh((leftScore - rightScore - 10) / 30) * 5;
            var leftProjectedMod = Math.Tanh((leftScore - leftProjected) / 30) * 5;
            var leftChange = Convert.ToInt32((32 + leftMarginMod) * ((lWin ? 1 : 0) - leftExpected) + leftProjectedMod);

            var rightMarginMod = Math.Tanh((rightScore - leftScore) / 30) * 5;
            var rightProjectedMod = Math.Tanh((rightScore - rightProjected) / 30) * 5;
            var rightChange = Convert.ToInt32((32 + rightMarginMod) * ((rWin ? 1 : 0) - rightExpected) + rightProjectedMod);

            return (leftChange, rightChange);
        }
    }
}
