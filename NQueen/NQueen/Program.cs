using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NQueen.Services;
using MicrosoftLog = Microsoft.Extensions.Logging;

internal class Program
{
    private static void Main(string[] args)
    {
        var logger = LogManager.GetCurrentClassLogger();

        try
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(MicrosoftLog.LogLevel.Information);
                    logging.AddNLog();
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<NQueenService>();
                })
                .Build();

            var nQueenService = host.Services.GetRequiredService<NQueenService>();

            nQueenService.Start();
        }
        catch (Exception ex)
        {
            logger.Error(ex);
            Console.WriteLine("錯誤發生請確認");
        }
    }
}