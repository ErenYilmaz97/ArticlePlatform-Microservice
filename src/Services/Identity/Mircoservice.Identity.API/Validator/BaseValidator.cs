using FluentValidation;

namespace Mircoservice.Identity.API.BaseValidator
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        //Common Methods That Using in Many Validator Object
        protected bool GreaterThenZero(string input)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(input))
            {
                result = int.TryParse(input, out int inputValue);

                result = result && inputValue > 0;

            }

            return result;
        }


        protected bool NotNullOrEmpty(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}
