using Microservice.Identity.Application.Service;
using Microservice.Identity.Domain.Model.User;
using Microservices.Core.Utilities.BaseController;
using Microservices.Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mircoservice.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("ConfirmEmail")]
        #region Confirm Email Endpoint
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailRequest request)
        {
            request.LogTrackId = base.GetLogTrackIdFromHeader();
            var serviceResult = await _userService.ConfirmEmail(request);

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
        [Route("ForgotPassword")]
        #region Forgot Password Endpoint
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            request.LogTrackId = base.GetLogTrackIdFromHeader();
            var serviceResult = await _userService.ForgotPassword(request);

            if (serviceResult.ResultCode == ResultCodes.Success)
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
        [Route("ResetPassword")]
        #region Reset Password Endpoint
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            request.LogTrackId = base.GetLogTrackIdFromHeader();
            var serviceResult = await _userService.ResetPassword(request);

            if (serviceResult.ResultCode == ResultCodes.Success)
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


    }
}
