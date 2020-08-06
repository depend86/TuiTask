using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TuiTask.Common.Services.Dictionary;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CacheController : Controller
    {
        private IDictService _dictService;

        public CacheController(IDictService dictService)
        {
            _dictService = dictService;
        }

        [HttpPost]
        [Route("clear")]
        public async Task<IActionResult> Clear()
        {
            _dictService.ClearCache();

            return Ok();
        }
    }
}