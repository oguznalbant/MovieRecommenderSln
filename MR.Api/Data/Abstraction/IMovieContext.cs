using MongoDB.Driver;
using MR.Api.Entities;

namespace MR.Api.Data.Abstraction
{
    public interface IMovieContext
    {
        IMongoCollection<Movie> Movies { get; }
    }
}
