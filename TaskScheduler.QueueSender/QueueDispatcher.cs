using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Threading.Tasks;
using TaskScheduler.Domain.Interfaces;

namespace TaskScheduler.QueueProcessor
{
    public class QueueDispatcher<T> : IQueueWriter<T>, IQueueReader<T>
    {
        CloudStorageAccount storageAccount;
        CloudQueueClient queueClient;
        CloudQueue queue;  

        public static async Task<QueueDispatcher<T>> CreateAsync()
        {
            var dispatcher = new QueueDispatcher<T>();
            return await dispatcher.InitializeAsync();
        }

        public async Task<T> Read()
        {
            CloudQueueMessage retrievedMessage = await queue.GetMessageAsync();
            await queue.DeleteMessageAsync(retrievedMessage);
            return retrievedMessage.AsString.Deserialize<T>();
        }

        public async Task Send(T entity)
        {
            var message = new CloudQueueMessage(entity.Serialize());
            await queue.AddMessageAsync(message);
        }

        private QueueDispatcher() { }

        private async Task<QueueDispatcher<T>> InitializeAsync()
        {
            queueClient = storageAccount.CreateCloudQueueClient();
            queue = queueClient.GetQueueReference("task_webping");
            await queue.CreateIfNotExistsAsync();

            return this;
        }
    }
}
