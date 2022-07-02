using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseSentry(Environment.GetEnvironmentVariable("SENTRY_DSN"));
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSentry(o =>
                    {
                        // Tells which project in Sentry to send events to:
                        o.Dsn = "https://987c249968934b9e83bbec9f469e9163@o1304826.ingest.sentry.io/6545579";
                        // When configuring for the first time, to see what the SDK is doing:
                        o.Debug = true;
                        // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
                        // We recommend adjusting this value in production.
                        o.TracesSampleRate = 1.0;
                    });
                });
    }
}
