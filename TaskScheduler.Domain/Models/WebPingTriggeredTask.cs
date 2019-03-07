using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TaskScheduler.Domain.Interfaces;

namespace TaskScheduler.Domain.Models
{
    public abstract class WebPingTriggeredTask : BaseTriggeredTask
    {
        public WebPingTaskResult TaskResult { get; set; }
    }
}
