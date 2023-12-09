using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolManagementSystem.Models
{
    public class Assessment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public String? Id { get; set; }
        public string IdAssessment { get; set; } = null!;
        [BsonElement("fk_IdSubject")]
        public string SubjectId { get; set; } = null!;
        [BsonElement("fk_IdStudent")]
        public string StudentId { get; set; } = null!;
        public int Note { get; set; }

    }
}
