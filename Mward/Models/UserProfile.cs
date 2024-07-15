using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mward.Models
{
    public class UserProfile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
