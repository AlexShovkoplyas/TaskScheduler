using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using TaskScheduler.Domain.Models;
using TaskScheduler.Domain;
using TaskScheduler.Domain.Interfaces;

namespace TaskScheduler.DAL
{
    public class Repository<T> : IRepository<T>
    {
        private const string EndpointUri = "https://taskscheduler2019.documents.azure.com:443/";
        private const string PrimaryKey = "HCoKWMtwjdBvWMapCLO5qvmd8cGMHJ1OceT06bUEWAss1USnOGL4VP5SrhMe71e5EirgZ2ULWsVnuPOEcbWRYA==";
        private const string DatabaseId = "TaskScheduler";
        private const string CollectionId = "Tasks";
        private DocumentClient client;

        public TestDbAccess()
        {
            client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Method()
        {
            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = DatabaseId });

            await client.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(DatabaseId), 
                new DocumentCollection { Id = CollectionId });

            var task = new WebPingTask
            {
                Id = "3",
                Cron = "* * * * 1",
                TaskType = TaskType.WebPing,
                TaskOptions = new WebPingOptions
                {
                    Url = "yahoo.com"
                }
            };

            var taskString = JsonConvert.SerializeObject(task);

            await CreateTaskDocumentIfNotExists(DatabaseId, CollectionId, task);

            

        }

        public bool Remove(string id)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        private async Task CreateTaskDocumentIfNotExists(string databaseName, string collectionName, WebPingTask task)
        {
            try
            {
                await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, task.Id));
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), task);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
