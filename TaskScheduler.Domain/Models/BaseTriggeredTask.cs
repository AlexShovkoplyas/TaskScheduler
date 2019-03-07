using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TaskScheduler.Domain.Interfaces;

namespace TaskScheduler.Domain.Models
{
    public abstract class BaseTriggeredTask : IEntityId
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public DateTime TriggeredOn { get; set; }

        public TaskType TaskType { get; set; }
    }
}
