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

        public string PosterPath { get; set; }

        public bool Adult { get; set; }

        public string Overview { get; set; }

        public string ReleaseDate { get; set; }

        public string OriginalLanguage { get; set; }

        public string BackdropPath { get; set; }

        public decimal Popularity { get; set; }

        // TODO: update after each comment
        public decimal AveragePoint { get; set; }

        public IEnumerable<MovieComment> MovieComments { get; set; }

        public IEnumerable<MovieRecommendation> MovieRecommendations { get; set; }

        public void SetAverageRate(decimal avgRate)
        {
            this.AveragePoint = avgRate;
        }
    }
}
