﻿namespace MR.Api.Models.Request
{
    public class GetMovieListRequest : IPaginationRequest
    {
        public int PageSize { get; set; } = 20;

        public int PageNumber { get; set; } = 1;
    }
}
