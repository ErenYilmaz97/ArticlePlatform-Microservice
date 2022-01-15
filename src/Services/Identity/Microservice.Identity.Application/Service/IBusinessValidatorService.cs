using Microservices.Core.Utilities.Result.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Application.Service
{
    public interface IBusinessValidatorService
    {
        #region Proje içerisinde yürütülecek olan business kuralları
        public Task<IBusinessResult> ExecuteRegisterRules();
        public Task<IBusinessResult> ExecuteConfirmEmailRules();
        public Task<IBusinessResult> ExecuteForgotPasswordRules();
        public Task<IBusinessResult> ExecuteResetPasswordRules();
        public Task<IBusinessResult> ExecuteLoginUserRules();
        public Task<IBusinessResult> ExecuteLoginWithRefreshTokenRules();
        public Task<IBusinessResult> ExecuteLoginClientRules();
        #endregion
    }
}
