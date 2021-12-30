using Microservice.Identity.Application.Caching;
using Microservices.Core.CrossCuttingConcerns.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Mircoservice.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IIdentityCache _cache;
        private readonly ILogger<TestController> _logger;

        public TestController(IIdentityCache cache, ILogger<TestController> logger)
        {
            this._cache = cache;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult TestAction()
        {           
            return Ok("Worked");
        }


        [HttpGet]
        [Route("LogTest")]
        public IActionResult LogTest()
        {
            this._logger.LogInformation("TestController Loged");          
            this._logger.LogInformation("{@LogObject} Logged" , new {Value1 = "Anonymus Type", Value2 = "Anonymus Type", Value3 = 20});

            return Ok();
        }


        [HttpGet]
        [Route("ErrorLogTest")]
        public IActionResult ErrorLogTest()
        {
            try
            {
                throw new ApplicationException("Test Exception");
            }
            catch (Exception ex)
            {
                this._logger.LogError("{@Exception} Failed." ,ex);
            }

            return Ok();
        }
    }
}
