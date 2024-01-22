using AdrianoRistrettoCore.Models;
using AdrianoRistrettoCore.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AdrianoRistrettoCore.Services
{
    public class EmpresaService
    {
        private readonly IMongoCollection<Empresa> _collection;

        public EmpresaService(
            IOptions<DataBaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Empresa>(
                databaseSettings.Value.EmpresasCollectionName);
        }

        public async Task<List<Empresa>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Empresa?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Empresa empresa) =>
            await _collection.InsertOneAsync(empresa);

        public async Task UpdateAsync(string id, Empresa empresa) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, empresa);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
