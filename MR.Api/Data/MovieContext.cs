using MongoDB.Driver;
using MR.Api.Entities;
using MR.Api.Data.Abstraction;

namespace MR.Api.Data
{
    public class MovieContext : IMovieContext
    {
        public MovieContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Movies = database.GetCollection<Movie>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }

        public IMongoCollection<Movie> Movies { get; }
    }
}