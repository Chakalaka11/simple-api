using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("")]
    public class DefauldController : ControllerBase
    {
        private readonly ILogger<ValueController> _logger;

        public DefauldController(
            ILogger<ValueController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetApplicationInfo()
        {
            return Ok("Hello world!");
        }
    }
}
