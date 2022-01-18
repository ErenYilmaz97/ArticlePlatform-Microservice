using Microservice.Identity.Application.Service;
using Microservice.Identity.Application.UnitOfWork;
using Microservice.Identity.Domain.Entity;
using Microservice.Identity.Domain.Enum;
using Microservice.Identity.Domain.Model.User;
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
            _logger.LogInformation($"Email Confirmation Flow Started. - LogTrackId : {request.LogTrackId}");
            await _businessValidatorService.ExecuteConfirmEmailRules(request);

            var user = await _uow.Users.GetAsync(filter: x => x.Id == request.UserId, include : x => x.Include(x => x.CommonTokens), disableTracking : false);
            ConfirmUsersEmail(user);
            RemoveEmailConfirmationTokenFromUser(user, request.ConfirmEmailToken);
            await _uow.CommitChangesAsync();

            _logger.LogInformation($"Account Confirmed Successfully. - LogTrackId : {request.LogTrackId}");
            return new SuccessBusinessResult("Account Confirmed Successfully.");

        }



        public async Task<IBusinessResult> ForgotPassword(ForgotPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessResult> ResetPassword(ResetPasswordRequest request)
        {
            throw new NotImplementedException();
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
        #endregion
    }
}
