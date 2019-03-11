using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TaskScheduler.Domain.Interfaces;

namespace TaskScheduler.Domain.Models
{
    public class SavePageTriggeredTask : BaseTriggeredTask
    {
        public string BlobPath { get; set; }
        //public WebPingTaskResult TaskResult { get; set; }
    }
}
