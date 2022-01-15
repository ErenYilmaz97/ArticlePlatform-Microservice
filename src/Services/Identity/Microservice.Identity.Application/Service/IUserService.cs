using Microservice.Identity.Domain.Model.User;
using Microservices.Core.Utilities.Result.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Application.Service
{
    public interface IUserService
    {
        public Task<IBusinessResult> ConfirmEmail(ConfirmEmailRequest request);
        public Task<IBusinessResult> ForgotPassword(ForgotPasswordRequest request);
        public Task<IBusinessResult> ResetPassword(ResetPasswordRequest request);

    }
}
