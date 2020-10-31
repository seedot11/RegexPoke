using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RegexPoke.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokeRegexController : ControllerBase
    {
        private readonly ILogger<PokeRegexController> _logger;

        public PokeRegexController(ILogger<PokeRegexController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string Post([FromBody] string[] regex)
        {
            return RegexPoke.RegexPokeService.RegexResults(regex);
        }

        [HttpGet("demo")]
        public string GetDemo()
        {
            return RegexPoke.RegexPokeService.RegexResults(null);
        }
    }
}
