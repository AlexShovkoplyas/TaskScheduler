using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskScheduler.Domain.Interfaces;
using TaskScheduler.Domain.Models;

namespace TaskScheduler.Api.Services
{
    public class TaskManagerService<T> : IHostedService
    {
        public TaskManagerService(IServiceProvider services)
        {
            manager = services.GetService<IManager<T>>();
        }

        private readonly IManager<T> manager;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return manager.StartAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
