using FluentValidation;
using Microservice.Identity.Domain.Enum;
using Microservice.Identity.Domain.Model.Identity;
using Mircoservice.Identity.API.BaseValidator;

namespace Mircoservice.Identity.API.Validator.Identity
{
    public class RegisterRequestValidator : BaseValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email).Must(base.NotNullOrEmpty).WithMessage("Email field can't be null or empty.");
            RuleFor(x => x.Name).Must(base.NotNullOrEmpty).WithMessage("Name field can't be null or empty.");
            RuleFor(x => x.LastName).Must(base.NotNullOrEmpty).WithMessage("LastName field can't be null or empty.");
            RuleFor(x => x.Password).Must(base.NotNullOrEmpty).WithMessage("Password field can't be null or empty.");
            RuleFor(x => x.PasswordConfirm).Must(base.NotNullOrEmpty).WithMessage("Password Confirm field can't be null or empty.");
            RuleFor(x => x.Gender).IsInEnum().WithMessage("Email field doesn't match for gender.");

            When(x => x.Password != null && x.PasswordConfirm != null, () =>
            {
                RuleFor(x => x).Must(PasswordsMatch).WithMessage("Password fields must be match.");
            });        

        }


        private bool PasswordsMatch(RegisterRequest request)
        {
            return (request.PasswordConfirm == request.Password);
        }
    }
}
