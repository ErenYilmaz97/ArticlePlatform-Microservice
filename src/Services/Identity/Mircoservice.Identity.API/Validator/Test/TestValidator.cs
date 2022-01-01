using FluentValidation;
using Mircoservice.Identity.API.BaseValidator;
using Mircoservice.Identity.API.Validator.Test;

namespace Mircoservice.Identity.API.Validator
{
    public class TestValidator : BaseValidator<TestRequest>
    {
        public TestValidator()
        {
            this.RuleFor(x => x.Value1).Must(GreaterThenZero).WithMessage("Value 1 Alanı Hatalı.");
            this.RuleFor(x => x.Value2).Must(GreaterThenZero).WithMessage("Value 2 Alanı Hatalı.");
            this.RuleFor(x => x.Value3).Must(GreaterThenZero).WithMessage("Value 3 Alanı Hatalı.");
        }
    }
}
