using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;
using DVA.Models;
using DVA.Provider;
using System.Threading.Tasks;

namespace DVA.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> _logger;

        public NewsController(ILogger<NewsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<NewsProviderResponse>> Search(string searchPhrase)
        {
            INewsProvider provider = NewsProviderBase.GetNewsProvider();
            NewsProviderResponse retVal = await provider.SearchAsync(searchPhrase);
            return Ok(retVal);
        }

        [HttpGet]
        public async Task<ActionResult<NewsProviderResponse>> TopHeadlines(string category)
        {
            INewsProvider provider = NewsProviderBase.GetNewsProvider();
            NewsProviderResponse retVal = await provider.TopHeadlinesAsync(category);
            return Ok(retVal);
        }
    }
}
