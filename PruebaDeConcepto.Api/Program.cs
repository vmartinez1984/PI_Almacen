using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;

namespace PruebaDeConcepto.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            CreateWebHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>()
              .ConfigureAppConfiguration((builderContext, config) =>
              {
                  config.AddJsonFile("serilog-config.json");
              })
              .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                  .ReadFrom.Configuration(hostingContext.Configuration)
              );

            Serilog.Debugging.SelfLog.Enable(msg => File.AppendAllText("milog.txt", msg));

            return builder;
        }
    }
}
