using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TaskScheduler.Domain.Interfaces;

namespace TaskScheduler.Domain.Models
{
    public class WebPingTask : TaskEntity
    {
        public WebPingOptions TaskOptions { get; set; }
    }
}
