using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetValue<string>("DatbaseSettings:ConnectionString"));
            var database = client.GetDatabase(config.GetValue<string>("DatbaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(config.GetValue<string>("DatbaseSettings:CollectionName"));

            CatalogContextSeed.SeedData(Products);
                
        } 

        public IMongoCollection<Product> Products { get; }


    }
}
