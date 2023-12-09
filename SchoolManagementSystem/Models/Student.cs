using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolManagementSystem.Models
{
    public class Student
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public String? Id { get; set; }
        public string IdStudent { get; set; } = null!;
        [BsonElement("Name")]
        public string StudentName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
