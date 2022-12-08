namespace MR.Api.Models.Request
{
    public class RecommendMovieRequest
    {
        public string MovieId { get; set; }
        public string ToMailAddress { get; set; }
    }
}