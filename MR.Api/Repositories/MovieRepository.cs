using MongoDB.Driver;
using MR.Api.Data.Abstraction;
using MR.Api.Entities;
using MR.Api.Models;

namespace MR.Api.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMovieContext _context;

        public MovieRepository(IMovieContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Get movies
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            try
            {
                return await _context.Movies.Find(p => true).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get movies with pagination
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<Movie>> GetMovies(IPaginationRequest request)
        {
            var skipCount = request.PageSize * (request.PageNumber - 1);
            try
            {
                return await _context.Movies.Find(a => true).Skip(skipCount).Limit(request.PageSize).ToListAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get specified movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Movie> GetMovie(string id)
        {
            try
            {
                return await _context.Movies.Find(p => p.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Insert movies as bulk
        /// </summary>
        /// <param name="movies"></param>
        /// <returns></returns>
        public async Task CreateBulkMovie(IEnumerable<Movie> movies)
        {
            try
            {
                await _context.Movies.InsertManyAsync(movies);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateMovie(Movie movie)
        {
            try
            {
                var result = await _context.Movies.ReplaceOneAsync(filter: g => g.Id == movie.Id, replacement: movie).ConfigureAwait(false);

                return result.IsAcknowledged && result.ModifiedCount > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateCommentRateOfMovie(string movieId, decimal avgRate)
        {
            var movie = await this.GetMovie(movieId).ConfigureAwait(false);

            movie.SetAverageRate(avgRate);

            return await this.UpdateMovie(movie).ConfigureAwait(false);
        }

        /// <summary>
        /// Add a comment to movie
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddMovieComment(MovieComment entity)
        {
            try
            {
                List<MovieComment> movieComments = new List<MovieComment>();
                var movie = await this.GetMovie(entity.MovieId).ConfigureAwait(false);
                if (movie != null)
                {
                    if (movie.MovieComments != null) // eğer doluysa
                    {
                        movieComments = movie.MovieComments.ToList();
                    }

                    movieComments.Add(entity);
                    movie.MovieComments = movieComments;

                    await _context.Movies.ReplaceOneAsync(f => f.Id == movie.Id, movie).ConfigureAwait(false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Comments of movie
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<MovieComment>> GetCommentsByMovieId(string movieId)
        {
            IEnumerable<MovieComment> results = new List<MovieComment>();
            try
            {
                var movies = await _context.Movies.FindAsync(m => m.Id == movieId).ConfigureAwait(false);

                if (movies == null)
                {
                    return results;
                }

                var movie = await movies.FirstOrDefaultAsync().ConfigureAwait(false);

                if (movie.MovieComments == null)
                {
                    return results;
                }

                results = movie.MovieComments;
            }
            catch (Exception)
            {
                throw;
            }

            return results;
        }
    }
}