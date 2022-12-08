using System.ComponentModel.DataAnnotations;

namespace MR.Api.Models.Request
{
    public class AddCommentMovieRequest
    {
        [Required]
        public string MovieId { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        [Range(0, 10)]
        public int Point { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}