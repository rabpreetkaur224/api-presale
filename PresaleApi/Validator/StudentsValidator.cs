using FluentValidation;
using PresaleApi.Models;

namespace PresaleApi
{
    public class StudentsValidator : AbstractValidator<SubjectRequest>
    {
        public StudentsValidator()
        {

            RuleFor(x => x.Name).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("Students Name is required.");
        }
    }
}
