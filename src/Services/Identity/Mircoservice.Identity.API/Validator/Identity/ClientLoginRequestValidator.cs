using FluentValidation;
using Microservice.Identity.Domain.Model.Identity;
using Mircoservice.Identity.API.BaseValidator;

namespace Mircoservice.Identity.API.Validator.Identity
{
    public class ClientLoginRequestValidator : BaseValidator<ClientLoginRequest>
    {
        public ClientLoginRequestValidator()
        {
            RuleFor(x => x.ClientId).Must(base.NotNullOrEmpty).WithMessage("Client ID field can't be null or empty.");
            RuleFor(x => x.ClientSecret).Must(base.NotNullOrEmpty).WithMessage("Client Secret field can't be null or empty.");
        }
    }
}
