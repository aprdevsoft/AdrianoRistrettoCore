using AdrianoRistrettoCore.Models;
using AdrianoRistrettoCore.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AdrianoRistrettoCore.Services
{
    public class ContratoService
    {
        private readonly IMongoCollection<Contrato> _collection;

        public ContratoService(
            IOptions<DataBaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Contrato>(
                databaseSettings.Value.ContratosCollectionName);
        }

        public async Task<List<Contrato>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Contrato?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Contrato contrato) =>
            await _collection.InsertOneAsync(contrato);

        public async Task UpdateAsync(string id, Contrato contrato) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, contrato);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
