using Microservice.Identity.Application.Service;
using Microservice.Identity.Application.UnitOfWork;
using Microservice.Identity.Domain.Enum;
using Microservice.Identity.Domain.Exception;
using Microservice.Identity.Domain.Model.Identity;
using Microservice.Identity.Domain.Model.User;
using Microservice.Identity.Infrastructure.Helper;
using Microservices.Core.Utilities.Result.Business;
using Microsoft.EntityFrameworkCore;
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
                throw new BusinessException("There is a user that using same email.", request.LogTrackId);
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
                throw new BusinessException("Client not found.", request.LogTrackId);
            }
            #endregion

            #region Is Client Secret Correct?
            bool isPasswordValid = HashHelper.VerifyPasswordHash(request.ClientSecret, client.PasswordHash, client.PasswordSalt);

            if (!isPasswordValid)
            {
                throw new BusinessException("Client Secret does not Match.", request.LogTrackId);
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
                throw new BusinessException("User Not Found By Email.", request.LogTrackId);
            }
            #endregion

            #region Is User Confirmed His Account?
            if(!user.EmailConfirmed)
            {
                throw new BusinessException("Account Not Confirmed.", request.LogTrackId);
            }
            #endregion

            #endregion

            _logger.LogInformation($"Business Validation For User Login Succeeded. - LogTrackId : {request.LogTrackId}");
        }




        public async Task ExecuteConfirmEmailRules(ConfirmEmailRequest request)
        {
            #region Checking Business Rules

            #region Does User Exist ?
            var user = await _uow.Users.GetAsync(filter: x => x.Id == request.UserId, include: x => x.Include(x => x.CommonTokens));

            if (user is null)
            {
                throw new BusinessException("User Not Found.", request.LogTrackId);
            }
            #endregion          

            #region Does Token Exist And Belong To User ?
            var token = user.CommonTokens.FirstOrDefault(x => x.Value == request.ConfirmEmailToken && x.TokenType == TokenType.ConfirmEmailToken);

            if (token is null)
            {
                throw new BusinessException("Email Confirmation Token Not Found.", request.LogTrackId);
            }
            #endregion 

            #region Is Token Valid?
            if (!token.IsValid)
            {
                throw new BusinessException("Token Is Not Valid.", request.LogTrackId);
            }
            #endregion

            #region Is Token Expired?
            if(token.ExpireDate > DateTime.Now)
            {
                throw new BusinessException("Token Expired.", request.LogTrackId);
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
                throw new BusinessException("User Not Found.", request.LogTrackId);
            }
            #endregion

            #region Is User's Account Confirmed ?
            if (!user.EmailConfirmed)
            {
                throw new BusinessException("Account Not Confirmed.", request.LogTrackId);
            }
            #endregion



            #endregion

            _logger.LogInformation($"Business Validation For Forgot Password Succeeded. - LogTrackId : {request.LogTrackId}");
        }




        public async Task ExecuteResetPasswordRules(ResetPasswordRequest request)
        {
            #region Checking Business Rules

            #region Does User Exist?
            var user = await _uow.Users.GetAsync(filter: x => x.Id == request.UserId, include: x => x.Include(x => x.CommonTokens));

            if (user is null)
            {
                throw new BusinessException("User Not Found.", request.LogTrackId);
            }
            #endregion

            #region Does Token Exist And Belong To User ?
            var token = user.CommonTokens.FirstOrDefault(x => x.Value == request.ResetPasswordToken && x.TokenType == TokenType.ResetPasswordToken);

            if (token is null)
            {
                throw new BusinessException("Reset Password token Not Found.", request.LogTrackId);
            }
            #endregion

            #region Does Token Valid ?
            if (!token.IsValid)
            {
                throw new BusinessException("Token Is Not Valid.", request.LogTrackId);
            }
            #endregion

            #region Does Token Expired ?
            if(token.ExpireDate > DateTime.Now)
            {
                throw new BusinessException("Token Expired.", request.LogTrackId);
            }
            #endregion

            #endregion

            _logger.LogInformation($"Business Validation For Reset Password Succeeded. - LogTrackId : {request.LogTrackId}");
        }



        public async Task ExecuteLoginWithRefreshTokenRules(RefreshTokenLoginRequest request)
        {
            #region Checking Business Rules

            #region Does User Exist ?
            var user = await _uow.Users.GetAsync(filter: x => x.Id == request.UserId, include : x => x.Include(x => x.CommonTokens));

            if(user is null)
            {
                throw new BusinessException("User Not Found.", request.LogTrackId);
            }
            #endregion

            #region Does Token Exist And Belong To User ?
            var token = user.CommonTokens.FirstOrDefault(x => x.Value == request.RefreshToken && x.TokenType == TokenType.RefreshToken);

            if (token is null)
            {
                throw new BusinessException("User's Refresh Token Not Found.", request.LogTrackId);
            }
            #endregion

            #region Does Token Valid ?
            if (!token.IsValid)
            {
                throw new BusinessException(" Refresh Token Not Valid.", request.LogTrackId);
            }
            #endregion

            #region Does Token Expired ?
            if(token.ExpireDate > DateTime.Now)
            {
                throw new BusinessException("Refresh Token Expired.", request.LogTrackId);
            }
            #endregion

            #endregion

            _logger.LogInformation($"Business Validation For Refresh Token Login Succeeded. - LogTrackId : {request.LogTrackId}");
        }



    }
}
