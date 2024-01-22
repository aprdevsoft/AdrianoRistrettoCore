using AdrianoRistrettoCore.Models;
using AdrianoRistrettoCore.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AdrianoRistrettoCore.Services
{
    public class FuncionarioService
    {
        private readonly IMongoCollection<Funcionario> _collection;

        public FuncionarioService(
            IOptions<DataBaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Funcionario>(
                databaseSettings.Value.FuncionariosCollectionName);
        }

        public async Task<List<Funcionario>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Funcionario?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Funcionario funcionario) =>
            await _collection.InsertOneAsync(funcionario);

        public async Task UpdateAsync(string id, Funcionario empresa) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, empresa);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
