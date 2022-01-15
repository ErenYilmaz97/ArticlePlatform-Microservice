using Microservice.Identity.Application.Service;
using Microservice.Identity.Domain.Model;
using Microservice.Identity.Domain.Model.Identity;
using Microservices.Core.Utilities.Result.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Infrastructure.Service
{
    public class IdentityService : IIdentityService
    {
        public Task<IBusinessDataResult<ClientToken>> LoginClient(ClientLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IBusinessDataResult<UserToken>> LoginUser(UserLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IBusinessResult> Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
