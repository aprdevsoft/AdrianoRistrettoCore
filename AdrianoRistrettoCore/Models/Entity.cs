using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AdrianoRistrettoCore.Models
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
