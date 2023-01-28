using FluentValidation;
using PresaleApi.Models;

namespace PresaleApi.Validator
{
    public class StatesValidator : AbstractValidator<StatesRequest>
    {
        public StatesValidator()
        {

            RuleFor(x => x.Name).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("states Name is required.");
        }
    }
}
