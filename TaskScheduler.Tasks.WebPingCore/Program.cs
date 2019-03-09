using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Logging;
using TaskScheduler.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using TaskScheduler.QueueProcessor;

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
            builder.ConfigureServices((hostContext, s) =>
            {
                s.AddScoped<IQueueWriter<object>, QueueDispatcher<object>>();
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
