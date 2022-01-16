using FluentValidation;
using Microservice.Identity.Domain.Model.User;
using Mircoservice.Identity.API.BaseValidator;

namespace Mircoservice.Identity.API.Validator.User
{
    public class ForgotPasswordRequestValidator : BaseValidator<ForgotPasswordRequest>
    {
        public ForgotPasswordRequestValidator()
        {
            RuleFor(x => x.Email).Must(base.NotNullOrEmpty).WithMessage("Email field can't be null or empty.");
        }
    }
}
