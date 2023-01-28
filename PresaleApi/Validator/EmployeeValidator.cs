using FluentValidation;
using PresaleApi.Models;

namespace PresaleApi.Validator
{
    public class EmployeeValidator : AbstractValidator<EmployeeRequest>
    {
        public EmployeeValidator()
        {

            RuleFor(x => x.FirstName).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("Employee Name is required.");
        }
    }
}
