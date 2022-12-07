using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MR.Api.Entities
{
    public class Movie
    {
        [BsonId]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public string Note { get; set; }

        public int Point { get; set; }
    }
}
