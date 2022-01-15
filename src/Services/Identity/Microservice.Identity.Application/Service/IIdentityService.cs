using Microservice.Identity.Domain.Model;
using Microservice.Identity.Domain.Model.Identity;
using Microservices.Core.Utilities.Result.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Application.Service
{
    public interface IIdentityService
    {
        public Task<IBusinessResult> Register(RegisterRequest request);
        public Task<IBusinessDataResult<UserToken>> LoginUser(UserLoginRequest request);
        public Task<IBusinessDataResult<UserToken>> LoginWithRefreshToken(RefreshTokenLoginRequest request);
        public Task<IBusinessDataResult<ClientToken>> LoginClient(ClientLoginRequest request);

    }
}
