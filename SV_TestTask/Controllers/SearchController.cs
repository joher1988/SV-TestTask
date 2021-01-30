using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SV_TestTask.ApplicationServices;
using SV_TestTask.Common.Models;
using SV_TestTask.Dto;

namespace SV_TestTask.Controllers
{
    [Route("Search")]
    public class SearchController
    {
        private readonly ISearchEngine _searchEngine;

        public SearchController(ISearchEngine searchEngine)
        {
            _searchEngine = searchEngine;
        }
        [HttpGet]
        [ProducesDefaultResponseType(typeof(IEnumerable<EntityBase>))]
        public async Task<IActionResult> Search([FromQuery] string searchString)
        {
            var result =_searchEngine.SearchByString(searchString);
            return new OkObjectResult(result);
        }
    }
}