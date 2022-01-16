using FluentValidation;
using Microservice.Identity.Domain.Model.User;
using Mircoservice.Identity.API.BaseValidator;

namespace Mircoservice.Identity.API.Validator.User
{
    public class ConfirmEmailRequestValidator : BaseValidator<ConfirmEmailRequest>
    {
        public ConfirmEmailRequestValidator()
        {
            RuleFor(x => x.UserId).Must(base.NotNullOrEmpty).WithMessage("User ID can't be null or empty.");
            RuleFor(x => x.ConfirmEmailToken).Must(base.NotNullOrEmpty).WithMessage("Confirm Email Token can't be null or empty.");
        }
    }
}
