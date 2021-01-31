using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SV_TestTask.ApplicationServices;
using SV_TestTask.Common.Models;
using SV_TestTask.Dto;

namespace SV_TestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController:ControllerBase
    {
        private readonly ISearchEngine _searchEngine;
        private readonly IMapper _mapper;

        public SearchController(ISearchEngine searchEngine, IMapper mapper)
        {
            _searchEngine = searchEngine;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string searchString=null)
        {
            var result = await _searchEngine.SearchByString(searchString);
            return new OkObjectResult(_mapper.Map<IEnumerable<SearchResultEntity>>(result));
        }
    }
}