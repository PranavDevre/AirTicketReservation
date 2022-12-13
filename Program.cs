using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AIR_RESERVATION_SYSTEM_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            #region Log4net
            //ILoggerRepository repository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            //var fileInfo = new FileInfo(@"log4net.config");
            //log4net.Config.XmlConfigurator.Configure(repository, fileInfo);
            //host.Run();
            #endregion
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
