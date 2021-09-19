using Catalog.API.Entities;
using Catalog.API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public CatalogContext(IOptions<DatabaseSettings> dbOptions)
        {
            var databaseSettings = dbOptions.Value;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            Products = database.GetCollection<Product>(databaseSettings.CollectionName);
            CatalogContextSeed.seedData(Products);
        }
    }
}