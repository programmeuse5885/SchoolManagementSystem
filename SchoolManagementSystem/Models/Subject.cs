using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolManagementSystem.Models
{
    public class Subject
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public String? Id { get; set; }
        public string IdSubject { get; set; } = null!;
        [BsonElement("Name")]
        public string SubjectName { get; set; } = null!;
        public int Grade { get; set; }
    }
}
