using Microservice.Identity.Application.Service;
using Microservice.Identity.Domain.Model;
using Microservice.Identity.Domain.Model.Identity;
using Microservices.Core.Utilities.BaseController;
using Microservices.Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mircoservice.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : CustomController
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }


       
        [HttpPost]
        [Route("Register")]
        #region Register Endpoint
        public async Task<IActionResult> Register(RegisterRequest request)
        {
           request.LogTrackId = base.GetLogTrackIdFromHeader();

            var serviceResult = await _identityService.Register(request);

            if(serviceResult.ResultCode == ResultCodes.Success)
            {
                return Ok(new ControllerResponse<object>()
                {
                    ResultCode = serviceResult.ResultCode,
                    ResultMessage = serviceResult.ResultMessage
                });
            }

            return BadRequest(new ControllerResponse<object>()
            {
                ResultCode = serviceResult.ResultCode,
                ResultMessage = serviceResult.ResultMessage
            });
        }
        #endregion



       
        [HttpPost]
        [Route("User/Login")]
        #region User Login Endpoint
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            request.LogTrackId = base.GetLogTrackIdFromHeader();
            var serviceResult = await _identityService.LoginUser(request);

            if (serviceResult.ResultCode == ResultCodes.Success)
            {
                return Ok(new ControllerResponse<UserToken>()
                {
                    ResultCode = serviceResult.ResultCode,
                    ResultMessage = serviceResult.ResultMessage,
                    Data = serviceResult.Data
                });
            }

            return BadRequest(new ControllerResponse<UserToken>()
            {
                ResultCode = serviceResult.ResultCode,
                ResultMessage = serviceResult.ResultMessage
            });
        }
        #endregion




        [HttpPost]
        [Route("Login/RefreshToken")]
        #region Login (Refresh Token) Endpoint
        public async Task<IActionResult> LoginWithRefreshToken(RefreshTokenLoginRequest request)
        {
            request.LogTrackId = base.GetLogTrackIdFromHeader();
            var serviceResult = await _identityService.LoginWithRefreshToken(request);

            if (serviceResult.ResultCode == ResultCodes.Success)
            {
                return Ok(new ControllerResponse<UserToken>()
                {
                    ResultCode = serviceResult.ResultCode,
                    ResultMessage = serviceResult.ResultMessage,
                    Data = serviceResult.Data
                });
            }

            return BadRequest(new ControllerResponse<UserToken>()
            {
                ResultCode = serviceResult.ResultCode,
                ResultMessage = serviceResult.ResultMessage
            });
        }
        #endregion




        [HttpPost]
        [Route("Client/Login")]
        #region Client Login Endpoint
        public async Task<IActionResult> Login(ClientLoginRequest request)
        {
            request.LogTrackId = base.GetLogTrackIdFromHeader();
            var serviceResult = await _identityService.LoginClient(request);

            if (serviceResult.ResultCode == ResultCodes.Success)
            {
                return Ok(new ControllerResponse<ClientToken>()
                {
                    ResultCode = serviceResult.ResultCode,
                    ResultMessage = serviceResult.ResultMessage,
                    Data = serviceResult.Data
                });
            }

            return BadRequest(new ControllerResponse<ClientToken>()
            {
                ResultCode = serviceResult.ResultCode,
                ResultMessage = serviceResult.ResultMessage
            });
        }
        #endregion


    }
}
