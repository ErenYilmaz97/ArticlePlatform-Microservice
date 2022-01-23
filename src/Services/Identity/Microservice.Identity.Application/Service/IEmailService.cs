using Microservice.Identity.Domain.Model.Email;
using Microservices.Core.Utilities.Result.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Application.Service
{
    public interface IEmailService
    {
        Task<IBusinessResult> SendConfirmAccountEMail(SendConfirmAccountRequest request);
        Task<IBusinessResult> SendResetPasswordEmail(SendResetPasswordRequest request);
    }
}
