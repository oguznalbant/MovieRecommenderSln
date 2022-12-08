namespace MR.Api.Models.Request
{
    public class UpdateCommentRateRequest
    {
        public UpdateCommentRateRequest(string movieId)
        {
            this.MovieId = movieId;
        }

        public string MovieId { get; set; }
    }
}