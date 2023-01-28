using FluentValidation;
using PresaleApi.Models;

namespace PresaleApi.Validator
{
    public class DepartmentValidator : AbstractValidator<DepartmentRequest>
    {
        public DepartmentValidator()
        {

            RuleFor(x => x.Name).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("Department Name is required.");
        }
    }
}
