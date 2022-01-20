using FluentValidation;
using Microservice.Identity.Domain.Model.Identity;
using Mircoservice.Identity.API.BaseValidator;

namespace Mircoservice.Identity.API.Validator.Identity
{
    public class RefreshTokenLoginRequestValidator : BaseValidator<RefreshTokenLoginRequest>
    {
        public RefreshTokenLoginRequestValidator()
        {
            RuleFor(x => x.UserId).Must(base.NotNullOrEmpty).WithMessage("User ID field can't be null or empty.");
            RuleFor(x => x.RefreshToken).Must(base.NotNullOrEmpty).WithMessage("Refresh Token field can't be null or empty.");
        }
    }
}
