using SchoolManagementSystem.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SchoolManagementSystem.Services
{
    public class StudentsService
    {
        private readonly IMongoCollection<Student> _studentsCollection;

        public StudentsService(IOptions<SchoolManagementSystemDatabaseSettings> schoolManagementSystemDatabaseSettings)
        {
            var mongoClient = new MongoClient(schoolManagementSystemDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(schoolManagementSystemDatabaseSettings.Value.DatabaseName);
            _studentsCollection = mongoDatabase.GetCollection<Student>(schoolManagementSystemDatabaseSettings.Value.StudentColletionName);

        }

        //Busca todas los estudiantes
        public async Task<List<Student>> GetAsync() =>
            await _studentsCollection.Find(_ => true).ToListAsync();

        //Busca estudiante por id
        public async Task<Student?> GetAsync(string id) =>
            await _studentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        //Inserta estudiante
        public async Task CreateAsync(Student newStudent) =>
            await _studentsCollection.InsertOneAsync(newStudent);

        //Actualiza estudiante
        public async Task UpdateAsync(string id, Student updateStudent) =>
            await _studentsCollection.ReplaceOneAsync(x => x.Id == id, updateStudent);

        //Elimina estudiante
        public async Task RemoveAsync(string id) =>
            await _studentsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
