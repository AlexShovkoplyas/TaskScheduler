using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TaskScheduler.Domain.Interfaces;

namespace TaskScheduler.Domain.Models
{
    public abstract class TaskEntity : IEntityId, IEntityCron
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string Cron { get; set; }

        public TaskType TaskType { get; set; }
    }
}
