using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Logging;
using TaskScheduler.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using DinkToPdf.Contracts;
using DinkToPdf;

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
                s.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
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
