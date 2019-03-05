using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskScheduler.Domain.Models
{
    public class WebPingTask
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string Cron { get; set; }

        public TaskType TaskType { get; set; }

        public WebPingOptions TaskOptions { get; set; }
    }
}
