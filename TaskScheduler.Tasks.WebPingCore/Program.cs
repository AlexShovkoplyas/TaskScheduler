using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Logging;

namespace TaskScheduler.Tasks.WebPingCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();
            });
            builder.ConfigureLogging((context, b) =>
            {
                b.AddConsole();
            });
            builder.ConfigureServices((hostContext, services) =>
            {
                //TODO
            });
            var host = builder.Build();
            using (host)
            {
                host.Run();
            }
        }
    }
}
