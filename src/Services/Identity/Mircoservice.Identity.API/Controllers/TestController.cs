using Microservice.Identity.Application.Caching;
using Microservice.Identity.Domain.Entity;
using Microservice.Identity.Domain.Exception;
using Microservice.Identity.Domain.Model;
using Microservice.Identity.Infrastructure.Helper;
using Microservices.Core.CrossCuttingConcerns.Logging;
using Microservices.Core.Utilities.BaseController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Mircoservice.Identity.API.Validator.Test;
using Serilog;

namespace Mircoservice.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : CustomController
    {
        private readonly IIdentityCache _cache;
        private readonly ILogger<TestController> _logger;
        private readonly TokenOptions _tokenOptions;

        public TestController(IIdentityCache cache, ILogger<TestController> logger, IOptions<TokenOptions> tokenOptions)
        {
            this._cache = cache;
            _logger = logger;
            _tokenOptions = tokenOptions.Value;
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



        [HttpPost]
        [Route("ValidationTest")]
        public IActionResult ValidatioTest(TestRequest request)
        {
            return Ok("Model is Valid.");
        }


        [HttpGet]
        [Route("ErrorResponseTest")]
        public IActionResult ErrorResponseTest()
        {
            throw new BusinessException("Test Exception");
        }


        [HttpGet]
        [Route("InternalErrorResponseTest")]
        public IActionResult InternalErrorResponseTest()
        {
            throw new ApplicationException("Internal Error Test");
        }


        [HttpGet]
        [Route("JwtHelperTest")]
        public IActionResult JwtHelperTest()
        {
            
            var token = JwtHelper.CreateUserAccessToken(new User(), _tokenOptions);
            var token2 = JwtHelper.CreateClientAccessToken(new SubscribedClient(), _tokenOptions);
            return Ok();
        }
    }
}
