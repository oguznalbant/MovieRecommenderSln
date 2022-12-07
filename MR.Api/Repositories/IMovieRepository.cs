using MR.Api.Entities;

namespace MR.Api.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies();

        Task<Movie> GetMovie(string id);

        Task<IEnumerable<Movie>> GetMovieByName(string name);

        Task CreateMovie(Movie movie);

        Task CreateBulkMovie(IEnumerable<Movie> movies);

        Task<bool> UpdateMovie(Movie movie);

        Task<bool> DeleteMovie(string id);
    }
}
