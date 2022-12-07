using MongoDB.Driver;
using MR.Api.Data.Abstraction;
using MR.Api.Entities;

namespace MR.Api.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMovieContext _context;

        public MovieRepository(IMovieContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _context
                            .Movies
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<Movie> GetMovie(string id)
        {
            return await _context
                           .Movies
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetMovieByName(string name)
        {
            FilterDefinition<Movie> filter = Builders<Movie>.Filter.ElemMatch(p => p.Name, name);

            return await _context
                            .Movies
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateMovie(Movie movie)
        {
            await _context.Movies.InsertOneAsync(movie);
        }

        public async Task CreateBulkMovie(IEnumerable<Movie> movies)
        {
            await _context.Movies.InsertManyAsync(movies);
        }

        public async Task<bool> UpdateMovie(Movie movie)
        {
            var updateResult = await _context
                                        .Movies
                                        .ReplaceOneAsync(filter: g => g.Id == movie.Id, replacement: movie);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteMovie(string id)
        {
            FilterDefinition<Movie> filter = Builders<Movie>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Movies
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}