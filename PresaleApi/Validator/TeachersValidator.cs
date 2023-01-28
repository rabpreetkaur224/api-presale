using FluentValidation;
using PresaleApi.Models;

namespace PresaleApi.Validator
{
    public class TeachersValidator : AbstractValidator<TeachersRequest>
    {
        public TeachersValidator()
        {

            RuleFor(x => x.FirstName).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("Teachers Name is required.");
        }
    }
}
