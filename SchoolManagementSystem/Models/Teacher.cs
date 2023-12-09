using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolManagementSystem.Models
{
    public class Teacher
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public String? Id { get; set; }
        public string IdTeacher { get; set; } = null!;
        [BsonElement("Name")]
        public string TeacherName { get; set; } = null!;
        [BsonElement("fk_IdSubject")]
        public string SubjectId { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
