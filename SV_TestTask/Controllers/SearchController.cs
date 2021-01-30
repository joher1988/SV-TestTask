using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using SV_TestTask.Dto;

namespace SV_TestTask.Controllers
{
    public class SearchController
    {
        public SearchController(ISearchEngine searchEngine)
        {
            
        }
        [HttpGet]
        [ProducesDefaultResponseType(typeof(SearchResultEntity))]
        public async Task<IActionResult> Search([FromQuery] string searchString)
        {

            return new OkObjectResult(null);
        }
    }
}