using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Diagnostics;
using System.IO;

namespace MonitoringMachinesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(@"C:\temp\MonitoringMachinesLog\LogFile.txt")
                .CreateLogger();

            try
            {
                Log.Information("Starting up the service");
                CreateHostBuilder(args).Build().Run();
                Log.Information("return main");
                return;
            } 
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error. Cannot start the service");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static string GetBasePath()
        {
            Log.Information("GetBasePath");
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var isDevelopment = environment == Environments.Development;
            if (isDevelopment)
            {
                Log.Information("isDevelopment");
                return Directory.GetCurrentDirectory();
            }
            using var processModule = Process.GetCurrentProcess().MainModule;

            Log.Information("Dentro do GetBasePath" + Path.GetDirectoryName(processModule?.FileName));
            return Path.GetDirectoryName(processModule?.FileName);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    Log.Information("getbasepath VALUE" + GetBasePath());
                    config.SetBasePath(GetBasePath());
                    config.AddJsonFile("appsettings.json", optional: false);

                    //config.Sources.Clear();

                    //var env = hostingContext.HostingEnvironment;

                    //config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    //      .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                    //                     optional: true, reloadOnChange: true);

                    //config.AddEnvironmentVariables();

                    //if (args != null)
                    //{
                    //    config.AddCommandLine(args);
                    //}
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureWebHost(config =>
                {
                    config.UseUrls("http://*:5000");
                }).UseWindowsService();
    }
}
