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
        public IBusinessResult ExecuteRegisterRules();
        public IBusinessResult ExecuteConfirmEmailRules();
        public IBusinessResult ExecuteForgotPasswordRules();
        public IBusinessResult ExecuteResetPasswordRules();
        public IBusinessResult ExecuteLoginUserRules();
        public IBusinessResult ExecuteLoginClientRules();
        #endregion
    }
}
