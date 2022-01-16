using Microservice.Identity.Application.Service;
using Microservice.Identity.Application.UnitOfWork;
using Microservice.Identity.Domain.Exception;
using Microservice.Identity.Domain.Model.Identity;
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

            if(user != null)
            {
                throw new BusinessException("There is a user that using same email.");
            }
            #endregion

            #endregion

            _logger.LogError("Business Validation Succeeded. {@logObject}", new { logTrackId = request.LogTrackId });
        }


        public Task<IBusinessResult> ExecuteConfirmEmailRules()
        {
            throw new NotImplementedException();
        }

        public Task<IBusinessResult> ExecuteForgotPasswordRules()
        {
            throw new NotImplementedException();
        }

        public Task<IBusinessResult> ExecuteLoginClientRules()
        {
            throw new NotImplementedException();
        }

        public Task<IBusinessResult> ExecuteLoginUserRules()
        {
            throw new NotImplementedException();
        }

        public Task<IBusinessResult> ExecuteLoginWithRefreshTokenRules()
        {
            throw new NotImplementedException();
        }

       
        public Task<IBusinessResult> ExecuteResetPasswordRules()
        {
            throw new NotImplementedException();
        }
    }
}
