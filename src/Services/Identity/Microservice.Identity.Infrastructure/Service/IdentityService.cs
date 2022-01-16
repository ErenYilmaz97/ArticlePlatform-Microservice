using Microservice.Identity.Application.Service;
using Microservice.Identity.Application.UnitOfWork;
using Microservice.Identity.Domain.Entity;
using Microservice.Identity.Domain.Model;
using Microservice.Identity.Domain.Model.Identity;
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
    public class IdentityService : IIdentityService
    {
        private readonly IBusinessValidatorService _businessValidatorService;
        private readonly ILogger<IdentityService> _logger;
        private readonly IIdentityUnitOfWork _uow;

        public IdentityService(IBusinessValidatorService businessValidatorService, ILogger<IdentityService> logger, IIdentityUnitOfWork uow)
        {
            _businessValidatorService = businessValidatorService;
            _logger = logger;
            _uow = uow;
        }


        public async Task<IBusinessResult> Register(RegisterRequest request)
        {
            _logger.LogError("User Register Flow Started. {@logObject}", new { logTrackId = request.LogTrackId});
            await _businessValidatorService.ExecuteRegisterRules(request);

            var newUser = CreateUser(request);
            CreateEmailConfirmationToken(newUser);

            _uow.Users.InsertAsync(newUser);
            _uow.CommitChangesAsync();

            await SendAccountConfirmEmail(newUser);
            return new SuccessBusinessResult("User Registered Successfully.");
        }



        public Task<IBusinessDataResult<ClientToken>> LoginClient(ClientLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IBusinessDataResult<UserToken>> LoginUser(UserLoginRequest request)
        {
            throw new NotImplementedException();
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
                PasswordHash = passwordHash
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

        #endregion

    }
}
