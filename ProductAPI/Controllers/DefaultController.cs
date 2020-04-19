using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("")]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;

        public DefaultController(
            ILogger<DefaultController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetApplicationInfo()
        {            
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            return Ok($"Product Api. v{fileVersionInfo.ProductVersion}");
        }
    }
}
