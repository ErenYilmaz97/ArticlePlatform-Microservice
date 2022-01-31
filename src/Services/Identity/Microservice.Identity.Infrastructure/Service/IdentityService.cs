using Microservice.Identity.Application.Service;
using Microservice.Identity.Application.UnitOfWork;
using Microservice.Identity.Domain.Entity;
using Microservice.Identity.Domain.Enum;
using Microservice.Identity.Domain.Exception;
using Microservice.Identity.Domain.Model;
using Microservice.Identity.Domain.Model.Identity;
using Microservice.Identity.Infrastructure.Helper;
using Microservices.Core.CrossCuttingConcerns.Logging;
using Microservices.Core.Utilities.Result;
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
        private readonly IRoleService _roleService;
        private readonly TokenOptions _tokenOptions;
        private readonly IEmailService _emailService;

        public IdentityService(IBusinessValidatorService businessValidatorService, 
                               ILogger<IdentityService> logger, 
                               IIdentityUnitOfWork uow,
                               IRoleService roleService,
                               IOptions<TokenOptions> tokenOptions,
                               IEmailService emailService)
        {
            _businessValidatorService = businessValidatorService;
            _logger = logger;
            _uow = uow;
            _tokenOptions = tokenOptions.Value;
            _roleService = roleService;
            _emailService = emailService;
        }


        public async Task<IBusinessResult> Register(RegisterRequest request)
        {
            _logger.LogInformation("{@logObject}", new LogObject("User Register Flow Started.", request.LogTrackId));
            await _businessValidatorService.ExecuteRegisterRules(request);

            var newUser = CreateUser(request);
            CreateEmailConfirmationToken(newUser);


            var defaultRole = await _roleService.GetDefaultUserRole();
            newUser.Roles.Add(defaultRole.Data);

            _uow.Users.InsertAsync(newUser);
            _uow.CommitChangesAsync();

            await SendAccountConfirmEmail(newUser);
            _logger.LogInformation("{@logObject}", new LogObject("User Registered Successfully.", request.LogTrackId));

            return new SuccessBusinessResult("User Registered Successfully.", request.LogTrackId);
        }



        public async Task<IBusinessDataResult<ClientToken>> LoginClient(ClientLoginRequest request)
        {
            _logger.LogInformation("{@logObject}", new LogObject("Client Login Flow Started.", request.LogTrackId));
            await _businessValidatorService.ExecuteLoginClientRules(request);

            HashHelper.CreatePasswordHash(request.ClientSecret, out byte[] passwordHash, out byte[] hashedClientSecret);
            var client = await _uow.SubscribedClients.GetAsync(filter: x => x.Id == request.ClientId && x.PasswordHash == hashedClientSecret);

            var clientToken = JwtHelper.CreateClientAccessToken(client, _tokenOptions);

            _logger.LogInformation("{@logObject}", new LogObject("Client Successfully Logged in.", request.LogTrackId));

            return new SuccessBusinessDataResult<ClientToken>("Client Successfully Logged in.", clientToken, request.LogTrackId);
        }



        public async Task<IBusinessDataResult<UserToken>> LoginUser(UserLoginRequest request)
        {
            _logger.LogInformation("{@logObject}", new LogObject("User Login Flow Started.", request.LogTrackId));
            await _businessValidatorService.ExecuteLoginUserRules(request);


            var user = await _uow.Users.GetAsync(filter: x => x.Email == request.Email, include: x => x.Include(x => x.LoginHistories).Include(x => x.CommonTokens), disableTracking: false);
            HashHelper.CreatePasswordHash(request.Password,  out byte[] hashedPassword, out byte[] passwordSalt);
   

            if (user.PasswordHash != hashedPassword)
            {
                AddFailedLoginHistoryToUser(user);
                await _uow.CommitChangesAsync();

                _logger.LogInformation("{@logObject}", new LogObject("User Password Does Not Match.", request.LogTrackId));
                return new FailBusinessDataResult<UserToken>("User Password Does Not Match.", request.LogTrackId);
            }

            AddSuccessLoginHistoryToUser(user, LoginType.DefaultLogin);
            RenewRefreshToken(user);
            await _uow.CommitChangesAsync();

            var userToken = JwtHelper.CreateUserAccessToken(user, _tokenOptions);
            _logger.LogInformation("{@logObject}", new LogObject("User Successfully Logged in.", request.LogTrackId));

            return new SuccessBusinessDataResult<UserToken>(userToken, request.LogTrackId);
        }



        public async Task<IBusinessDataResult<UserToken>> LoginWithRefreshToken(RefreshTokenLoginRequest request)
        {
            _logger.LogInformation("{@logObject}", new LogObject("Refresh Token Login Flow Started.", request.LogTrackId));
            await _businessValidatorService.ExecuteLoginWithRefreshTokenRules(request);

            var user = await _uow.Users.GetAsync(filter: x => x.Id == request.UserId, include: x => x.Include(x => x.CommonTokens), disableTracking: false);
            AddSuccessLoginHistoryToUser(user, LoginType.RefreshTokenLogin);
            await _uow.CommitChangesAsync();

            var token = JwtHelper.CreateUserAccessToken(user, _tokenOptions);
            _logger.LogInformation("{@logObject}", new LogObject("Refresh Token Login Flow Completed Successfully.", request.LogTrackId));

            return new SuccessBusinessDataResult<UserToken>(token, request.LogTrackId);
        }



        public async Task<IBusinessResult> ValidateClient(ValidateClientRequest request)
        {
            _logger.LogInformation("{@logObject}", new LogObject("Validate Client Flow Started.", request.LogTrackId));

            var client = await _uow.SubscribedClients.GetAsync(filter: x => x.Id == request.ClientId);

            if(client is null)
            {
                _logger.LogInformation("{@logObject}", new LogObject("Client Not Found.", request.LogTrackId));
                return new FailBusinessResult("Client Not Found.", request.LogTrackId);
            }

            var clientSecretSalt = client.PasswordSalt;
            HashHelper.CreatePasswordHash(request.ClientSecret, out byte[] passwordHash,  out clientSecretSalt);

            bool isPasswordCorrect = HashHelper.VerifyPasswordHash(request.ClientSecret, client.PasswordHash, client.PasswordSalt);

            if (!isPasswordCorrect)
            {
                _logger.LogInformation("{@logObject}", new LogObject("Client Secret Not Correct.", request.LogTrackId));
                return new FailBusinessResult("Client Secret Not Correct", request.LogTrackId);
            }

            return new SuccessBusinessResult("Client Validated.", request.LogTrackId);
            
        }



        public async Task<IBusinessResult> ValidateUser(ValidateUserRequest request)
        {
            _logger.LogInformation("{@logObject}", new LogObject("Validate User Flow Started.", request.LogTrackId));

            var user = await _uow.Users.GetAsync(filter: x => x.Id == request.UserId,
                                                include: x => x.Include(x => x.Roles).ThenInclude(x => x.PermissionGroup).ThenInclude(x => x.Permissions));

            if(user is null)
            {
                _logger.LogInformation("{@logObject}", new LogObject("User Not Found.", request.LogTrackId));
                return new FailBusinessResult("User Not Found.", request.LogTrackId);
            }

            bool userHasPermission = user.Roles.Any(x => x.PermissionGroup.Permissions.Any(x => x.PermissionType == request.Permission));

            if (!userHasPermission)
            {
                _logger.LogInformation("{@logObject}", new LogObject("User Doesn't Have Permission.", request.LogTrackId));
                return new FailBusinessResult("User Doesn't Have Permission..", request.LogTrackId);
            }

            return new SuccessBusinessResult("User Validated.", request.LogTrackId);
        }



        #region Private Helper Methods      
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
            var sendEmailResult = await _emailService.SendConfirmAccountEMail(new Domain.Model.Email.SendConfirmAccountRequest() { Email = user.Email });

            if(sendEmailResult.ResultCode != ResultCodes.Success)
            {
                throw new BusinessException("Failed To Send Confirm Account Email.", string.Empty);
            }
        }
       
    
        private void AddSuccessLoginHistoryToUser(User user, LoginType loginType)
        {
            var loginHistory = new LoginHistory()
            {
                Succeed = true,
                LoginType = loginType
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


        private void RenewRefreshToken(User user)
        {
            var refreshToken = user.CommonTokens.FirstOrDefault(x => x.TokenType == TokenType.RefreshToken);

            if(refreshToken is not null)
            {
                user.CommonTokens.Remove(refreshToken);
            }
            
            //Yeni Refresh Token Oluştur
            var token = new UserCommonToken()
            {
                TokenType= TokenType.RefreshToken,
                Value = Guid.NewGuid().ToString(),
                ExpireDate = DateTime.Now.AddDays(30),
                IsValid = true
            };

            user.CommonTokens.Add(token);
        }
      
          
        #endregion

    }
}
