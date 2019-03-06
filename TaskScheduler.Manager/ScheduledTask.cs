using NCrontab;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskScheduler.Domain.Interfaces;
using TaskScheduler.Domain.Models;

namespace TaskScheduler.Manager
{
    class ScheduledTask<T> : IComparable<ScheduledTask<T>> where T : IEntityCron
    {
        public ScheduledTask(T entity, Func<T, Task> taskFactory)
        {
            Entity = entity;
            TaskFactory = taskFactory;
            SetNextOccurance();
        }

        private T Entity { get; set; }
        private Func<T, Task> TaskFactory { get; set; }

        public DateTime NextOccurance { get; private set; }
        
        public int CompareTo(ScheduledTask<T> other) => NextOccurance.CompareTo(other.NextOccurance);

        public async Task Process()
        {
            await TaskFactory(Entity);
            SetNextOccurance();
        }

        private void SetNextOccurance()
        {
            var schedule = CrontabSchedule.Parse(Entity.Cron);
            NextOccurance = schedule.GetNextOccurrence(DateTime.Now);
        }
    }
}
