using Microservice.Identity.Application.Service;
using Microservice.Identity.Application.UnitOfWork;
using Microservice.Identity.Domain.Entity;
using Microservice.Identity.Domain.Enum;
using Microservice.Identity.Domain.Model.User;
using Microservice.Identity.Infrastructure.Helper;
using Microservices.Core.CrossCuttingConcerns.Logging;
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
    public class UserService : IUserService
    {
        private readonly IBusinessValidatorService _businessValidatorService;
        private readonly ILogger<UserService> _logger;
        private readonly IIdentityUnitOfWork _uow;

        public UserService(IBusinessValidatorService businessValidatorService, ILogger<UserService> logger, IIdentityUnitOfWork uow)
        {
            _businessValidatorService = businessValidatorService;
            _logger = logger;
            _uow = uow;
        }


        public async Task<IBusinessResult> ConfirmEmail(ConfirmEmailRequest request)
        {
            _logger.LogInformation("{@logObject}", new LogObject("Account Confirmation Flow Started.", request.LogTrackId));
            await _businessValidatorService.ExecuteConfirmEmailRules(request);

            var user = await _uow.Users.GetAsync(filter: x => x.Id == request.UserId, include : x => x.Include(x => x.CommonTokens), disableTracking : false);
            ConfirmUsersEmail(user);
            RemoveEmailConfirmationTokenFromUser(user, request.ConfirmEmailToken);
            await _uow.CommitChangesAsync();

            _logger.LogInformation("{@logObject}", new LogObject("Account Confirmed Successfully.", request.LogTrackId));
            return new SuccessBusinessResult("Account Confirmed Successfully.", request.LogTrackId);

        }



        public async Task<IBusinessResult> ForgotPassword(ForgotPasswordRequest request)
        {
            _logger.LogInformation("{@logObject}", new LogObject("Forgot Password Flow Started.", request.LogTrackId));
            await _businessValidatorService.ExecuteForgotPasswordRules(request);

            var user = await _uow.Users.GetAsync(filter: x => x.Email == request.Email, include: x => x.Include(x => x.CommonTokens), disableTracking: false);
            CreateResetPasswordTokenForUser(user);
            await _uow.CommitChangesAsync();

            SendResetPasswordEmailToUser(user);
            _logger.LogInformation("{@logObject}", new LogObject("Forgot Password Flow Completed Successfully.", request.LogTrackId));

            return new SuccessBusinessResult("Forgot Password Flow Completed.", request.LogTrackId);
        }



        public async Task<IBusinessResult> ResetPassword(ResetPasswordRequest request)
        {
            _logger.LogInformation("{@logObject}", new LogObject("Reset Password Flow Started.", request.LogTrackId));
            await _businessValidatorService.ExecuteResetPasswordRules(request);

            var user = await _uow.Users.GetAsync(filter: x => x.Id == request.UserId, include : x => x.Include(x => x.CommonTokens), disableTracking : false);

            ChangeUserPassword(user, request.NewPassword);
            RemoveResetPasswordTokenFromUser(user, request.ResetPasswordToken);
            await _uow.CommitChangesAsync();

            _logger.LogInformation("{@logObject}", new LogObject("Reset Password Flow Completed Successfully.", request.LogTrackId));

            return new SuccessBusinessResult("Reset Password Flow Completed.", request.LogTrackId);

        }



        #region Private Helper Methods
        private void ConfirmUsersEmail(User user)
        {
            user.EmailConfirmed = true;
            user.EmailConfirmedDate = DateTime.Now;
        }


        private void RemoveEmailConfirmationTokenFromUser(User user, string tokenValue)
        {
            var emailConfirmationToken = user.CommonTokens.First(x => x.Value == tokenValue && x.TokenType == TokenType.ConfirmEmailToken);
            user.CommonTokens.Remove(emailConfirmationToken);
        }


        private void CreateResetPasswordTokenForUser(User user)
        {
            var token = new UserCommonToken() 
            {
                TokenType = TokenType.ResetPasswordToken, 
                Value = Guid.NewGuid().ToString(),
                ExpireDate = DateTime.Now.AddDays(3),
                IsValid = true
            };

            user.CommonTokens.Add(token);
        }

        private void SendResetPasswordEmailToUser(User user)
        {
            //Send Email via EmailService
        }


        private void ChangeUserPassword(User user, string newPassword)
        {
            byte[] passwordHash, passwordSalt;
            HashHelper.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.LastPasswordUpdatedDate = DateTime.Now;
        }

        
        private void RemoveResetPasswordTokenFromUser(User user, string resetPasswordToken)
        {
            var token = user.CommonTokens.First(x => x.Value == resetPasswordToken);
            user.CommonTokens.Remove(token);
        }
        #endregion
    }
}
