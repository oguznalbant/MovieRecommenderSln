using MR.Api.Entities;

namespace MR.Api.Repositories.Abstraction
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovie(string id);
        Task<IEnumerable<Movie>> GetMovieByName(string name);
        //Task<IEnumerable<Movie>> GetMovieByCategory(string categoryName);

        Task CreateMovie(Movie product);
        Task<bool> UpdateMovie(Movie product);
        Task<bool> DeleteMovie(string id);
    }
}
