using MongoDB.Bson.Serialization.Attributes;

namespace MR.Api.Entities
{
    public class MovieRecommendation
    {
        [BsonId]
        public string? Id { get; set; }

        public string Email { get; set; }

        public string MovieId { get; set; }

        public bool IsRecommended { get; set; }
    }
}
