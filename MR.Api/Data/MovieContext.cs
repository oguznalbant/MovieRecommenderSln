using MongoDB.Driver;
using MR.Api.Entities;
using MR.Api.Data.Abstraction;

namespace MR.Api.Data
{
    public class MovieContext : IMovieContext
    {
        public MovieContext(IConfiguration configuration)
        {
            Console.WriteLine(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            //Console.WriteLine(JsonSerializer.Serialize(client));

            Console.WriteLine(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            //Console.WriteLine(JsonSerializer.Serialize(database));

            Console.WriteLine(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            Movies = database.GetCollection<Movie>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            //Console.WriteLine(JsonSerializer.Serialize(Movies));
        }

        public IMongoCollection<Movie> Movies { get; }
    }
}