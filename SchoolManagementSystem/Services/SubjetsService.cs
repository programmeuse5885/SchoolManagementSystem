using SchoolManagementSystem.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SchoolManagementSystem.Services
{
    public class SubjetsService
    {
        private readonly IMongoCollection<Subject> _subjectsCollection;

        public SubjetsService(IOptions<SchoolManagementSystemDatabaseSettings> schoolManagementSystemDatabaseSettings)
        {
            var mongoClient = new MongoClient(schoolManagementSystemDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(schoolManagementSystemDatabaseSettings.Value.DatabaseName);
            _subjectsCollection = mongoDatabase.GetCollection<Subject>(schoolManagementSystemDatabaseSettings.Value.SubjetColletionName);

        }

        //Busca todas las materias
        public async Task<List<Subject>> GetAsync() =>
            await _subjectsCollection.Find(_ => true).ToListAsync();

        //Busca materia por id
        public async Task<Subject?> GetAsync(string id) =>
            await _subjectsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        //Inserta materia
        public async Task CreateAsync(Subject newSubject) =>
            await _subjectsCollection.InsertOneAsync(newSubject);

        //Actualiza materia
        public async Task UpdateAsync(string id, Subject updateSubject) =>
            await _subjectsCollection.ReplaceOneAsync(x => x.Id == id, updateSubject);

        //Elimina materia
        public async Task RemoveAsync(string id) =>
            await _subjectsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
