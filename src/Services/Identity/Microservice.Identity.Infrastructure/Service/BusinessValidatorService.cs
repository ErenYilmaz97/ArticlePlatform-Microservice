using Microservice.Identity.Application.Service;
using Microservices.Core.Utilities.Result.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Infrastructure.Service
{
    public class BusinessValidatorService : IBusinessValidatorService
    {
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

        public Task<IBusinessResult> ExecuteRegisterRules()
        {
            throw new NotImplementedException();
        }

        public Task<IBusinessResult> ExecuteResetPasswordRules()
        {
            throw new NotImplementedException();
        }
    }
}
