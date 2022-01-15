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
        public IBusinessResult ExecuteConfirmEmailRules()
        {
            throw new NotImplementedException();
        }

        public IBusinessResult ExecuteForgotPasswordRules()
        {
            throw new NotImplementedException();
        }

        public IBusinessResult ExecuteLoginClientRules()
        {
            throw new NotImplementedException();
        }

        public IBusinessResult ExecuteLoginUserRules()
        {
            throw new NotImplementedException();
        }

        public IBusinessResult ExecuteLoginWithRefreshTokenRules()
        {
            throw new NotImplementedException();
        }

        public IBusinessResult ExecuteRegisterRules()
        {
            throw new NotImplementedException();
        }

        public IBusinessResult ExecuteResetPasswordRules()
        {
            throw new NotImplementedException();
        }
    }
}
