using MR.Api.Entities;
using MR.Api.Models;

namespace MR.Api.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies();

        Task<IEnumerable<Movie>> GetMovies(IPaginationRequest request);

        Task<Movie> GetMovie(string id);

        Task CreateBulkMovie(IEnumerable<Movie> movies);

        Task<bool> UpdateMovie(Movie movie);

        Task AddMovieComment(MovieComment entity);

        Task<IEnumerable<MovieComment>> GetCommentsByMovieId(string movieId);

        Task<bool> UpdateCommentRateOfMovie(string movieId, decimal avgRate);
    }
}
