using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Threading.Tasks;
using TaskScheduler.Domain.Interfaces;

namespace TaskScheduler.QueueProcessor
{
    public class Dispatcher<T> : IQueueWriter<T>, IQueueReader
    {
        CloudStorageAccount storageAccount;
        CloudQueueClient queueClient;
        CloudQueue queue;  

        public static async Task<Dispatcher<T>> CreateAsync()
        {
            var dispatcher = new Dispatcher<T>();
            return await dispatcher.InitializeAsync();
        }

        public async Task<string> Read()
        {
            CloudQueueMessage retrievedMessage = await queue.GetMessageAsync();
            await queue.DeleteMessageAsync(retrievedMessage);
            return retrievedMessage.AsString;
        }

        public async Task Send(T entity)
        {
            var message = new CloudQueueMessage(entity.ToString());
            await queue.AddMessageAsync(message);
        }

        private Dispatcher() { }

        private async Task<Dispatcher<T>> InitializeAsync()
        {
            queueClient = storageAccount.CreateCloudQueueClient();
            queue = queueClient.GetQueueReference("task_webping");
            await queue.CreateIfNotExistsAsync();

            return this;
        }
    }
}
