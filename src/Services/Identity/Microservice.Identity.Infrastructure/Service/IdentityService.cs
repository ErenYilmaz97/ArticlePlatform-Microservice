using Microservice.Identity.Application.Service;
using Microservice.Identity.Application.UnitOfWork;
using Microservice.Identity.Domain.Entity;
using Microservice.Identity.Domain.Enum;
using Microservice.Identity.Domain.Model;
using Microservice.Identity.Domain.Model.Identity;
using Microservice.Identity.Infrastructure.Helper;
using Microservices.Core.Utilities.Result.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Infrastructure.Service
{
    public class IdentityService : IIdentityService
    {
        private readonly IBusinessValidatorService _businessValidatorService;
        private readonly ILogger<IdentityService> _logger;
        private readonly IIdentityUnitOfWork _uow;
        private readonly TokenOptions _tokenOptions;

        public IdentityService(IBusinessValidatorService businessValidatorService, ILogger<IdentityService> logger, IIdentityUnitOfWork uow, IOptions<TokenOptions> tokenOptions)
        {
            _businessValidatorService = businessValidatorService;
            _logger = logger;
            _uow = uow;
            _tokenOptions = tokenOptions.Value;
        }


        public async Task<IBusinessResult> Register(RegisterRequest request)
        {
            _logger.LogInformation($"User Register Flow Started. - LogTrackId : {request.LogTrackId}");
            await _businessValidatorService.ExecuteRegisterRules(request);

            var newUser = CreateUser(request);
            CreateEmailConfirmationToken(newUser);

            _uow.Users.InsertAsync(newUser);
            _uow.CommitChangesAsync();

            await SendAccountConfirmEmail(newUser);
            _logger.LogInformation($"User Successfully Registered.  - LogTrackId : {request.LogTrackId}");

            return new SuccessBusinessResult("User Registered Successfully.");
        }



        public async Task<IBusinessDataResult<ClientToken>> LoginClient(ClientLoginRequest request)
        {
            _logger.LogInformation($"Client Login Flow Started. - LogTrackId : {request.LogTrackId}");
            await _businessValidatorService.ExecuteLoginClientRules(request);

            HashHelper.CreatePasswordHash(request.ClientSecret, out byte[] passwordHash, out byte[] hashedClientSecret);
            var client = await _uow.SubscribedClients.GetAsync(filter: x => x.Id == request.ClientId && x.PasswordHash == hashedClientSecret);

            var clientToken = JwtHelper.CreateClientAccessToken(client, _tokenOptions);

            _logger.LogInformation($"Client Successfully Logged in.  - LogTrackId : {request.LogTrackId}");

            return new SuccessBusinessDataResult<ClientToken>("Client Successfully Logged in.", clientToken);
        }




        public async Task<IBusinessDataResult<UserToken>> LoginUser(UserLoginRequest request)
        {
            _logger.LogInformation($"User Login Flow Started. - LogTrackId : {request.LogTrackId}");
            await _businessValidatorService.ExecuteLoginUserRules(request);


            var user = await _uow.Users.GetAsync(filter: x => x.Email == request.Email, include: x => x.Include(x => x.LoginHistories), disableTracking: false);
            HashHelper.CreatePasswordHash(request.Password,  out byte[] hashedPassword, out byte[] passwordSalt);
   

            if (user.PasswordHash != hashedPassword)
            {
                AddFailedLoginHistoryToUser(user);
                await _uow.CommitChangesAsync();

                _logger.LogInformation($"User Password Does Not Match. - LogTrackId : {request.LogTrackId}");
                return new FailBusinessDataResult<UserToken>("User Password Does Not Match.");
            }

            AddSuccessLoginHistoryToUser(user);
            await _uow.CommitChangesAsync();

            var userToken = JwtHelper.CreateUserAccessToken(user, _tokenOptions);
            _logger.LogInformation($"User Successfully Logged in. - LogTrackId : {request.LogTrackId}");

            return new SuccessBusinessDataResult<UserToken>(userToken);
        }



        public Task<IBusinessDataResult<UserToken>> LoginWithRefreshToken(RefreshTokenLoginRequest request)
        {
            throw new NotImplementedException();
        }


        #region Private Helper Methods

        #region Register Methots
        private User CreateUser(RegisterRequest request)
        {
            HashHelper.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            return new User()
            {
                Name = request.Name,
                LastName = request.LastName,
                Gender = request.Gender,
                Email = request.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                EmailConfirmed = false,
                IsPasswordExpired = false,
                LastLoginDate = DateTime.Now
            };
        }


        private void CreateEmailConfirmationToken(User user)
        {
            var confirmEmailToken = new UserCommonToken()
            {
                TokenType = Domain.Enum.TokenType.ConfirmEmailToken,
                Value = Guid.NewGuid().ToString(),
                ExpireDate = DateTime.Now.AddDays(3),
                IsValid = true
            };

            user.CommonTokens.Add(confirmEmailToken);
        }


        private async Task SendAccountConfirmEmail(User user)
        {
            //Send Email via EmailService
        }

        #endregion


        #region User Login Methots
        private void AddSuccessLoginHistoryToUser(User user)
        {
            var loginHistory = new LoginHistory()
            {
                Succeed = true,
                LoginType = LoginType.DefaultLogin
            };

            user.LoginHistories.Add(loginHistory);
            user.LastLoginDate = DateTime.Now;
        }



        private void AddFailedLoginHistoryToUser(User user)
        {
            var loginHistory = new LoginHistory()
            {
                Succeed = false,
                LoginType = LoginType.DefaultLogin
            };

            user.LoginHistories.Add(loginHistory);
        }
        #endregion

        #endregion

    }
}
