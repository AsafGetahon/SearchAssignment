using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Searchassignment.Dal.Entities;
using Searchassignment.Model.DTO;
using Searchassignment.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchassignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IQueryService _queryService;

        public SearchController(IQueryService queryService, IConfiguration configuration)
        {
            _configuration = configuration;
            _queryService = queryService;
        }

        [HttpPost("getResults")]
        public async Task<IActionResult> GetQueryResults(DTOQuery query)
        {
            try
            {
                var result = _queryService.GetQueryResultsAsync(query.QuerySearched);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<QueryEntity>>> GetQueryHistory()
        {
            var result = await _queryService.GetAllQuery();
            return Ok(result);
        }
    }
}
