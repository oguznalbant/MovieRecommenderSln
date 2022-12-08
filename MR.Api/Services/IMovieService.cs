namespace MR.Api.Services
{
    public interface IMovieService
    {
        Task<bool> AutoFetchMovies();
    }
}
