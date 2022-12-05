using FluentValidation;
using PresaleApi.Models;

namespace PresaleApi.Validator
{
    public class PropertyTypeValidator : AbstractValidator<PropertyTypeRequest>
    {
        public PropertyTypeValidator()
        {

            RuleFor(x => x.PropertyTypeName).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("PropertyType Name is required.");
        }
    }
}
