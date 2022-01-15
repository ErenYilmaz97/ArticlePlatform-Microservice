﻿using Microservice.Identity.Application.Service;
using Microservice.Identity.Domain.Model.User;
using Microservices.Core.Utilities.Result.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Infrastructure.Service
{
    public class UserService : IUserService
    {
        public async Task<IBusinessResult> ConfirmEmail(ConfirmEmailRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessResult> ForgotPassword(ForgotPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessResult> ResetPassword(ResetPasswordRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
