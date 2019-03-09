using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;
using TaskScheduler.DAL;
using TaskScheduler.Domain;
using TaskScheduler.Domain.Interfaces;
using TaskScheduler.Domain.Models;
using TaskScheduler.Infrustructure;

namespace TaskScheduler.Tasks.WebPing
{
    public class Functions
    {
        private const int TIMEOUT = 1024;

        private static IDocumentRepository<WebPingTriggeredTask> repository;

        public static async Task ProcessQueueMessage([QueueTrigger("task-webping")] CloudQueueMessage message, ILogger logger)
        {
            var task = message.AsString.Deserialize<WebPingTask>();

            string targetHost = task.TaskOptions.Url;
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(targetHost, TIMEOUT);

            var log = new WebPingTriggeredTask
            {
                Id = task.Id,
                TaskType = TaskType.WebPing,
                TriggeredOn = DateTime.UtcNow,
                TaskResult = reply.Status == IPStatus.Success ? WebPingTaskResult.Ok : WebPingTaskResult.Error
            };

            repository = await DocumentRepository<WebPingTriggeredTask>.CreateAsync();
            await repository.Add(log);
        }

        //public static void ProcessQueueMessage2(
        //    [QueueTrigger("task-webping")] string message,
        //    [Blob("container/{queueTrigger}", FileAccess.Read)] Stream myBlob,
        //    ILogger logger)
        //{
        //    logger.LogInformation($"Blob name:{message} \n Size: {myBlob.Length} bytes");
        //}

        //public static void ProcessQueueMessage3(
        //    [QueueTrigger("task-webping")] string message,
        //    [Blob("container/{queueTrigger2}", FileAccess.Read)] Stream myBlob,
        //    [Blob("container/copy-{queueTrigger}", FileAccess.Write)] Stream outputBlob,
        //    ILogger logger)
        //{
        //    logger.LogInformation($"Blob name:{message} \n Size: {myBlob.Length} bytes");
        //    myBlob.CopyTo(outputBlob);
        //}
    }
}
