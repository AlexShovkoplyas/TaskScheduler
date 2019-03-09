using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TaskScheduler.Domain.Interfaces;

namespace TaskScheduler.Domain.Models
{
    public abstract class BaseTask : IEntityId, IEntityCron //IComparable<BaseTask>
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string Cron { get; set; }

        public TaskType TaskType { get; set; }

        //public int CompareTo(BaseTask other)
        //{
        //    if (Id == other.Id &&
        //        Cron == other.Cron &&
        //        TaskType == other.TaskType)
        //    {
        //        return 0;
        //    }
        //    else
        //    {

        //    }                
        //}
    }
}
