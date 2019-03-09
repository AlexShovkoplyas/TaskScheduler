using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Logging;
using TaskScheduler.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace TaskScheduler.Tasks.SaveWebPage
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
            builder.ConfigureServices((hostContext, s) =>
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
