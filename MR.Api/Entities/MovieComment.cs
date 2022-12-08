using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MR.Api.Entities
{
    public class MovieComment
    {
        public MovieComment()
        {
            this.Id = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public int Star { get; set; }

        public string Comment { get; set; }

        public string Email { get; set; }

        public string MovieId { get; set; }
    }
}
