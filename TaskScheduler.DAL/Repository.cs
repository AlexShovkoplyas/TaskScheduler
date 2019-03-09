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
using System.Collections.Generic;

namespace TaskScheduler.DAL
{
    public class Repository<T> : IRepository<T> where T : IEntityId
    {
        private const string EndpointUri = "https://taskscheduler2019.documents.azure.com:443/";
        private const string PrimaryKey = "HCoKWMtwjdBvWMapCLO5qvmd8cGMHJ1OceT06bUEWAss1USnOGL4VP5SrhMe71e5EirgZ2ULWsVnuPOEcbWRYA==";
        private const string DatabaseId = "TaskScheduler";
        private const string CollectionId = "Tasks";
        private DocumentClient client;

        private Uri documentCollectionUri;
        private Uri databaseUri;

        public static Task<Repository<T>> CreateAsync()
        {
            var repo = new Repository<T>();
            return repo.InitializeAsync();
        }

        public async Task<IQueryable<T>> List()
        {
            var collectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId);
            var collection = (await client.ReadDocumentCollectionAsync(collectionUri)).Resource;
            return client.CreateDocumentQuery<T>(collection.SelfLink).AsQueryable();
        }

        public async Task<T> Get(string id)
        {
            var documentUri = UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id);
            return await client.ReadDocumentAsync<T>(documentUri);
        }

        public async Task<T> Add(T entity)
        {
            await CreateDocumentIfNotExists(entity);
            return entity;
        }

        public async Task<bool> Remove(string id)
        {
            var documentUri = UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id);
            await client.DeleteDocumentAsync(documentUri);
            return true;
        }

        public async Task<T> Update(T entity)
        {
            var documentUri = UriFactory.CreateDocumentUri(DatabaseId, CollectionId, entity.Id);
            var response = await client.UpsertDocumentAsync(documentUri, entity);
            return entity;
        }

        private Repository() { }

        private async Task<Repository<T>> InitializeAsync()
        {
            client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);

            await CreateDatabase();
            await CreateCollection();

            databaseUri = UriFactory.CreateDatabaseUri(DatabaseId);
            documentCollectionUri = UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId);

            return this;
        }

        private async Task CreateDatabase()
        {
            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = DatabaseId });
        }

        private async Task CreateCollection()
        {
            await client.CreateDocumentCollectionIfNotExistsAsync(
                databaseUri,
                new DocumentCollection { Id = CollectionId });
        }

        private async Task CreateDocumentIfNotExists(T entity)
        {
            try
            {
                var documentUri = UriFactory.CreateDocumentUri(DatabaseId, CollectionId, entity.Id);
                await client.ReadDocumentAsync(documentUri);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentAsync(documentCollectionUri, entity);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
