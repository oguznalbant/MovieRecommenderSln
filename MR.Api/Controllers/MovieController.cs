﻿using Microsoft.AspNetCore.Mvc;
using MR.Api.Models.Request;
using MR.Api.Models.Response;

namespace MR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<GetMovieResponse>> Get([FromQuery] GetMovieRequest request)
        {
            return Ok();
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<GetMovieListResponse>> GetList([FromQuery] GetMovieListRequest request)
        {
            return Ok();
        }

        [HttpPut(Name = "Update")]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateMovieRequest request)
        {
            return Ok(true);
        }

        [HttpPost(Name = "RecommendMovie")]
        public async Task<ActionResult<bool>> RecommendMovie([FromBody] UpdateMovieRequest request)
        {
            return Ok(true);
        }
    }
}