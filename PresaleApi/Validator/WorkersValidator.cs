using FluentValidation;
using PresaleApi.Models;

namespace PresaleApi.Validator
{
    public class WorkersValidator : AbstractValidator<WorkersRequest>
    {
        public WorkersValidator()
        {

            RuleFor(x => x.FirstName).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("Workers Name is required.");
        }
    }
}
