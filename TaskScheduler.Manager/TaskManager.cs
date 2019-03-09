using NCrontab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskScheduler.Domain.Interfaces;
using TaskScheduler.Domain.Models;

namespace TaskScheduler.Manager
{
    public class TaskManager<T> : ITaskManager<T> where T: IEntityId, IEntityCron
    {
        private const int IntervalInMilliseconds = 500;
        List<ScheduledTask<T>> Tasks;

        readonly MinHeap<ScheduledTask<T>> tasksQueue;

        public TaskManager()
        {
            tasksQueue = new MinHeap<ScheduledTask<T>>(30);
        }

        public TaskManager(IEnumerable<T> tasks, Func<T, Task> taskFactory)
        {
            tasksQueue = new MinHeap<ScheduledTask<T>>(tasks.Select(t => new ScheduledTask<T>(t, taskFactory)));
        }

        public void Add(T task, Func<T, Task> taskFactory)
        {
            var managedTask = new ScheduledTask<T>(task, taskFactory);
            tasksQueue.Add(managedTask);
        }

        public void Remove(string taskId)
        {
            //TODO: it looks that easier to change minheap on sortedset
            throw new NotImplementedException();
        }

        public async Task StartAsync()
        {
            while (true)
            {
                if (tasksQueue.Peek().NextOccurance >= DateTime.Now)
                {
                    var task = tasksQueue.Pop();
                    await task.Process();
                    tasksQueue.Add(task);
                    await Task.Delay(TimeSpan.FromMilliseconds(IntervalInMilliseconds));
                }
            }
        }
    }
}
