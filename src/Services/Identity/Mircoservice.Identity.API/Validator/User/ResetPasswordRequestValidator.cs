using FluentValidation;
using Microservice.Identity.Domain.Model.User;
using Mircoservice.Identity.API.BaseValidator;

namespace Mircoservice.Identity.API.Validator.User
{
    public class ResetPasswordRequestValidator : BaseValidator<ResetPasswordRequest>
    {
        public ResetPasswordRequestValidator()
        {
            RuleFor(x => x.UserId).Must(base.NotNullOrEmpty).WithMessage("User ID field can't be null or empty.");
            RuleFor(x => x.ResetPasswordToken).Must(base.NotNullOrEmpty).WithMessage("Reset Password Token field can't be null or empty.");
            RuleFor(x => x.NewPassword).Must(base.NotNullOrEmpty).WithMessage("New Password field can't be null or empty.");
            RuleFor(x => x.NewPasswordConfirm).Must(base.NotNullOrEmpty).WithMessage("New Password Confirm field can't be null or empty.");

            When(x => x.NewPassword != null && x.NewPasswordConfirm != null, () =>
            {
                RuleFor(x => x).Must(PasswordsMatch).WithMessage("Password fields must be match.");
            });
        }


        private bool PasswordsMatch(ResetPasswordRequest request)
        {
            return (request.NewPassword == request.NewPasswordConfirm);
        }
    }
}
