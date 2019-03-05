using System;

namespace TaskScheduler.Domain.Dto
{
    public class CreateTaskDto
    {
        public CronDto Cron { get; set; }

        public TaskType TaskType { get; set; }

        public object TaskOptions { get; set; }
    }
}
