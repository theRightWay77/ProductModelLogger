using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ProductModel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Инициализация Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console() // или любой другой желаемый вывод
                .CreateLogger();

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.CloseAndFlush(); // Важно закрыть и сбросить логгер после завершения работы приложения
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders(); // Очистите существующие провайдеры журналирования
                    logging.AddSerilog(); // Добавьте Serilog как провайдера журналирования
                });
    }
}
