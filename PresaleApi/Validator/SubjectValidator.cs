using FluentValidation;
using PresaleApi.Models;

namespace PresaleApi.Validator
{
    public class SubjectValidator : AbstractValidator<StateRequest>
    {
        public SubjectValidator()
        {

            RuleFor(x => x.Name).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("Subject Name is required.");
        }
    }
}
