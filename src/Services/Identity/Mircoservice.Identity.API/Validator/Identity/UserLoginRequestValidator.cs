using FluentValidation;
using Microservice.Identity.Domain.Model.Identity;
using Mircoservice.Identity.API.BaseValidator;

namespace Mircoservice.Identity.API.Validator.Identity
{
    public class UserLoginRequestValidator : BaseValidator<UserLoginRequest>
    {
        public UserLoginRequestValidator()
        {
            RuleFor(x => x.Email).Must(base.NotNullOrEmpty).WithMessage("Email field can't be null or empty.");
            RuleFor(x => x.Password).Must(base.NotNullOrEmpty).WithMessage("Password field can't be null or empty.");
        }
    }
}
