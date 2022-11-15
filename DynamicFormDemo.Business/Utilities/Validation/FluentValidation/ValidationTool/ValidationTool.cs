using FluentValidation;
using FluentValidation.Results;

namespace DynamicFormDemo.Business.Utilities.Validation.FluentValidation.ValidationTool
{
    public static class ValidationTool
    {
        public static List<ValidationFailure> Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var results = validator.Validate(context);

            return !results.IsValid ? results.Errors : null;
        }
    }
}
