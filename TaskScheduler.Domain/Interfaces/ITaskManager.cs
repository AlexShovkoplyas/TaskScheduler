using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler.Domain.Interfaces
{
    public interface ITaskManager<T>
    {
        void Add(T task, Func<T, Task> taskFactory);
        void Remove(string taskId);
        Task StartAsync();
    }
}
