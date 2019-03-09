using NCrontab;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskScheduler.Domain.Interfaces;
using TaskScheduler.Domain.Models;

namespace TaskScheduler.Manager
{
    class ScheduledTask<T> : IEntityId, IComparable<ScheduledTask<T>> where T : IEntityId, IEntityCron
    {
        private T Entity { get; set; }
        private Func<T, Task> TaskFactory { get; set; }
        private readonly CrontabSchedule cronParsed;

        public ScheduledTask(T entity, Func<T, Task> taskFactory)
        {
            Id = entity.Id;
            Entity = entity;
            TaskFactory = taskFactory;
            cronParsed = CrontabSchedule.Parse(Entity.Cron);
            SetNextOccurance();
        }
        
        public string Id { get; set; }

        public DateTime NextOccurance { get; private set; }
        
        public int CompareTo(ScheduledTask<T> other) => NextOccurance.CompareTo(other.NextOccurance);

        public async Task Process()
        {
            await TaskFactory(Entity);
            SetNextOccurance();
        }

        private void SetNextOccurance()
        {            
            NextOccurance = cronParsed.GetNextOccurrence(DateTime.Now);
        }
    }
}
