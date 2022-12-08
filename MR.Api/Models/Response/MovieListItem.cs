﻿namespace MR.Api.Models.Response
{
    public class MovieListItem
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string OriginalTitle { get; set; }

        public string PosterPath { get; set; }

        public bool Adult { get; set; }

        public string Overview { get; set; }

        public string ReleaseDate { get; set; }

        public string OriginalLanguage { get; set; }

        public string BackdropPath { get; set; }

        public decimal Popularity { get; set; }

        public int VoteCount { get; set; }

        public bool Video { get; set; }

        public decimal VoteAverage { get; set; }
    }
}
