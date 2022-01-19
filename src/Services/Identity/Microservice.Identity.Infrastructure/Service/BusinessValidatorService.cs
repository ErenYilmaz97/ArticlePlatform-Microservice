using Microservice.Identity.Application.Service;
using Microservice.Identity.Application.UnitOfWork;
using Microservice.Identity.Domain.Exception;
using Microservice.Identity.Domain.Model.Identity;
using Microservice.Identity.Domain.Model.User;
using Microservice.Identity.Infrastructure.Helper;
using Microservices.Core.Utilities.Result.Business;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Infrastructure.Service
{
    public class BusinessValidatorService : IBusinessValidatorService
    {
        private readonly ILogger<BusinessValidatorService> _logger;
        private readonly IIdentityUnitOfWork _uow;

        public BusinessValidatorService(ILogger<BusinessValidatorService> logger, IIdentityUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }


        public async Task ExecuteRegisterRules(RegisterRequest request)
        {
            #region Checking Business Rules

            #region Is There a User With Same Email?
            var user = await _uow.Users.GetAsync(filter: x => x.Email == request.Email);

            if(user is null)
            {
                throw new BusinessException("There is a user that using same email.");
            }
            #endregion

            #endregion

            _logger.LogInformation($"Business Validation For Register Succeeded. - LogTrackId : {request.LogTrackId}");
        }




        public async Task ExecuteLoginClientRules(ClientLoginRequest request)
        {
            #region Checking Business Rules

            #region Is Client Id Correct?
            var client = await _uow.SubscribedClients.GetAsync(filter: x => x.Id == request.ClientId);

            if(client is null)
            {
                throw new BusinessException("Client not found.");
            }
            #endregion

            #region Is Client Secret Correct?
            bool isPasswordValid = HashHelper.VerifyPasswordHash(request.ClientSecret, client.PasswordHash, client.PasswordSalt);

            if (!isPasswordValid)
            {
                throw new BusinessException("Client Secret does not Match.");
            }
            #endregion

            #endregion

            _logger.LogInformation($"Business Validation For Client Login Succeeded. - LogTrackId : {request.LogTrackId}");
        }




        public async Task ExecuteLoginUserRules(UserLoginRequest request)
        {
            #region Checking Business Rules

            #region Is There a User With Same Email?
            var user = await _uow.Users.GetAsync(filter: x => x.Email == request.Email);

            if(user is null)
            {
                throw new BusinessException("User Not Found By Email.");
            }
            #endregion

            #region Is User Confirmed His Account?
            if(!user.EmailConfirmed)
            {
                throw new BusinessException("Account Not Confirmed.");
            }
            #endregion

            #endregion

            _logger.LogInformation($"Business Validation For User Login Succeeded. - LogTrackId : {request.LogTrackId}");
        }




        public async Task ExecuteConfirmEmailRules(ConfirmEmailRequest request)
        {
            #region Checking Business Rules

            #region Is Token Exist ?
            var token = await _uow.UserCommonTokens.GetAsync(filter: x => x.Value == request.ConfirmEmailToken);

            if(token is null)
            {
                throw new BusinessException("Email Confirmation Token Not Found.");
            }
            #endregion 

            #region Is Token Belong To The User?
            if(token.UserId != request.UserId)
            {
                throw new BusinessException("Token Is Not Belong To User.");
            }
            #endregion

            #region Is Token Valid?
            if (!token.IsValid)
            {
                throw new BusinessException("Token Is Not Valid.");
            }
            #endregion

            #region Is Token Expired?
            if(token.ExpireDate > DateTime.Now)
            {
                throw new BusinessException("Token Expired.");
            }
            #endregion

            #endregion

            _logger.LogInformation($"Business Validation For Email Confirmation Succeeded. - LogTrackId : {request.LogTrackId}");
        }




        public async Task ExecuteForgotPasswordRules(ForgotPasswordRequest request)
        {
            #region Checking Business Rules

            #region Is There a User With Same Email?
            var user = await _uow.Users.GetAsync(filter: x => x.Email == request.Email);

            if(user is null)
            {
                throw new BusinessException("User Not Found.");
            }
            #endregion

            #region Is User's Account Confirmed ?
            if (!user.EmailConfirmed)
            {
                throw new BusinessException("Account Not Confirmed.");
            }
            #endregion



            #endregion

            _logger.LogInformation($"Business Validation For Forgot Password Succeeded. - LogTrackId : {request.LogTrackId}");
        }




        public async Task ExecuteResetPasswordRules(ResetPasswordRequest request)
        {
            #region Checking Business Rules

            #region Does Token Exist?
            var token = await _uow.UserCommonTokens.GetAsync(filter: x => x.Value == request.ResetPasswordToken);

            if(token is null)
            {
                throw new BusinessException("Reset Password Token Not Found.");
            }
            #endregion

            #region Does Token Belong To User ?
            if(token.UserId != request.UserId)
            {
                throw new BusinessException("Token Does Not Belong To User.");
            }
            #endregion

            #region Does Token Valid ?
            if (!token.IsValid)
            {
                throw new BusinessException("Token Is Not Valid.");
            }
            #endregion

            #region Does Token Expired ?
            if(token.ExpireDate > DateTime.Now)
            {
                throw new BusinessException("Token Expired.");
            }
            #endregion

            #endregion

            _logger.LogInformation($"Business Validation For Reset Password Succeeded. - LogTrackId : {request.LogTrackId}");
        }



        public Task ExecuteLoginWithRefreshTokenRules()
        {
            throw new NotImplementedException();
        }

       
        
    }
}
