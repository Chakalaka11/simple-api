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
    [Route("[controller]")]
    public class ValueController : ControllerBase
    {
        private readonly ILogger<ValueController> _logger;
        private readonly IValueStorage _valueStorage;

        public ValueController(
            ILogger<ValueController> logger,
            IValueStorage valueStorage)
        {
            _logger = logger;
            _valueStorage = valueStorage;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_valueStorage.GetValue());
        }
        
        [HttpPost]
        public IActionResult Set([FromQuery] int newValue)
        {
            _valueStorage.SetValue(newValue);
            return NoContent();
        }
    }
}
