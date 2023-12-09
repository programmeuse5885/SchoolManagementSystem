using SchoolManagementSystem.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace SchoolManagementSystem.Services
{
    public class AssessmentsService
    {
        private readonly IMongoCollection<Assessment> _assessmentCollection;

        public AssessmentsService(IOptions<SchoolManagementSystemDatabaseSettings> schoolManagementSystemDatabaseSettings)
        {
            var mongoClient = new MongoClient(schoolManagementSystemDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(schoolManagementSystemDatabaseSettings.Value.DatabaseName);
            _assessmentCollection = mongoDatabase.GetCollection<Assessment>(schoolManagementSystemDatabaseSettings.Value.AssessmentColletionName);

        }

        //Busca todas las calificaciones
        public async Task<List<Assessment>> GetAsync() =>
            await _assessmentCollection.Find(_ => true).ToListAsync();

        //Busca calificaciones por id
        public async Task<Assessment?> GetAsync(string id) =>
            await _assessmentCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        //Inserta calificacion
        public async Task CreateAsync(Assessment newAssessment) =>
            await _assessmentCollection.InsertOneAsync(newAssessment);

        //Actualiza calificacion
        public async Task UpdateAsync(string id, Assessment updateAssessment) =>
            await _assessmentCollection.ReplaceOneAsync(x => x.Id == id, updateAssessment);

        //Elimina calificacion
        public async Task RemoveAsync(string id) =>
            await _assessmentCollection.DeleteOneAsync(x => x.Id == id);
    }
}
