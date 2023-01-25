using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TDB.Ms.Producto.Infraestructura.Common;

namespace TDB.Ms.Producto.Infraestructura
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly List<Func<Task>> _commands;
        public IMongoClient Client { get; }

        public IMongoDatabase Database { get; }

        public MongoDbContext(IMongoDatabase mongoDatabase)
        { 
            _commands = new List<Func<Task>>();
            InitializeGuidRepresentation();
            Database = mongoDatabase;
            Client = Database.Client;
        }

        public MongoDbContext(string connectionString, string databaseName)
        {
            _commands = new List<Func<Task>>();
            InitializeGuidRepresentation();
            Client = new MongoClient(connectionString);
            Database = Client.GetDatabase(databaseName);
        }

        public MongoDbContext(string connectionString)
            : this(connectionString, new MongoUrl(connectionString).DatabaseName)
        {
            _commands = new List<Func<Task>>();
        }

        public MongoDbContext(MongoClient client, string databaseName)
        {
            _commands = new List<Func<Task>>();
            InitializeGuidRepresentation();
            Client = client;
            Database = client.GetDatabase(databaseName);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void DropCollection<TDocument>(string partitionKey = null)
        {
            Database.DropCollection(GetCollectionName<TDocument>(partitionKey));
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string partitionKey = null)
        {
            return Database.GetCollection<TDocument>(GetCollectionName<TDocument>(partitionKey));
        }

        public void SetGuidRepresentation(GuidRepresentation guidRepresentation)
        {
            MongoDefaults.GuidRepresentation = guidRepresentation;
        }

        protected virtual void InitializeGuidRepresentation()
        {
            MongoDefaults.GuidRepresentation = GuidRepresentation.Standard;
        }

        protected virtual string GetCollectionName<TDocument>(string partitionKey)
        {
            string text = GetAttributeCollectionName<TDocument>() ?? Pluralize<TDocument>();
            if (string.IsNullOrEmpty(partitionKey))
            {
                return text;
            }

            return partitionKey + "-" + text;
        }

        protected virtual string GetAttributeCollectionName<TDocument>()
        {
            return (typeof(TDocument).GetTypeInfo().GetCustomAttributes(typeof(CollectionNameAttribute)).FirstOrDefault() as CollectionNameAttribute)?.Name;
        }

        protected virtual string Pluralize<TDocument>()
        {
            return typeof(TDocument).Name.Pluralize().Camelize();
        }
    }
}
