using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;

namespace TaskScheduler.Tasks.WebPingCore
{
    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("task_webping")] CloudQueueMessage message, ILogger logger)
        {
            //logger.LogInformation(message);
            //TODO
        }
    }
}
