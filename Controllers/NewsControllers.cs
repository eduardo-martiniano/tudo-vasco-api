using Microsoft.AspNetCore.Mvc;
using tudo_vasco_api.Interfaces;

namespace tudo_vasco_api.Controllers
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNews([FromQuery] bool onlyImportant = false)
        {
            return Ok(await _newsService.GetNews(onlyImportant));
        }

    }
}
