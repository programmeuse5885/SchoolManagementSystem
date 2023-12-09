using SchoolManagementSystem.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SchoolManagementSystem.Services
{
    public class TeachersService
    {
        private readonly IMongoCollection<Teacher> _teachersCollection;

        public TeachersService(IOptions<SchoolManagementSystemDatabaseSettings> schoolManagementSystemDatabaseSettings)
        {
            var mongoClient = new MongoClient(schoolManagementSystemDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(schoolManagementSystemDatabaseSettings.Value.DatabaseName);
            _teachersCollection = mongoDatabase.GetCollection<Teacher>(schoolManagementSystemDatabaseSettings.Value.TeacherColletionName);

        }

        //Busca todas los maestros
        public async Task<List<Teacher>> GetAsync() =>
            await _teachersCollection.Find(_ => true).ToListAsync();

        //Busca maestro por id
        public async Task<Teacher?> GetAsync(string id) =>
            await _teachersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        //Inserta maestro
        public async Task CreateAsync(Teacher newTeacher) =>
            await _teachersCollection.InsertOneAsync(newTeacher);

        //Actualiza maestro
        public async Task UpdateAsync(string id, Teacher updateTeacher) =>
            await _teachersCollection.ReplaceOneAsync(x => x.Id == id, updateTeacher);

        //Elimina maestro
        public async Task RemoveAsync(string id) =>
            await _teachersCollection.DeleteOneAsync(x => x.Id == id);

    }
}
