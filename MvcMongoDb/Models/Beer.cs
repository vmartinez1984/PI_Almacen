using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MvcMongoDb.Models
{
    public class Beer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("name")]
        public string Alcohol { get; set; }
    }
}
