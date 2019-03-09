using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Threading.Tasks;
using TaskScheduler.Domain.Interfaces;
using TaskScheduler.Infrustructure;

namespace TaskScheduler.QAL
{
    public class QueueRepository<T> : IQueueWriter<T>, IQueueReader<T>
    {
        CloudStorageAccount storageAccount;
        CloudQueueClient queueClient;
        CloudQueue queue;  

        public static async Task<QueueRepository<T>> CreateAsync()
        {
            var dispatcher = new QueueRepository<T>();
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

        private QueueRepository() { }

        private async Task<QueueRepository<T>> InitializeAsync()
        {
            queueClient = storageAccount.CreateCloudQueueClient();
            queue = queueClient.GetQueueReference("task_webping");
            await queue.CreateIfNotExistsAsync();

            return this;
        }
    }
}
