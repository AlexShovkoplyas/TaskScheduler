using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;

namespace TaskScheduler.Tasks.WebPingCore
{
    public class Functions
    {
        //public static void ProcessQueueMessage([QueueTrigger("task-webping")] CloudQueueMessage message, ILogger logger)
        //{
        //    //logger.LogInformation(message);
        //    //TODO
        //}

        //public static void ProcessQueueMessage2(
        //    [QueueTrigger("task-webping")] string message,
        //    [Blob("container/{queueTrigger}", FileAccess.Read)] Stream myBlob,
        //    ILogger logger)
        //{
        //    logger.LogInformation($"Blob name:{message} \n Size: {myBlob.Length} bytes");
        //}

        public static void ProcessQueueMessage3(
            [QueueTrigger("task-webping")] string message,
            [Blob("container/{queueTrigger}", FileAccess.Read)] Stream myBlob,
            [Blob("container/copy-{queueTrigger}", FileAccess.Write)] Stream outputBlob,
            ILogger logger)
        {
            logger.LogInformation($"Blob name:{message} \n Size: {myBlob.Length} bytes");
            myBlob.CopyTo(outputBlob);
        }
    }
}
