using FluentValidation;
using PresaleApi.Models;

namespace PresaleApi.Validator
{
    public class ConstructionTypeValidator : AbstractValidator<ConstructionTypeRequest>
    {
    
        public ConstructionTypeValidator()
        {

            RuleFor(x => x.ConstructionTypeName).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("Feature Name is required.");
        }
    }
}
