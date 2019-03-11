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
using System.Net;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace TaskScheduler.Tasks.SaveWebPage
{
    public class Functions
    {
        private const int TIMEOUT = 1024;

        public Functions(IDocumentRepository<SavePageTriggeredTask> repository, IConverter converter)
        {
            this.repository = repository;
            this.converter = converter;
        }

        private readonly IDocumentRepository<SavePageTriggeredTask> repository;
        private readonly IConverter converter;

        public async Task ProcessQueueMessage(
            [QueueTrigger("task-savewebpage")] SavePageTask task,
            [Blob("savedPages/{Id}_{datetime:yyyy-mm-dd}", FileAccess.Write)] Stream outputBlob,
            string Id, DateTime datetime,
            ILogger logger)
        {
            string targetHost = task.TaskOptions.Url;

            switch (task.TaskOptions.HowToSave)
            {
                case SaveOption.ToPdf:
                    //TODO:
                    throw new NotImplementedException();

                case SaveOption.ToHtml:
                    await SaveToHtml(outputBlob, targetHost);
                    break;
            }

            var log = new SavePageTriggeredTask
            {
                Id = task.Id,
                TaskType = TaskType.SavePage,
                TriggeredOn = DateTime.UtcNow,
                BlobPath = $"savedPages/{Id}_{datetime:yyyy-mm-dd}"
            };

            await repository.Add(log);
        }

        private static async Task SaveToHtml(Stream outputBlob, string targetHost)
        {
            using (WebClient client = new WebClient())
            {
                var blobData = await client.DownloadDataTaskAsync(targetHost);
                await outputBlob.WriteAsync(blobData, 0, blobData.Length);
            }
        }
    }
}
