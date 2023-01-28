using FluentValidation;
using PresaleApi.Models;

namespace PresaleApi
{
    public class StateValidator : AbstractValidator<StateRequest>
    {
        public StateValidator()
        {

            RuleFor(x => x.Name).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("State Name is required.");
        }
    }
}
